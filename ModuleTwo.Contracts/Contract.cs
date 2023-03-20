using Common;
using ModuleCommon;

namespace ModuleTwo.Contracts;

public class Contract : StaticModuleContractBase
{
    public static string ModuleName => "ModuleTwo";

    public static string ViewTwo => nameof(Views.ViewTwo);
    
    public static string ActionName => "ActionTwo";
}