using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfApp.ViewModel;

public class MainWindowViewModel : BindableBase
{
    private string _currentView = nameof(Common.Views.ViewOne);

    public ICommand SubmitCommand { get; private set; }
    public string CurrentView
    {
        get => _currentView;
        set => SetProperty(ref this._currentView, value);
    }

    public ObservableCollection<string> Views { get; } = new ObservableCollection<string>();

    public MainWindowViewModel()
    {
        this.SubmitCommand = new DelegateCommand<string>(AddView);
    }


    private void AddView(string regionName)
    {
        Views.Add(regionName);
    }


}
