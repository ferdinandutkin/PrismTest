using System.Collections.Generic;

namespace WpfApp.Utils;

public class ModuleRegionsInfo
{
    public string ModuleName { get; init; }
    
    public string ActionName { get; set; }
    public IReadOnlyCollection<string> Regions { get; init; }
}