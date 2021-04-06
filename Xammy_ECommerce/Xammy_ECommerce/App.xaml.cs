using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using Xammy_ECommerce.Interface;
using Xammy_ECommerce.Services;
using Xammy_ECommerce.ViewModels;
using Xammy_ECommerce.Views;

namespace Xammy_ECommerce
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("MasterPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<MasterPage, MasterPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
            containerRegistry.RegisterForNavigation<ProductsPage, ProductsPageViewModel>();

            containerRegistry.Register<IProductsService, ProductsService>();
            containerRegistry.RegisterForNavigation<ProductDetailsPage, ProductDetailsPageViewModel>();
        }
    }
}
