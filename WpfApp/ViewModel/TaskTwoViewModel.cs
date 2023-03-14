using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Common;
using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Unity.Injection;
using WpfApp.Utils;

namespace WpfApp.ViewModel;

public class TaskTwoViewModel : BindableBase
{
    private readonly IContainerProvider _containerProvider;

    private ModuleRegionsInfo? _selectedModuleRegionsInfo;
    
    public DelegateCommand CallModuleActionCommand { get; }
    public ModuleRegionsInfo? SelectedModuleRegionsInfo
    {
        get => _selectedModuleRegionsInfo;
        set
        {
            SetProperty(ref _selectedModuleRegionsInfo, value);
            CallModuleActionCommand.RaiseCanExecuteChanged();
        }
    }

    public TaskTwoViewModel(IModuleManager moduleManager, IContainerProvider containerProvider)
    {
        _containerProvider = containerProvider;
        Modules = new ObservableModuleRegionsCollection(moduleManager);

        CallModuleActionCommand = new DelegateCommand(CallModuleAction, () => SelectedModuleRegionsInfo is not null);

    }

    private void CallModuleAction()
    {
        var action = _containerProvider.Resolve<IModuleAction>(SelectedModuleRegionsInfo!.ActionName);
        action.Action();
    }

    public TaskTwoViewModel()
    {
        Modules = null!;
        CallModuleActionCommand = null!;
        _containerProvider = null!;
    }
    public ObservableCollection<ModuleRegionsInfo> Modules { get; }
}