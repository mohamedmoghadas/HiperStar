using HiperStar.Models;
using HiperStar.Models.VmComponent;
using HiperStar.Models.VmList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HiperStar.Controllers
{
    public class ProductDetailController : Controller
    {
        FsetMvcEntities db = new FsetMvcEntities();

        [HttpPost]
        public ActionResult Index(string id)
        {
            if (id == "" || id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var result = GetProductInfo(id);
                return View(result);
            }
        }
        public object GetProductInfo(string id)
        {
            long idproduct = Convert.ToInt64(CreatHash.Decrypt(id));


            Product _mainproduct = db.Product.Where(p => p.StateDelete == false && p.Id == idproduct).FirstOrDefault();

            var _Pr = (from p in db.Product
                       where p.StateDelete == false && p.Id == idproduct && p.Idparent != 0


                       select new ListProduct
                       {
                           ProductId = p.Id,
                           Name = p.Name,
                           ImageUrl = db.ProductImage.FirstOrDefault(x => x.IdProduct == p.Id && x.StateDelete == false).Url,
                           Price = db.ProductProperty.FirstOrDefault(x => x.IdProduct == p.Id && x.IdProperty == 3).Value,
                           CustomerPrice = db.ProductProperty.FirstOrDefault(x => x.IdProduct == p.Id && x.IdProperty == 4).Value,
                           Percent = db.ProductProperty.FirstOrDefault(x => x.IdProduct == p.Id && x.IdProperty == 6).Value,
                           Exist = p.StateExist,

                       }).ToList();



            var ImageProduct = db.ProductImage.Where(p => p.StateDelete == false && p.IdProduct == idproduct)
             .Select(p => new ImageProduct
             {
                 ProductImageId = p.Id,
                 Url = p.Url
             }).ToList();


            var pGroups = (from pp in db.ProductProperty
                           join pr in db.Property on pp.IdProperty equals pr.Id
                           where pp.StateDelete == false && pr.StateDelete == false
                           && pp.IdProduct == idproduct
                           select new pGroups
                           {
                               IdParent = pr.IdParent
                           }).Distinct().ToList();

            var PropertyList = (from v in pGroups
                                select new PropertyList
                                {
                                    Subject = (from s in db.Property
                                               where s.Id == v.IdParent
                                               select new Propertylisted { Name = s.Name }).ToList(),

                                    Properties = (from _pp in db.ProductProperty
                                                  join _pr in db.Property on _pp.IdProperty equals _pr.Id
                                                  where _pp.StateDelete == false &&
                                                  _pr.IdParent == v.IdParent && _pp.IdProduct == idproduct

                                                  select new ProductPropertylist
                                                  {
                                                      Key = _pr.Name,
                                                      Value = _pp.Value
                                                  }).ToList()
                                }).ToList();



            var _RelativeProduct = db.RelativeProduct.Where(p => p.StateDelete == false && p.IdProductMain == _mainproduct.Idparent).ToList()
             .Select(p => new ListRelativeProduct
             {
                 Id = p.Id,
                 ProductName = p.Product.Name,
                 Url = p.Product.ProductImage.Where(q => q.IdProduct == p.IdProductSubmain).FirstOrDefault().Url
             }).ToList();

            // List<RelativeProduct> _relativproduct = db.RelativeProduct.Where(p => p.StateDelete == false && p.IdProductSubmain == idproduct).ToList();




            vmPrDetail _vmPrDetail = new vmPrDetail();
            _vmPrDetail.Product = _Pr;
            _vmPrDetail.ImageProduct = ImageProduct;
            _vmPrDetail.pGroups = pGroups;
            _vmPrDetail.PropertyList = PropertyList;
            _vmPrDetail._mainproduct = _mainproduct;
            _vmPrDetail._relativeproduct = _RelativeProduct;


            return _vmPrDetail;

        }

    }
}