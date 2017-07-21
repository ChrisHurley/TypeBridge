using System.Runtime.CompilerServices;
using TypeBridge.Sdk;

[assembly: InternalsVisibleTo("TypeBridge.Input.DotNetDll.Tests")]

namespace TypeBridge.Input.DotNetDll
{
    public class DotNetDllInput : IInputPlugin<DotNetDllInputConfiguration>
    {
        public DotNetDllInputConfiguration Configuration { get; set; }
    }
}
