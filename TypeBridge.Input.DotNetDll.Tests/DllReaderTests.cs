using System.Linq;
using NUnit.Framework;

namespace TypeBridge.Input.DotNetDll.Tests
{
    [TestFixture]
    public class DllReaderTests : TempFilesInAppDomainTestBase
    {
        [Test, RunInApplicationDomain]
        public void CanReadTypesInAssembly()
        {
            var dllPath = CSharpCompiler.CompileDllFromSourceResources(m_TempDirectory.FolderPath, "Test", "TestClass.cs");

            var inputReader = new DotNetDllInput
            {
                Configuration = new DotNetDllInputConfiguration
                {
                    AssemblyPaths = new [] { dllPath }
                }
            };

            var types = inputReader.GetTypes().ToList();

            Assert.That(types, Has.Count.EqualTo(1));
            Assert.That(types.Single().Name, Is.EqualTo("TestClass"));
        }
    }
}
