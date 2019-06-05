using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismSandBox.Infrastructure;

namespace ModuleB
{
    public class ModuleBModule : IModule
    {
        private IRegionManager _regionManager;

        public ModuleBModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ContentBView>(typeof(ContentBView).FullName);
        }
    }
}