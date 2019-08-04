using HiperStar.Models;
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

        [HttpPost]
        public ActionResult Index()
        {
            return View();
        }

    }
}