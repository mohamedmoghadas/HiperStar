using HiperStar.Models;
using HiperStar.Models.VmComponent;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HiperStar.Controllers
{
    public class PaymentController : Controller
    {
        FsetMvcEntities db = new FsetMvcEntities();

        public ActionResult Index()
        {
            long cusid = 0;
            if (Request.Cookies.AllKeys.Contains("customerId"))
            {
                cusid = Convert.ToInt64(CreatHash.Decrypt(Request.Cookies["customerId"].Value));
                Customer customerinfo = db.Customer.Where(p => p.Id == cusid).FirstOrDefault();

                if (customerinfo.Mobile == "" || customerinfo.Mobile == null || customerinfo.Address == "" || customerinfo.Address == null)
                {
                    return RedirectToAction("Index", "fCArea");

                }



                List<CustomerProduct> CustomerProduct = db.CustomerProduct.Where(p => p.CustomerId == cusid && p.IdState == 1 && p.StateDelete == false).ToList();

                if (CustomerProduct.Count() > 0 && CustomerProduct != null)
                {
                    var result = getinfopaymentpage();
                    return View(result);

                }

                else
                {
                    return RedirectToAction("Index", "fproducts");
                }
            }
            else
            {
                return RedirectToAction("Index", "fLR");
            }
        }
        public object getinfopaymentpage()
        {
            long cusid = 0;

            cusid = Convert.ToInt64(CreatHash.Decrypt(Request.Cookies["customerId"].Value));
            Customer customerinfo = db.Customer.Where(p => p.Id == cusid).FirstOrDefault();
            List<CustomerProduct> CustomerProduct = db.CustomerProduct.Where(p => p.CustomerId == cusid && p.IdState == 1 && p.StateDelete == false).ToList();


            long? amount = 0;
            long sendcost = 0;

            var sendcost1 = db.sendcost.FirstOrDefault();

            if (sendcost1 == null)
            {
                sendcost = 0;
            }
            else
            {
                sendcost = sendcost1.SendCost1;
            }

            foreach (var item in CustomerProduct)
            {
                amount += item.TotalPrice;
            }
            amount = amount + sendcost;

            vmPayment _vmPayment = new vmPayment();
            _vmPayment.Amount = amount;
            _vmPayment.Customerinfo = customerinfo;
            _vmPayment.sendcoust = sendcost;
            _vmPayment.CustomerProduct = CustomerProduct;

            return _vmPayment;

        }

       




        [HttpPost]

        public async Task<ActionResult> checkdiscountcod(string dicode)
        {
            long cusid = 0;
            if (Request.Cookies.AllKeys.Contains("customerId"))
            {
                cusid = Convert.ToInt64(CreatHash.Decrypt(Request.Cookies["customerId"].Value));
                Customer customerinfo = db.Customer.Where(p => p.Id == cusid).FirstOrDefault();
            }
            else
            {
                return new HttpStatusCodeResult(508);

            }

            discountcode _discountcode = db.discountcode.Where(p => p.dicountcode == dicode).FirstOrDefault();
            if (_discountcode == null)
            {
                return new HttpStatusCodeResult(506);
            }



            DateTime dateend = _discountcode.dateende;
            DateTime datenow = DateTime.Now;


            if (datenow > dateend)
            {
                return new HttpStatusCodeResult(507);

            }


            if (_discountcode.numberofuseg == 0 || _discountcode.numberofuseg == null)
            {
                _discountcode.numberofuseg = 1;
                _discountcode.customerid = cusid;
                await db.SaveChangesAsync();

                List<CustomerProduct> customerProducts = db.CustomerProduct.Where(p => p.CustomerId == cusid && p.IdState == 1).ToList();

                foreach (var item in customerProducts)
                {
                    factor factor = db.factor.Where(p => p.factorcode == item.factorcod).FirstOrDefault();
                    factor.discountcode = _discountcode.dicountcode;
                    factor.discountpercent = _discountcode.discountpersent;

                }
                await db.SaveChangesAsync();
            }
            else if (_discountcode.numberofuseg >= 1)
            {
                return new HttpStatusCodeResult(509);

            }





            return Json(_discountcode.discountpersent, JsonRequestBehavior.AllowGet);
        }
    }
}