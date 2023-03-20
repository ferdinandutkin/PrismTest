using Common;
using ModuleCommon;
using ModuleThree.Contracts;

namespace ModuleThree;

class ModuleAction : ModuleActionBase
{
    public ModuleAction(IStringRenderer stringRenderer) : base(Contract.ModuleName, stringRenderer)
    {
    }
}