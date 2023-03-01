using ModuleTwo.View;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleTwo;

public class Module : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        var regionManager = containerProvider.Resolve<IRegionManager>();

        regionManager.RegisterViewWithRegion(nameof(Common.Views.ViewTwo), typeof(ViewTwo));

    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
}