using Common;
using ModuleThree.Contracts;
using ModuleThree.View;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleThree;

public class Module : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        var regionManager = containerProvider.Resolve<IRegionManager>();

        regionManager.RegisterViewWithRegion(Contract.ViewThree, typeof(ViewThree));
        regionManager.RegisterViewWithRegion(Contract.ViewFour, typeof(ViewFour));

    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IModuleAction, ModuleAction>(Contract.ActionName);
    }
}