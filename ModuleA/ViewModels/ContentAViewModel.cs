using ModuleB.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismSandBox.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ModuleA.ViewModels
{
    public class HwItem
    {
        public string ItemName { get; set; }
        public string Value { get; set; }
    }

    public class ContentAViewModel : BindableBase, INavigationAware, IConfirmNavigationRequest, IRegionMemberLifetime
    {
        private IRegionNavigationService _navigationService;
        private IRegionManager _regionManager;

        public ObservableCollection<HwItem> ItemList { get; private set; }

        private int _count = 0;
        public int Count { get { return _count; } set { _count = value; RaisePropertyChanged(); } }

        public ContentAViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            GoForward = new DelegateCommand(OnGoForward, OnCanGoForward);
            GoBackward = new DelegateCommand(OnGoBackward, OnCanGoBackward);

            InitItemList();
        }

        private void InitItemList()
        {
            ItemList = new ObservableCollection<HwItem>();

            ItemList.Add(new HwItem { ItemName = "Nazwa sprzętu", Value = "Samsung" });
            ItemList.Add(new HwItem { ItemName = "Rodzaj sprzętu", Value = "Laptop" });
            ItemList.Add(new HwItem { ItemName = "Gwarancja", Value = "Tak" });
            ItemList.Add(new HwItem { ItemName = "Opis", Value = "Brak opisu" });
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
