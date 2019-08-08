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
    public class cartController : Controller
    {
        FsetMvcEntities db = new FsetMvcEntities();

        public ActionResult Index()
        {
            var cost = db.sendcost.FirstOrDefault();
            if (cost == null)
            {
                ViewBag.SendCost = 0;
            }
            else
            {
                ViewBag.SendCost = cost.SendCost1;
            }
            var result = getproductbasket();
            return View(result);
        }


        public object getproductbasket()
        {


            List<string> _prid = new List<string>();


            if (Request.Cookies.AllKeys.Contains("ProductBasketCookie"))
            {
                var basketCooki = Request.Cookies["ProductBasketCookie"].Value.Split(",".ToCharArray());

                foreach (var item in basketCooki)
                {
                    if (item != null && item != "")
                    {

                        _prid.Add(item);
                    }
                }
                vmProductDetail _vmProductDetail = new vmProductDetail();
                List<ListProduct> dd = new List<ListProduct>();

                for (int j = 0; j < _prid.Count; j++)
                {
                    long _PId = Convert.ToInt64(_prid[j]);



                    var listProduct = (from p in db.Product
                                       where p.StateDelete == false && p.Id == _PId && p.Idparent != 0


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
                    dd.AddRange(listProduct);

                }

                _vmProductDetail.listProducts = dd;

                return _vmProductDetail;

            }

            else
            {
                return null;
            }
        }


        [HttpPost]
        public async Task<ActionResult> registercustomerproduct(itemcart _prop, string discontcode, long? _toltalprice)
        {
            List<CustomerProduct> _customerproduct = new List<CustomerProduct>();
            CustomerProduct _cp = null;
            long cusid = 0;
            if (Request.Cookies.AllKeys.Contains("customerId"))
            {
                cusid = Convert.ToInt64(CreatHash.Decrypt(Request.Cookies["customerId"].Value));
                Customer customerinfo = db.Customer.Where(p => p.Id == cusid).FirstOrDefault();
                if (customerinfo.Mobile == "" || customerinfo.Mobile == null || customerinfo.Address == "" || customerinfo.Address == null)
                {
                    return new HttpStatusCodeResult(504);

                }

            }
            else
            {
                return new HttpStatusCodeResult(501);
            }

            Random r = new Random();

            string factorcode = "";

            for (int i = 0; i < _prop.ListProps.Count(); i++)
            {
                long prid = _prop.ListProps[i].Id;

                #region deletecookie

                HttpCookie cookie = Request.Cookies["ProductBasketCookie"];
                cookie.Expires = DateTime.Now.AddDays(-11);

                Response.Cookies.Add(cookie);

                #endregion

                factorcode = _prop.ListProps[i].Id + r.Next(1, 999999999).ToString() + r.Next(1, 999999999).ToString();

                long _prices;

                var _price = db.ProductProperty.Where(p => p.IdProduct == prid && p.IdProperty == 4).FirstOrDefault().Value;
                _prices = Convert.ToInt64(_price);
                _cp = new CustomerProduct();
                _cp.Count = _prop.ListProps[i].Value;
                _cp.CustomerId = cusid;
                _cp.DateRequest = DateTime.Now;
                _cp.IdState = 1;
                _cp.ProductId = _prop.ListProps[i].Id;
                _cp.StateDelete = false;

                if (discontcode != null && discontcode != "")
                {

                    var discountpercent = db.discountcode.Where(p => p.dicountcode == discontcode).FirstOrDefault().discountpersent;

                    var totalprice = _prices - (_prices * discountpercent);

                    _cp.TotalPrice = _prop.ListProps[i].Value * totalprice;

                    _toltalprice = 0;
                    _toltalprice += _cp.TotalPrice;
                }
                else
                {
                    _cp.TotalPrice = _prop.ListProps[i].Value * _prices;
                    _toltalprice = 0;

                    _toltalprice += _cp.TotalPrice;


                }
                _cp.factorcod = factorcode;
                _customerproduct.Add(_cp);
            }
            factor _f = new factor();
            _f.customerId = cusid;
            _f.dateinsert = DateTime.Now;
            _f.discountcode = discontcode;
            if (discontcode != null && discontcode != "")
            {

                _f.discountpercent = db.discountcode.Where(p => p.dicountcode == discontcode).FirstOrDefault().discountpersent;
            }
            else
            {
                _f.discountpercent = null;
            }
            _f.factorcode = factorcode;
            _f.prcount = _customerproduct.Count();
            _f.statedelete = false;




            _f.totalprice = (long)_toltalprice;

            db.factor.Add(_f);
            db.CustomerProduct.AddRange(_customerproduct);
            await db.SaveChangesAsync();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult deletecartcooki(long id)
        {


            List<string> temp = new List<string>();

            if (Request.Cookies.AllKeys.Contains("ProductBasketCookie"))
            {
                var coockisplit = Request.Cookies["ProductBasketCookie"].Value.Split(",".ToCharArray());


                var listcook = Request.Cookies["ProductBasketCookie"].Value.ToList();

                foreach (var item in coockisplit)
                {
                    temp.Add(item);

                    if (item == id.ToString() || item == "" || item == null)
                    {
                        temp.Remove(item);
                    }



                }
            }

            var basketCooki = "";

            HttpCookie cookie = Request.Cookies["ProductBasketCookie"];
            cookie.Expires = DateTime.Now.AddDays(-11);
            cookie.Value = null;
            Response.Cookies.Remove(Request.Cookies["ProductBasketCookie"].ToString());
            Response.Cookies.Add(cookie);

            var lastItem = "";
            if (temp.Count > 0)
            {
                lastItem = temp.Last();

            }
            foreach (var item2 in temp)
            {
                basketCooki = item2;
                if (item2.Equals(lastItem))
                {
                    cookie.Value += basketCooki;

                }
                else
                {

                    cookie.Value += basketCooki + ",";
                }

            }
            cookie.Expires = DateTime.Now.AddDays(10);


            Response.Cookies.Add(cookie);

            return Json("ok", JsonRequestBehavior.AllowGet);
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

            }
            else if (_discountcode.numberofuseg >= 1)
            {
                return new HttpStatusCodeResult(509);

            }



            return Json(_discountcode.discountpersent, JsonRequestBehavior.AllowGet);
        }
    }
}