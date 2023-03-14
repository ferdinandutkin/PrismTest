using Common;
using ModuleCommon;

namespace ModuleOne.Contracts;

public class Contract : StaticModuleContractBase
{
    public static string ModuleName => "ModuleOne";
    public static string ViewOne => nameof(Views.ViewOne);

    public static string ActionName => "ActionOne";
}