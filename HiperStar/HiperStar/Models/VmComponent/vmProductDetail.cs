using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiperStar.Models.VmComponent
{
    public class vmProductDetail
    {
        public List<ListProduct> listProducts { get; set; }


        public List<ProductSuggestion> _productsuggest { get; set; }


        public Product _mainproduct { get; set; }


        public List<ListRelativeProduct> _relativeproduct { get; set; }
        public string descriptionProduct { get; set; }


    }

    public class ListProduct
    {

        public long ProductId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Price { get; set; }
        public string CustomerPrice { get; set; }
        public string Percent { get; set; }
        public bool? Exist { get; set; }

    }

    public class ListRelativeProduct
    {

        public long Id { get; set; }
        public string ProductName { get; set; }
        public string Url { get; set; }
        public long IdProductSubmain { get; set; }
        public ProductImage ProductImage { get; set; }




    }
}