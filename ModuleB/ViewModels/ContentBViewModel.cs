using ModuleB.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismSandBox.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleB.ViewModels
{
    public class ContentBViewModel : BindableBase, INavigationAware, IConfirmNavigationRequest, IRegionMemberLifetime
    {
        private IRegionNavigationService _navigationService;

        private IRegionManager _regionManager;

        private int _count = 0;
        public int Count { get { return _count; } set { _count = value; RaisePropertyChanged(); } }

        public ContentBViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            GoForward = new DelegateCommand(OnGoForward);
            GoBackward = new DelegateCommand(OnGoBackward);
        }

        private void OnGoBackward()
        {
            _navigationService.NavigationFailed += _navigationService_NavigationFailed;            
            _navigationService.Journal.GoBack();
        }

        private void _navigationService_NavigationFailed(object sender, RegionNavigationFailedEventArgs e)
        {
            
        }

        private void OnGoForward()
        {

        }

        public bool KeepAlive => false;        

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
