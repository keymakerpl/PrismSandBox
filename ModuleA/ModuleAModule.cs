﻿using ModuleA.Views;
using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismSandBox.Infrastructure;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private IRegionManager _regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(ContentAView).FullName);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ContentAView>(typeof(ContentAView).FullName);
        }
    }
}