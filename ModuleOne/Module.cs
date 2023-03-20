using Common;
using ModuleOne.Contracts;
using ModuleOne.View;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
namespace ModuleOne;

public class Module : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        var regionManager = containerProvider.Resolve<IRegionManager>();

        regionManager.RegisterViewWithRegion(Contract.ViewOne, typeof(ViewOne));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IModuleAction, ModuleAction>(Contract.ActionName);
        
    }
}