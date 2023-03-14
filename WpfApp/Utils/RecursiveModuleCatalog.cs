using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Prism.Modularity;

namespace WpfApp.Utils;

public class RecursiveDirectoryModuleCatalog : DirectoryModuleCatalog
{
    protected override void InnerLoad()
    {
        var directory = new DirectoryInfo(this.ModulePath);
        if (!directory.Exists)
            return;

        var searchOption = SearchOption.AllDirectories;
        
        var moduleFiles = directory.GetFiles("*.dll", searchOption)
            .Union(directory.GetFiles("*.exe", searchOption));

        foreach (var file in moduleFiles)
        {
            var assembly = Assembly.LoadFrom(file.FullName);

            var moduleTypes = assembly.GetTypes()
                .Where(type => typeof(IModule).IsAssignableFrom(type));

            foreach (var moduleType in moduleTypes)
            {
                var moduleInfo = new ModuleInfo()
                {
                    ModuleName = moduleType.FullName,
                    ModuleType = moduleType.AssemblyQualifiedName,
                    Ref = new Uri(file.FullName, UriKind.Absolute).ToString()
                };

                this.Items.Add(moduleInfo);
            }
        }
    }
}


