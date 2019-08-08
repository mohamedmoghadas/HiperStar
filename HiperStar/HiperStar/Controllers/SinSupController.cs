using HiperStar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HiperStar.Controllers
{
    public class SinSupController : Controller
    {
        FsetMvcEntities db = new FsetMvcEntities();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Index(Customer _customer)
        {
            var _fCustomer = db.Customer.Where(p => p.Statedelete == false && (p.UserName == _customer.UserName || p.Email == _customer.UserName)).FirstOrDefault();
            if (_fCustomer != null)
            {
               

                string encriptpass = CreatHash.HashPass(_customer.Password);

                string hashid = CreatHash.Encrypt(_fCustomer.Id.ToString());

                if (_fCustomer.Password == encriptpass)
                {
                    HttpCookie cookie = new HttpCookie("customerId");

                    cookie.Value = hashid;
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "CustumerArea");

                }
                else
                {

                    ViewBag.WrongIdentity = "1";
                    return View();

                }
            }
            else
            {

                ViewBag.WrongIdentity = "1";
                return View();


            }
        }

        [HttpPost]
        public async Task<ActionResult> mngcustomer(Customer _mcustomer, HttpPostedFileBase _file1)
        {
            string fileImagename = "";


            if (!Request.Cookies.AllKeys.Contains("customerId"))
            {

                var unqusername = db.Customer.Where(p => p.UserName == _mcustomer.UserName).Any();

                var unquemail = db.Customer.Where(p => p.Email == _mcustomer.Email).Any();

                if (unqusername == true || unquemail == true)
                {
                    return new HttpStatusCodeResult(503);
                }

                var pass = CreatHash.HashPass(_mcustomer.Password);
                _mcustomer.Password = pass;

                _mcustomer.DateInsert = DateTime.Now;
                _mcustomer.Statedelete = false;

                if (Request.Files != null && Request.Files.Count != 0)
                {
                    _file1 = Request.Files[0];
                    if (!_file1.ContentType.Contains("image/jpeg"))
                    {
                        return new HttpStatusCodeResult(502);
                    }
                    var number = new Random();
                    fileImagename = number.Next(1, 999999999).ToString() + _file1.FileName;
                    var path = Path.Combine(Server.MapPath("~/Image/CustomerImage"), fileImagename);
                    _file1.SaveAs(path);
                    _mcustomer.userimage = fileImagename;


                }

                db.Customer.Add(_mcustomer);
                await db.SaveChangesAsync();
                return Json("Ok", JsonRequestBehavior.AllowGet);
            }
            else
            {
                long cusid = 0;
                cusid = Convert.ToInt64(CreatHash.Decrypt(Request.Cookies["customerId"].Value));
                Customer _edmcustomer = db.Customer.Find(cusid);
                if (_mcustomer.Address == "" || _mcustomer.Address == null
                    || _mcustomer.Mobile == "" || _mcustomer.Mobile == null
                    || _mcustomer.Tel == "" || _mcustomer.Tel == null)
                {
                    return new HttpStatusCodeResult(505);
                }
                bool uniquemail = db.Customer.Where(p => p.Email == _mcustomer.Email && p.Id != _edmcustomer.Id).Any();
                bool uniquusername = db.Customer.Where(p => p.UserName == _mcustomer.UserName && p.Id != _edmcustomer.Id).Any();

                if (uniquemail == true || uniquusername == true)
                {
                    return new HttpStatusCodeResult(503);
                }
                _edmcustomer.Address = _mcustomer.Address;
                _edmcustomer.CompanyName = _mcustomer.CompanyName;
                _edmcustomer.DateUpdate = DateTime.Now;
                _edmcustomer.Email = _mcustomer.Email;
                _edmcustomer.FullName = _mcustomer.FullName;
                _edmcustomer.Mobile = _mcustomer.Mobile;

                _edmcustomer.Statedelete = false;
                _edmcustomer.Tel = _mcustomer.Tel;
                _edmcustomer.UserName = _mcustomer.UserName;

                if (Request.Files != null && Request.Files.Count != 0)
                {
                    _file1 = Request.Files[0];
                    if (!_file1.ContentType.Contains("image/jpeg"))
                    {
                        return new HttpStatusCodeResult(502);
                    }

                    if (_edmcustomer.userimage != null && _edmcustomer.userimage != "")
                    {
                        var oldimg = Path.Combine(Server.MapPath("~/Image/CustomerImage"), _edmcustomer.userimage);
                        if (System.IO.File.Exists(oldimg))
                        {
                            System.IO.File.Delete(oldimg);
                        }


                    }
                    var number = new Random();
                    fileImagename = number.Next(1, 999999999).ToString() + _file1.FileName;
                    var path = Path.Combine(Server.MapPath("~/Image/CustomerImage"), fileImagename);
                    _file1.SaveAs(path);
                    _edmcustomer.userimage = fileImagename;
                }

                await db.SaveChangesAsync();
                return Json("Ok", JsonRequestBehavior.AllowGet);


            }
        }


        [HttpPost]
        public async Task<ActionResult> changecuspass(Customer _mcustomer)
        {

            long cusid = 0;
            cusid = Convert.ToInt64(CreatHash.Decrypt(Request.Cookies["customerId"].Value));
            Customer _edmcustomer = db.Customer.Find(cusid);

            var pass = CreatHash.HashPass(_mcustomer.Password);
            _edmcustomer.Password = pass;


            await db.SaveChangesAsync();
            return Json("ok", JsonRequestBehavior.AllowGet);


        }
    }
}