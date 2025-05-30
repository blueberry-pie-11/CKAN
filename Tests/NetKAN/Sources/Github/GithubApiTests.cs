using System;
using System.IO;
using System.Linq;

using NUnit.Framework;

using CKAN;
using CKAN.NetKAN.Services;
using CKAN.NetKAN.Sources.Github;

using Tests.Data;

namespace Tests.NetKAN.Sources.Github
{
    [TestFixture]
    [Category("FlakyNetwork"),
     Category("Online")]
    public sealed class GithubApiTests
    {
        // Ironically, despite the fact that these run in CI, which is strongly integrated
        // with GitHub, these sometimes cause test failures because github will throw random
        // 403s. (Hence we disable them in CI with --where="Category!=FlakyNetwork")

        private string?       _cachePath;
        private NetFileCache? _cache;

        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            _cachePath = TestData.NewTempDir();
            var path = Path.Combine(_cachePath, Guid.NewGuid().ToString("N"));

            Directory.CreateDirectory(path);
            _cache = new NetFileCache(path);
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            _cache?.Dispose();
            _cache = null;
            if (_cachePath != null)
            {
                Directory.Delete(_cachePath, recursive: true);
            }
        }

        [Test]
        public void GetsLatestReleaseCorrectly()
        {
            // Arrange
            var sut = new GithubApi(new CachingHttpService(_cache!),
                                    Environment.GetEnvironmentVariable("GITHUB_TOKEN"));

            // Act
            var githubRelease = sut.GetLatestRelease(new GithubRef("#/ckan/github/KSP-CKAN/Test", false), false);

            // Assert
            Assert.IsNotNull(githubRelease?.Author);
            Assert.IsNotNull(githubRelease?.Tag);
            Assert.IsNotNull(githubRelease?.Assets?.FirstOrDefault());
            Assert.IsNotNull(githubRelease?.Assets?.FirstOrDefault()?.Download);
        }
    }
}
