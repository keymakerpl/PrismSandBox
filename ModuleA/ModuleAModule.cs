using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using PrismSandBox.Infrastructure;
using System;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {

        IUnityContainer _container;
        IRegionManager _regionManager;


        public ModuleAModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            IRegion region = _regionManager.Regions[RegionNames.ToolbarRegion];
            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());

            //_regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ToolbarView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentView));
        }
    }
}
