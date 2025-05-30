using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using CKAN.NetKAN.Model;
using CKAN.NetKAN.Transformers;

namespace Tests.NetKAN.Transformers
{
    [TestFixture]
    public sealed class StripNetkanMetadataTransformerTests
    {
        private readonly TransformOptions opts = new TransformOptions(1, null, null, null, false, null);

        [TestCaseSource(nameof(StripNetkanMetadataTestCaseSource))]
        public void StripNetkanMetadata(string json, string expected)
        {
            // Arrange
            var sut = new StripNetkanMetadataTransformer();

            // Act
            var result = sut.Transform(new Metadata(JObject.Parse(json)), opts).First();
            var transformedJson = result.Json();

            // Assert
            var expectedJson = JObject.Parse(expected);

            Assert.AreEqual(expectedJson, transformedJson);
        }

        private static IEnumerable<object[]> StripNetkanMetadataTestCaseSource
        {
            get
            {
                yield return new object[]
                {
                    @"{
                        ""spec_version"": 1,
                        ""foo"": ""bar""
                    }",
                    @"{
                        ""spec_version"": 1,
                        ""foo"": ""bar""
                    }"
                };

                yield return new object[]
                {
                    @"{
                        ""spec_version"": 1,
                        ""foo"": ""bar"",
                        ""x_netkan"": ""foobar""
                    }
                    ",
                    @"{
                        ""spec_version"": 1,
                        ""foo"": ""bar""
                    }"
                };

                yield return new object[]
                {
                    @"{
                        ""spec_version"": 1,
                        ""foo"": ""bar"",
                        ""x_netkan"": ""foobar"",
                        ""baz"": {
                            ""x_netkan_foo"": ""foobar""
                        }
                    }
                    ",
                    @"{
                        ""spec_version"": 1,
                        ""foo"": ""bar"",
                        ""baz"": {}
                    }"
                };

                yield return new object[]
                {
                    @"{
                        ""spec_version"": 1,
                        ""foo"": [
                            {
                                ""foo"": ""bar"",
                                ""x_netkan_foo"": ""foobar""
                            }
                        ]
                    }",
                    @"{
                        ""spec_version"": 1,
                        ""foo"": [
                            {
                                ""foo"": ""bar""
                            }
                        ]
                    }"
                };

                yield return new object[]
                {
                    @"{
                        ""spec_version"": 1,
                        ""$kref"": ""#/ckan/foo""
                    }",
                    @"{
                        ""spec_version"": 1
                    }",
                };

                yield return new object[]
                {
                    @"{
                        ""spec_version"": 1,
                        ""$vref"": ""#/ckan/foo""
                    }",
                    @"{
                        ""spec_version"": 1
                    }",
                };
            }
        }
    }
}
