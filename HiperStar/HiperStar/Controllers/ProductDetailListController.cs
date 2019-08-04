using HiperStar.Models;
using HiperStar.Models.VmList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HiperStar.Controllers
{
    public class ProductDetailListController : Controller
    {
        FsetMvcEntities db = new FsetMvcEntities();

        int PageOffSet = 10;
        [HttpPost]
        public ActionResult Index(long? id, string SearchText, int? PageNumber)
        {
            if (PageNumber == null)
            {
                var result = GetProductDetail(id, SearchText, 1);

                return View(result);
            }
            else
            {

                var result = GetProductDetail(id, SearchText, (int)PageNumber);


                return View(result);
            }
        }

        private object GetProductDetail(long? id, string searchText, int PageNumber)
        {
            if (searchText == null)
            {
                searchText = "";
            }
            if (PageNumber <= 0)
            {
                PageNumber = 1;
            }
            int PageSkip = (PageNumber - 1) * PageOffSet;


            List<Product> ProductList = db.Product.Where(p => p.Idparent > 0 && p.Name.Contains(searchText)).ToList();

            if (id != null)
            {
                ProductList = ProductList.Where(p => p.Idparent == id).ToList();
            }
            ProductList = ProductList.Skip(PageSkip)
                    .Take(PageOffSet)
                    .ToList();

            VmProductDetail vmProductDetail = new VmProductDetail();
            vmProductDetail.ProductList = ProductList;
            vmProductDetail.AllPage = (db.Product.Where(p => p.Idparent > 0).Count() / 10) + 1;
            vmProductDetail.CurrentPage = PageNumber;
            return vmProductDetail;
        }

    }
}