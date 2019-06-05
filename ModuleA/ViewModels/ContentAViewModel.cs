using ModuleB.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismSandBox.Infrastructure;
using System;
using System.Linq;

namespace ModuleA.ViewModels
{
    public class ContentAViewModel : BindableBase, INavigationAware, IConfirmNavigationRequest, IRegionMemberLifetime
    {
        private IRegionNavigationService _navigationService;
        private IRegionManager _regionManager;

        private int _count = 0;
        public int Count { get { return _count; } set { _count = value; RaisePropertyChanged(); } }

        public ContentAViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            GoForward = new DelegateCommand(OnGoForward, OnCanGoForward);
            GoBackward = new DelegateCommand(OnGoBackward, OnCanGoBackward);
        }

        private bool OnCanGoBackward()
        {
            return true;
        }

        private bool OnCanGoForward()
        {
            return true;
        }

        private void OnGoBackward()
        {

        }

        private void OnGoForward()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(ContentBView).FullName);
        }

        public bool KeepAlive => true;        

        public DelegateCommand GoForward { get; }
        public DelegateCommand GoBackward { get; }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _navigationService = navigationContext.NavigationService;
            Count++;
        }
    }
}
