using WpfApp.ViewModel;

namespace WpfApp.View;

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


