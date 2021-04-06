using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xammy_ECommerce.Interface;
using Xammy_ECommerce.Model;
using Xammy_ECommerce.Views;

namespace Xammy_ECommerce.ViewModels
{
    public class ProductsPageViewModel : ViewModelBase
    {
        private readonly IProductsService _productsService;

        private ObservableCollection<ProductModel> _ProductsList;
        public ObservableCollection<ProductModel> ProductsList
        {
            get => _ProductsList;
            set
            {
                SetProperty(ref _ProductsList, value);
                RaisePropertyChanged("ProductsList");
            }
        }

        private ProductModel _SelecetdProduct;
        public ProductModel SelectedProduct
        {
            get => _SelecetdProduct;
            set => SetProperty(ref _SelecetdProduct, value);
        }

        public DelegateCommand<ProductModel> ShowProductDetailsCommand { get; private set; }


        public ProductsPageViewModel(INavigationService navigationService, IProductsService productsService)
            : base(navigationService)
        {
            _productsService = productsService;
            ShowProductDetailsCommand = new DelegateCommand<ProductModel>(ShowProductDetails);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            string categoryName = parameters.GetValue<string>("CategoryName");
            Title = categoryName;
            InitData(categoryName);
        }

        private void ShowProductDetails(ProductModel product)
        {
            var navigationParams = new NavigationParameters { { "Product", JsonConvert.SerializeObject(product) } };
            NavigationService.NavigateAsync("ProductDetailsPage", navigationParams);
        }

        private void InitData(string categoryName)
        {
            ProductsList = _productsService.GetProductsByGategoryName(categoryName);
        }

    }
}
