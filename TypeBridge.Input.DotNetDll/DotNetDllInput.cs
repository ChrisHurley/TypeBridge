using TypeBridge.Sdk;

namespace TypeBridge.Input.DotNetDll
{
    public class DotNetDllInput : IInputPlugin<DotNetDllInputConfiguration>
    {
        public DotNetDllInputConfiguration Configuration { get; set; }
    }
}
