using HiperStar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HiperStar.Controllers
{
    public class AboutUsController : Controller
    {
        FsetMvcEntities db = new FsetMvcEntities();
        public ActionResult Index()
        {
            AboutUs _ab = db.AboutUs.FirstOrDefault();
            return View(_ab);
        }
    }
}