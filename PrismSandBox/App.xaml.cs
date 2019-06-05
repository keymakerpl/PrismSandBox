using ModuleA;
using ModuleB;
using Prism.Ioc;
using Prism.Modularity;
using PrismSandBox.Views;
using System.Windows;

namespace PrismSandBox.Application
{
    public partial class App
    {
        //TODO: App unexpected error handler
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule(typeof(ModuleAModule));
            moduleCatalog.AddModule(typeof(ModuleBModule));

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
