using System;
using System.Collections.Generic;
using System.Text;

namespace Xammy_ECommerce.Model
{
   public class ProductModel
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public string Thumbnail { get; set; }

        public ProductsEnum Category { get; set; }
        public int ID { get; internal set; }
    }

    public enum ProductsEnum
    {
        Dresses = 0,
        Pants = 2,
        Shoes = 3
    }
}
