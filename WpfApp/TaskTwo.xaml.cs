using Prism.Regions;
using WpfApp.ViewModel;

namespace WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class TaskTwo
{
    public TaskTwo(TaskTwoViewModel viewModel, IRegionManager manager)
    {
        InitializeComponent();
        
        this.DataContext = viewModel;
        
    }

}


