using NUnit.Framework;
using TypeBridge.Input.DotNetDll.Tests.Helpers;

namespace TypeBridge.Input.DotNetDll.Tests
{
    /// <summary>
    /// Creates a temp directory for each test and destroys it at the end.
    /// Supports tests running in other appdomains (so they can load generated assemblies).
    /// </summary>
    public abstract class TempFilesInAppDomainTestBase
    {
        private const string c_TempDirectoryStoreKey = "TempDirectory";
        protected TempDirectory m_TempDirectory;

        [SetUp]
        public void Setup()
        {
            if (!AppDomainRunner.IsInTestAppDomain)
            {
                m_TempDirectory = TempDirectory.Create();
                AppDomainRunner.DataStore.Set(c_TempDirectoryStoreKey, m_TempDirectory);
            }
            else
            {
                m_TempDirectory = AppDomainRunner.DataStore.Get<TempDirectory>(c_TempDirectoryStoreKey);
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (!AppDomainRunner.IsInTestAppDomain)
            {
                m_TempDirectory.Dispose();
            }
        }
    }
}