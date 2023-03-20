using System.Linq;
using Common;

namespace WpfApp.Services;

public class CompositeStringRenderer : IStringRenderer
{
    private readonly IStringRenderer[] _stringRenderers;

    public CompositeStringRenderer(params IStringRenderer[] stringRenderers)
    {
        _stringRenderers = stringRenderers;
    }
    public void Render(string toRender)
    {
        foreach (var renderer in _stringRenderers)
        {
            renderer.Render(toRender);
        }
    }
}