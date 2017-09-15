using System.Linq;
using NUnit.Framework;
using TypeBridge.Input.DotNetDll.Tests.Helpers;

namespace TypeBridge.Input.DotNetDll.Tests
{
    [TestFixture]
    public class DllReaderTests
    {
        [Test]
        public void CanReadTypesInAssembly()
        {
            using (var tempDirectory = TempDirectory.Create())
            {
                var dllPath = CSharpCompiler.CompileDllFromSourceResources(tempDirectory.FolderPath, "Test", "TestClass.cs");

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
}
