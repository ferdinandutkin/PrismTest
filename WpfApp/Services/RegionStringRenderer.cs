using System.Windows.Controls;
using Common;
using Prism.Regions;

namespace WpfApp.Services;

public class RegionStringRenderer : IStringRenderer
{
    public static string RegionName => "StringRegion";
    private static string ViewName => "StringRegionRendererView";
    
    private readonly IRegionManager _regionManager;

    public RegionStringRenderer(IRegionManager regionManager)
    {
        _regionManager = regionManager;
    }
    public void Render(string toRender)
    {
        var targetRegion = _regionManager.Regions[RegionName];

        if (targetRegion is null) return;
        
        if (targetRegion.GetView(ViewName) is TextBlock textBlock)
        {
            textBlock.Text = toRender;
        }
        else
        {
            targetRegion.Add(new TextBlock() {Text = toRender}, ViewName);
        }
    }
    
    
}