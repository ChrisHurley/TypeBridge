using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using TypeBridge.Sdk;
using TypeBridge.Sdk.Model;

[assembly: InternalsVisibleTo("TypeBridge.Input.DotNetDll.Tests")]

namespace TypeBridge.Input.DotNetDll
{
    internal class DotNetDllInput : IInputPlugin<DotNetDllInputConfiguration>
    {
        public DotNetDllInputConfiguration Configuration { get; set; }

        private readonly Lazy<IReadOnlyCollection<Assembly>> m_Assemblies;

        public DotNetDllInput()
        {
            m_Assemblies = new Lazy<IReadOnlyCollection<Assembly>>(LoadAssembliesFromConfiguration);
        }

        private IReadOnlyCollection<Assembly> LoadAssembliesFromConfiguration()
        {
            var assemblies = new List<Assembly>();

            foreach (var path in Configuration.AssemblyPaths)
            {
                assemblies.Add(Assembly.ReflectionOnlyLoadFrom(path));
            }

            return assemblies.AsReadOnly();
        }

        public IEnumerable<TbType> GetTypes()
        {
            return m_Assemblies.Value.SelectMany(a => a.GetTypes().Select(DotNetTypeToTbType));
        }

        private TbType DotNetTypeToTbType(Type dotNetType)
        {
            return new TbType(dotNetType.Name);
        }
    }
}

