using System.Reflection;
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
            }
        }
    }
}
