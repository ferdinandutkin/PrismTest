using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfApp.ViewModel;

public class TaskOneViewModel : BindableBase
{
  
    public ICommand SubmitCommand { get; private set; }
    public ObservableCollection<string> Views { get; } = new();

    public TaskOneViewModel()
    {
        this.SubmitCommand = new DelegateCommand<string>(AddView);
    }


    private void AddView(string regionName)
    {
        Views.Add(regionName);
    }


}