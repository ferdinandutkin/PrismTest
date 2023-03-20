using Common;
using ModuleCommon;
using ModuleTwo.Contracts;

namespace ModuleTwo;

class ModuleAction : ModuleActionBase
{
    public ModuleAction(IStringRenderer stringRenderer) : base(Contract.ModuleName, stringRenderer)
    {
    }
}