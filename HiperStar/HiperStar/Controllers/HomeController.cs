using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiperStar.Models;
using HiperStar.Models.VmComponent;

namespace HiperStar.Controllers
{
    public class HomeController : Controller
    {
        FsetMvcEntities db = new FsetMvcEntities();
        public ActionResult Index()
        {
            var result = GetInfoHome();

            return View(result);
        }

        private object GetInfoHome()
        {
            List<SlidShow> ListSlidShows = db.SlidShow.Where(p=>p.StateDelete==false).ToList();
            List<Product> ListProduct = db.Product.Where(p => p.StateDelete == false && p.Idparent==0).Take(6).ToList();



            VmHome vmHome = new VmHome();
            vmHome.ListSlidShows = ListSlidShows;
            vmHome.ListProduct = ListProduct;




            return vmHome;
        }

        [HttpPost]

        public JsonResult AddtoBasket(string id)
        {
            //  long id2 = Convert.ToInt64(id);
            //  var idparent = db.Product.Find(id2);

            var basketCooki = "";
            if (Request.Cookies.AllKeys.Contains("ProductBasketCookie"))
            {
                if (!Request.Cookies["ProductBasketCookie"].Value.Contains(id))
                {
                    basketCooki = Request.Cookies["ProductBasketCookie"].Value + "," + id;
                    Request.Cookies["ProductBasketCookie"].Value = basketCooki;
                    Request.Cookies["ProductBasketCookie"].Expires = DateTime.Now.AddDays(10);
                    Response.Cookies.Add(Request.Cookies["ProductBasketCookie"]);
                }

            }
            else
            {
                HttpCookie cookie2 = new HttpCookie("ProductBasketCookie");
                cookie2.Value = id;
                cookie2.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(cookie2);

            }





            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]

        public JsonResult GetBasketCooki()
        {
            FsetMvcEntities db = new FsetMvcEntities();

            List<AboutUs> aboutUs = db.AboutUs.ToList();



            long _basketCookiCount = 0;

                if (Request.Cookies.AllKeys.Contains("ProductBasketCookie"))
                {
                    var basketCooki = Request.Cookies["ProductBasketCookie"].Value.Split(",".ToCharArray());
                    foreach (var item in basketCooki)
                    {
                        if (item != null && item != "")
                        {

                            _basketCookiCount++;
                        }
                    }
                    
                }

            return Json(_basketCookiCount, JsonRequestBehavior.AllowGet);
            
           
        }
    }
}