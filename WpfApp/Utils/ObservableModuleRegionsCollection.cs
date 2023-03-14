using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Common;
using Prism.Modularity;

namespace WpfApp.Utils;

public class ObservableModuleRegionsCollection : ObservableCollection<ModuleRegionsInfo>
{
    public event Action<IModuleInfo> NewModuleLoaded;

    public ObservableModuleRegionsCollection(IModuleManager moduleManager)
    {
        moduleManager.LoadModuleCompleted += (_, args) =>
        {
            var moduleInfo = args.ModuleInfo;
            var contract = GetContract(moduleInfo);
            var moduleRegionsInfo = new ModuleRegionsInfo
            {
                ModuleName = moduleInfo.ModuleName,
                Regions = contract.Regions,
                ActionName = contract.Action
            };
            Add(moduleRegionsInfo);
        };
    }

    private IModuleContract GetContract(IModuleInfo moduleInfo)
    {
        var moduleUri = new Uri(moduleInfo.Ref);
        var moduleUriLocalPath = moduleUri.LocalPath;
        var moduleFileNameWithoutExtension = Path.GetFileNameWithoutExtension(moduleUriLocalPath);
        var moduleContractFileNameWithoutExtension = $"{moduleFileNameWithoutExtension}.Contracts";
        var moduleContractPath =
            moduleUriLocalPath.Replace(moduleFileNameWithoutExtension, moduleContractFileNameWithoutExtension);
        

        return Assembly.LoadFile(moduleContractPath).ExportedTypes
            .Where(type => typeof(IModuleContract).IsAssignableFrom(type)
                           && !type.IsAbstract
                           && type.IsClass
                           && type.GetConstructor(Type.EmptyTypes) is not null)
            .Select(type => Activator.CreateInstance(type) as IModuleContract)
            .OfType<IModuleContract>()
            .First();
    }
}