using System.Reflection;
using Common;

namespace ModuleCommon;

public abstract class StaticModuleContractBase : IModuleContract
{
    public IReadOnlyCollection<string> Regions { get; }
    public string Action { get; }

    protected StaticModuleContractBase()
    {
        Regions = GetType()
            .GetProperties(BindingFlags.Static | BindingFlags.Public)
            .Where(property => property.CanRead && property.PropertyType == typeof(string) && property.Name.StartsWith("View"))
            .Select(property => property.GetValue(this))
            .OfType<string>()
            .ToList();
        
        Action = GetType()
            .GetProperties(BindingFlags.Static | BindingFlags.Public)
            .Where(property => property.CanRead && property.PropertyType == typeof(string) && property.Name.Equals("ActionName"))
            .Select(property => property.GetValue(this))
            .OfType<string>()
            .First();
    }
}