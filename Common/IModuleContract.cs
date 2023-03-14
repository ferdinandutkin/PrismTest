namespace Common;

public interface IModuleContract
{
    IReadOnlyCollection<string> Regions { get; }
    
    string Action { get; }
}