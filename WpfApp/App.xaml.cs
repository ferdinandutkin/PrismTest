using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using Common;
using Unity.Injection;
using WpfApp.Services;
using WpfApp.Utils;
using WpfApp.View;
using WpfApp.ViewModel;

namespace WpfApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    protected override Window CreateShell()
    {
        return Container.Resolve<TaskTwo>();
    }

    protected override IModuleCatalog CreateModuleCatalog()
    {
        return new RecursiveDirectoryModuleCatalog() {ModulePath = @".\Modules"};
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterDialog<DialogStringRendererView, DialogStringRendererViewModel>();

        containerRegistry.RegisterSingleton<IStringRenderer>(registry => 
            new CompositeStringRenderer(
                registry.Resolve<RegionStringRenderer>(),
                registry.Resolve<DialogStringRenderer>()));
    }
}