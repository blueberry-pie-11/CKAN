using System;
using System.Linq;

using Newtonsoft.Json.Linq;
using YamlDotNet.RepresentationModel;

using CKAN.Versioning;
using CKAN.Extensions;
using CKAN.NetKAN.Transformers;

namespace CKAN.NetKAN.Model
{
    internal sealed class Metadata
    {
        private const string KrefPropertyName          = "$kref";
        private const string VrefPropertyName          = "$vref";
        public  const string SpecVersionPropertyName   = "spec_version";
        private const string VersionPropertyName       = "version";
        private const string DownloadPropertyName      = "download";
        public  const string UpdatedPropertyName       = "release_date";
        private const string StagedPropertyName        = "x_netkan_staging";
        private const string StagingReasonPropertyName = "x_netkan_staging_reason";

        private readonly JObject _json;

        public string         Identifier      => (string?)_json["identifier"] ?? "";
        public RemoteRef?     Kref            { get; private set; }
        public RemoteRef?     Vref            { get; private set; }
        public ModuleVersion? SpecVersion     { get; private set; }
        public ModuleVersion? Version         { get; private set; }
        public Uri?           Download        { get; private set; }
        public DateTime?      RemoteTimestamp { get; private set; }
        public bool           Staged          { get; private set; }
        public string?        StagingReason   { get; private set; }

        public string[]       Hosts
            => (_json.TryGetValue(DownloadPropertyName, out JToken? downloadToken)
                    ? downloadToken.Type == JTokenType.String
                      && (string?)downloadToken is string url
                          ? Enumerable.Repeat(url, 1)
                          : downloadToken.Children()
                                         .Select(ch => (string?)ch)
                                         .OfType<string>()
                    : Enumerable.Empty<string>())
                .Select(u => new Uri(u).Host)
                .ToArray();

        public Metadata(JObject json)
        {
            _json = json;

            if (json.TryGetValue(KrefPropertyName, out JToken? krefToken))
            {
                if (krefToken.Type == JTokenType.String)
                {
                    Kref = new RemoteRef((string?)krefToken ?? "");
                }
                else
                {
                    throw new Kraken(string.Format("{0} must be a string.", KrefPropertyName));
                }
            }

            if (json.TryGetValue(VrefPropertyName, out JToken? vrefToken))
            {
                if (vrefToken.Type == JTokenType.String)
                {
                    Vref = new RemoteRef((string?)vrefToken ?? "");
                }
                else
                {
                    throw new Kraken(string.Format("{0} must be a string.", VrefPropertyName));
                }
            }

            if (json.TryGetValue(SpecVersionPropertyName, out JToken? specVersionToken))
            {
                if (specVersionToken.Type == JTokenType.Integer && (int)specVersionToken == 1)
                {
                    SpecVersion = new ModuleVersion("v1.0");
                }
                else if (specVersionToken.Type == JTokenType.String)
                {
                    SpecVersion = new ModuleVersion((string?)specVersionToken ?? "");
                }
                else
                {
                    throw new Kraken(string.Format(@"Could not parse {0}: ""{1}""",
                        SpecVersionPropertyName,
                        specVersionToken
                    ));
                }
            }

            if (json.TryGetValue(VersionPropertyName, out JToken? versionToken))
            {
                Version = new ModuleVersion((string?)versionToken ?? "");
            }

            if (json.TryGetValue(DownloadPropertyName, out JToken? downloadToken))
            {
                Download = (downloadToken.Type == JTokenType.String
                                ? (string?)downloadToken
                                : (string?)downloadToken.Children().First())
                            is string s
                                ? new Uri(s)
                                : null;
            }

            if (json.TryGetValue(StagedPropertyName, out JToken? stagedToken))
            {
                Staged = (bool)stagedToken;
            }

            if (json.TryGetValue(StagingReasonPropertyName, out JToken? stagingReasonToken))
            {
                StagingReason = (string?)stagingReasonToken ?? "";
            }

            if (json.TryGetValue(UpdatedPropertyName, out JToken? updatedToken))
            {
                DateTime t = (DateTime)updatedToken;
                RemoteTimestamp = t.ToUniversalTime();
            }
        }

        public Metadata(YamlMappingNode yaml) : this(yaml.ToJObject())
        {
        }

        public static Metadata Merge(Metadata[] modules)
            => //modules is [var m]
               modules.Length == 1
               && modules[0] is var m
                   ? m
                   : PropertySortTransformer.SortProperties(
                       new Metadata(MergeJson(modules.Select(m => m._json)
                                                     .ToArray())));

        public Metadata MergeFrom(JObject[] jsons)
        {
            var mergeSettings = new JsonMergeSettings()
            {
                MergeArrayHandling     = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge,
            };
            var main = Json();
            foreach (var other in jsons)
            {
                main.Merge(other, mergeSettings);
            }
            return new Metadata(main);
        }

        private static JObject MergeJson(JObject[] jsons)
        {
            var mergeSettings = new JsonMergeSettings()
            {
                MergeArrayHandling     = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge,
            };
            var downloads = jsons.SelectMany(json => json[DownloadPropertyName] is JArray arr
                                                         ? arr.Children()
                                                         : Enumerable.Repeat(json[DownloadPropertyName], 1))
                                 .Distinct()
                                 .ToArray();
            var first = jsons.First();
            foreach (var other in jsons.Skip(1))
            {
                if ((string?)first["download_size"] != (string?)other["download_size"]
                    || (string?)first["download_hash"]?["sha1"] != (string?)other["download_hash"]?["sha1"]
                    || (string?)first["download_hash"]?["sha256"] != (string?)other["download_hash"]?["sha256"])
                {
                    // Can't treat the URLs as equivalent if they're different files
                    throw new Kraken(string.Format(
                        "Download from {0} does not match download from {1}",
                        first["download"], other["download"]));
                }
                first.Merge(other, mergeSettings);
            }
            // Merge game version compatibility
            GameVersion.SetJsonCompatibility(first, null, null, null);
            // Only generate array if multiple URLs
            first[DownloadPropertyName] = downloads.Length == 1
                ? downloads.First()
                : JArray.FromObject(downloads);
            return first;
        }

        public string[] Licenses
        {
            get
            {
                var lic = _json["license"];
                switch (lic?.Type)
                {
                    case JTokenType.Array:
                        return lic.Children()
                                  .Select(t => (string?)t)
                                  .OfType<string>()
                                  .ToArray();

                    case JTokenType.String:
                        return new string[] { (string?)lic ?? "" };
                }
                return Array.Empty<string>();
            }
        }

        public bool Redistributable => Licenses.Any(lic => new License(lic).Redistributable);

        public Uri? FallbackDownload
            => Identifier != null
            && Redistributable
            && Version?.ToString().Replace(':', '-') is string verStr
            && (JObject?)_json["download_hash"] is JObject hashes
            && (string?)hashes["sha1"] is string sha1
                ? new Uri($"https://archive.org/download/{Identifier}-{verStr}/{sha1[..8]}-{Identifier}-{verStr}.zip")
                : null;

        public bool Prerelease => _json["release_status"]?.ToString() is "testing" or "development";

        public JObject Json() => (JObject)_json.DeepClone();
    }
}
