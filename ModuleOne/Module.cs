﻿using System.Reflection;
using Common;
using ModuleCommon.View;
using ModuleCommon.ViewModel;
using ModuleOne.Contracts;
using ModuleOne.View;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Services.Dialogs;


namespace ModuleOne;

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

        regionManager.RegisterViewWithRegion(Contract.ViewOne, typeof(ViewOne));
    }

   

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IModuleAction, ModuleAction>(Contract.ActionName);
        containerRegistry.RegisterDialog<DialogBaseView, DialogBaseViewModel>(typeof(ModuleAction).FullName);
    }
}