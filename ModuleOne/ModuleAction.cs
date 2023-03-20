using Common;
using ModuleCommon;
using ModuleOne.Contracts;

namespace ModuleOne;

class ModuleAction : ModuleActionBase
{
    public ModuleAction(IStringRenderer stringRenderer) : base(Contract.ModuleName, stringRenderer)
    {
    }
}