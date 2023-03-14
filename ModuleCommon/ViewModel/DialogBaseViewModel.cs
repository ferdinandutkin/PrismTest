using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace ModuleCommon.ViewModel;

public class DialogBaseViewModel : BindableBase, IDialogAware
{
    private string _message;
    public string Message
    {
        get => _message;
        set => SetProperty(ref _message, value); 
    }

    public DelegateCommand CloseDialogCommand => new(CloseDialog, CanCloseDialog);

    public bool CanCloseDialog() => true;

    public void OnDialogClosed()
    {
    }
    
    protected virtual void CloseDialog()
    {
        RaiseRequestClose(new DialogResult());
    }

    protected virtual void RaiseRequestClose(IDialogResult dialogResult)
    {
        RequestClose?.Invoke(dialogResult);
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
        Message = parameters.GetValue<string>("message");
    }

    public string Title => "Popup window";
    public event Action<IDialogResult>? RequestClose;
}