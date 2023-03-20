using Common;
using Prism.Services.Dialogs;
using WpfApp.View;

namespace WpfApp.Services;

public class DialogStringRenderer : IStringRenderer
{
    private readonly IDialogService _dialogService;

    public DialogStringRenderer(IDialogService dialogService)
    {
        _dialogService = dialogService;
    }
    public void Render(string toRender)
    {
        IDialogParameters parameters = new DialogParameters
        {
            { "message", toRender }
        };
        _dialogService.Show(nameof(DialogStringRendererView), parameters, _ => { });
    }
}