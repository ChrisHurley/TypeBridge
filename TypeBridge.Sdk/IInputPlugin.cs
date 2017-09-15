using System.Collections.Generic;
using TypeBridge.Sdk.Model;

namespace TypeBridge.Sdk
{
    public interface IInputPlugin<TConfiguration>
    {
        TConfiguration Configuration { get; set; }

        IEnumerable<TbType> GetTypes();
    }
}
