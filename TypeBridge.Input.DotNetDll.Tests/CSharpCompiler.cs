using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace TypeBridge.Input.DotNetDll.Tests
{
    internal static class CSharpCompiler
    {
        public static string CompileToDll(string folder, string assemblyName, params string[] sources)
        {
            var syntaxTrees = sources.Select(s => CSharpSyntaxTree.ParseText(s));

            var compilation = CSharpCompilation.Create(assemblyName,
                syntaxTrees,
                new[] {MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location)},
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            var filename = Path.Combine(folder, $"{assemblyName}.dll");

            using (var dllStream = new FileStream(filename, FileMode.Create))
            {
                compilation.Emit(dllStream);
            }

            return filename;
        }

        public static string CompileDllFromSourceResources(string folder, string assemblyName, params string[] resources)
        {
            var sources = resources.Select(ReadResource).ToArray();

            return CompileToDll(folder, assemblyName, sources);
        }

        private static string ReadResource(string resource)
        {
            var thisAssembly = typeof(CSharpCompiler).GetTypeInfo().Assembly;
            var fullyQualifiedResourceName = $"{thisAssembly.GetName().Name}.Source.{resource}";

            using (var resourceStream = thisAssembly.GetManifestResourceStream(fullyQualifiedResourceName))
            using (var streamReader = new StreamReader(resourceStream))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
