using HiperStar.Models;
using HiperStar.Models.VmComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HiperStar.Controllers
{
    public class CustumerAreaController : Controller
    {
        FsetMvcEntities db = new FsetMvcEntities();

        public ActionResult Index()
        {
            if (Request.Cookies.AllKeys.Contains("customerId"))
            {
                var result = getcustomerinfo();
                return View(result);
            }
            else
            {
                return RedirectToAction("Index", "SinSup");
            }
        }

        public object getcustomerinfo()
        {

            long cusid = 0;
            cusid = Convert.ToInt64(CreatHash.Decrypt(Request.Cookies["customerId"].Value));
            Customer customerinfo = db.Customer.Where(p => p.Id == cusid && p.Statedelete == false).FirstOrDefault();
            List<CustomerProduct> Cp = db.CustomerProduct.Where(p => p.CustomerId == cusid && p.StateDelete == false).ToList();

            List<CustomerProjectTicket> cpt = db.CustomerProjectTicket.Where(p => p.IdCustomer == cusid).ToList();

            vmCArea _vmCArea = new vmCArea();
            _vmCArea.Customer = customerinfo;
            _vmCArea.CustomerProducts = Cp;
            _vmCArea.CustomerProjectTickets = cpt;


            return _vmCArea;



        }


        [HttpPost]
        public async Task<ActionResult> deletecustomerproduct(CustomerProduct _deletecustomerproduct)
        {
            long cusid = 0;
            if (Request.Cookies.AllKeys.Contains("customerId"))
            {
                cusid = Convert.ToInt64(CreatHash.Decrypt(Request.Cookies["customerId"].Value));
                CustomerProduct customerProduct = db.CustomerProduct.Where(p => p.CustomerId == cusid && p.Id == _deletecustomerproduct.Id).FirstOrDefault();
                customerProduct.StateDelete = true;
                customerProduct.DateDelete = DateTime.Now;
                customerProduct.ResonOfCancelletion = _deletecustomerproduct.ResonOfCancelletion;
                await db.SaveChangesAsync();
                return Json("Ok", JsonRequestBehavior.AllowGet);

            }
            else
            {

                return new HttpStatusCodeResult(506);
            }


        }


        [HttpPost]
        public ActionResult getmainproduct()
        {
            var listpr = db.Product.Where(p => p.Idparent == 0)
                .Select(p => new { p.Id, display = p.Name }).ToList();
            return Json(listpr, JsonRequestBehavior.AllowGet);
        }


       

        public ActionResult LogOut()
        {
            if (Request.Cookies.AllKeys.Contains("customerId"))
            {
                HttpCookie cookie = Request.Cookies["customerId"];
                cookie.Expires = DateTime.Now.AddDays(-2);

                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "SinSup");
            }
            else
            {
                return RedirectToAction("Index", "SinSup");
            }

        }
    }
}