using HiperStar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HiperStar.Controllers
{
    public class RolesController : Controller
    {
        FsetMvcEntities db = new FsetMvcEntities();

        public ActionResult Index()
        {
            List<ComponyRule> ComponyRule = db.ComponyRule.ToList();
            return View(ComponyRule);
        }
    }
}