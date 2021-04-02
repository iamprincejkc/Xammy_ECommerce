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
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public MasterPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateCommand = new DelegateCommand<string>(NavigateCommandExecuted);
        }

        private async void NavigateCommandExecuted(string categoryName)
        {
            var nagivationParams = new NavigationParameters { { "CategoryName", categoryName } };
            await NavigationService.NavigateAsync("/ProductsPage",nagivationParams);
        }
    }
}
