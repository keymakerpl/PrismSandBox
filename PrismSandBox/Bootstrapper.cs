using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using ModuleA;
using System.Windows;

namespace PrismSandBox
{
    public class Bootstrapper : UnityBootstrapper
    {
        //protected override IContainerExtension CreateContainerExtension()
        //{
        //    throw new NotImplementedException();
        //}

        //protected override void ConfigureAggregateCatalog()
        //{
        //    base.ConfigureAggregateCatalog();
        //    AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
        //}

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(ModuleAModule));
        }
    }
}
