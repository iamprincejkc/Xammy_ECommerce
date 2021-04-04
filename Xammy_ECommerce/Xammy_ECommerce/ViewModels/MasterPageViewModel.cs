using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xammy_ECommerce.Views;

namespace Xammy_ECommerce.ViewModels
{
    public class MasterPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public MasterPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand<string>(NavigateProduct);
        }

        private void NavigateProduct(string categoryName)
        {
            NavigationParameters nagivationParams = new NavigationParameters();
            nagivationParams.Add("CategoryName",categoryName);
            _navigationService.NavigateAsync("ProductsPage",nagivationParams);
        }
    }
}
