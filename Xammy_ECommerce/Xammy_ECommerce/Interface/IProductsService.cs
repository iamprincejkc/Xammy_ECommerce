using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xammy_ECommerce.Model;

namespace Xammy_ECommerce.Interface
{
    public interface IProductsService
    {
         ObservableCollection<ProductModel> GetProductsByGategoryName(string categoryName);
        ObservableCollection<string> GetProductsImages(long productId);
    }
}
