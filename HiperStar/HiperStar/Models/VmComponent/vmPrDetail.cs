using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiperStar.Models.VmComponent
{
    public class vmPrDetail
    {
        public List<ListProduct> Product { get; set; }
        public List<ImageProduct> ImageProduct { get; set; }
        public List<pGroups> pGroups { get; set; }
        public List<PropertyList> PropertyList { get; set; }
        public Product _mainproduct { get; set; }

        public List<ListRelativeProduct> _relativeproduct { get; set; }
    }
    public class ImageProduct
    {
        public long ProductImageId { get; set; }
        public string Url { get; set; }
    }


    public class pGroups
    {
        public long IdParent { get; set; }
    }

    public class PropertyList
    {
        public List<Propertylisted> Subject { get; set; }
        public List<ProductPropertylist> Properties { get; set; }


    }

    public class Propertylisted
    {
        public string Name { get; set; }
    }


    public class ProductPropertylist
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}