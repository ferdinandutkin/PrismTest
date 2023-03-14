using Common;
using ModuleCommon.View;
using ModuleCommon.ViewModel;
using ModuleThree.Contracts;
using ModuleThree.View;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace ModuleThree;

class ModuleAction : IModuleAction
{
    private readonly IDialogService _service;

    public ModuleAction(IDialogService service)
    {
        _service = service;
    }
    public void Action()
    {
        IDialogParameters parameters = new DialogParameters
        {
            { "message", Contract.ModuleName }
        };
        _service.Show(typeof(ModuleAction).FullName, parameters, result => { });
    }
}

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
        containerRegistry.RegisterDialog<DialogBaseView, DialogBaseViewModel>(typeof(ModuleAction).FullName);
    }
}