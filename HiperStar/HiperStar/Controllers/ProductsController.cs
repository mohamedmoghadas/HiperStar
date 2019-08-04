using HiperStar.Models;
using HiperStar.Models.VmList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HiperStar.Controllers
{
    public class ProductsController : Controller
    {
        FsetMvcEntities db = new FsetMvcEntities();
        int PageOffSet = 10;

        public ActionResult Index(string SearchText, int? PageNumber)
        {
            if (PageNumber == null)
            {
                var result = Getdata(SearchText, 1);

                return View(result);
            }
            else
            {
                var result = Getdata(SearchText, (int)PageNumber);

                return View(result);
            }
        }

        private object Getdata(string SearchText, int PageNumber)
        {
            if (SearchText == null)
            {
                SearchText = "";
            }
            if (PageNumber <= 0)
            {
                PageNumber = 1;
            }
            int PageSkip = (PageNumber - 1) * PageOffSet;

            List<Product> ListProduct = db.Product
                .Where(p => p.StateDelete == false && p.Idparent != 0 && p.Name.Contains(SearchText))
                .OrderBy(u => u.Id)
                    .Skip(PageSkip)
                    .Take(PageOffSet)
                    .ToList();

            VmProductDetail _VmProductDetail = new VmProductDetail();
            _VmProductDetail.ProductList = ListProduct;
            _VmProductDetail.AllPage = (db.Product.Where(p => p.StateDelete == false && p.Idparent != 0).Count() / 10) + 1;
            _VmProductDetail.CurrentPage = PageNumber;
            return _VmProductDetail;
        }
    }
}