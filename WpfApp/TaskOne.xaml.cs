using WpfApp.ViewModel;

namespace WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class TaskOne
{
    public TaskOne(TaskOneViewModel viewModel)
    {
        InitializeComponent();
        
        this.DataContext = viewModel;
    }

}


