using Common;

namespace ModuleCommon;

public class ModuleActionBase : IModuleAction
{
    private readonly string _moduleName;
    private readonly IStringRenderer _stringRenderer;

    protected ModuleActionBase(string moduleName, IStringRenderer stringRenderer)
    {
        _moduleName = moduleName;
        _stringRenderer = stringRenderer;
    }

    public void Action()
    {
        _stringRenderer.Render(_moduleName);
    }
}
