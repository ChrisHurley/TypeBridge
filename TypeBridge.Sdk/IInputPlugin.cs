namespace TypeBridge.Sdk
{
    public interface IInputPlugin<TConfiguration>
    {
        TConfiguration Configuration { get; set; }
    }
}
