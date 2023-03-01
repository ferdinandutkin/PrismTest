using Example;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }
    protected override IModuleCatalog CreateModuleCatalog()

    {
        return new ConfigurationModuleCatalog();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
}
