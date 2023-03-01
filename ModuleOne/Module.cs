using ModuleOne.View;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.ComponentModel;

namespace ModuleOne;

public class Module : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        var regionManager = containerProvider.Resolve<IRegionManager>();

        regionManager.RegisterViewWithRegion(nameof(Common.Views.ViewOne), typeof(ViewOne));

    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
}