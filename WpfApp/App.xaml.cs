using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using WpfApp.Utils;

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
        return new  RecursiveDirectoryModuleCatalog() {ModulePath = @".\Modules"};
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {

    }
}
