using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xammy_ECommerce.Interface;
using Xammy_ECommerce.Model;

namespace Xammy_ECommerce.ViewModels
{
    public class ProductDetailsPageViewModel : ViewModelBase, INavigatedAware
    {
        #region Properties
        private readonly IProductsService productsService;

        private ProductModel productModel;
        private IEnumerable<string> productImagesList;

        public IEnumerable<string> ProductImagesList
        {
            get => productImagesList;
            set => SetProperty(ref productImagesList, value);
        }

        private string productName;
        public string ProductName
        {
            get => productName;
            set => SetProperty(ref productName, value);
        }

        private float price;
        public float Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        private int quantity;
        public int Quantity
        {
            get => quantity;
            set => SetProperty(ref quantity, value);
        }

        private IEnumerable<string> sizeList;
        public IEnumerable<string> SizeList
        {
            get => sizeList;
            set => SetProperty(ref sizeList, value);
        }

        private string selectedSize;
        public string SelectedSize
        {
            get => selectedSize;
            set => SetProperty(ref selectedSize, value);
        }

        #endregion
        #region Commands

        public DelegateCommand IncreaseQuantityCommand { get; set; }
        public DelegateCommand DecreaseQuantityCommand { get; set; }
        public DelegateCommand AddProductToBasketCommand { get; set; }



        #endregion
        public ProductDetailsPageViewModel(INavigationService navigationService, IProductsService productsService)
            : base(navigationService)
        {
            this.productsService = productsService;
            IncreaseQuantityCommand = new DelegateCommand(IncreaseQuantity);
            DecreaseQuantityCommand = new DelegateCommand(DecreaseQuantity);
            AddProductToBasketCommand = new DelegateCommand(AddProductToBasket);
        }

        private void AddProductToBasket()
        {
            MessagingCenter.Send("UpdateBasket", "Add product", productModel);
        }

        private void DecreaseQuantity()
        {
            if (Quantity >= 2)
            {
                Quantity--;
            }
        }

        private void IncreaseQuantity()
        {
            Quantity++;
        }

        public override void Initialize(INavigationParameters parameters)
        {
            var val = parameters.GetValue<ProductModel>("xamlParam");
            //var productModel = JsonConvert.DeserializeObject<ProductModel>(val);
            Title = val.Name;
            ProductImagesList = productsService.GetProductsImages(val.ID);
            ProductName = val.Name;
            Price = val.Price;

            // Fake data 
            SizeList = new List<string>() { "S", "M", "L" };
            Quantity = 1;

        }
    }
}
