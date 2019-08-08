using HiperStar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HiperStar.Controllers
{
    public class ContactUsController : Controller
    {
        FsetMvcEntities db = new FsetMvcEntities();

        public ActionResult Index()
        {
            List<ContactUs> _ab = db.ContactUs.ToList();
            return View(_ab);
        }
        [HttpPost]
        public async Task<ActionResult> Suggestion(Suggestion _sug)
        {
            if (_sug.Id == 0)
            {
                _sug.dateinsert = DateTime.Now;
                _sug.statedelete = false;
                db.Suggestion.Add(_sug);
                await db.SaveChangesAsync();
                return Json("Ok", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Suggestion _edsug = db.Suggestion.Find(_sug.Id);
                _edsug.dateinsert = DateTime.Now;
                _edsug.statedelete = false;
                _edsug.Name = _sug.Name;
                _edsug.Email = _sug.Email;
                _edsug.Message = _sug.Message;
                _edsug.respondmessag = _sug.respondmessag;
                _edsug.Subject = _sug.Subject;
                _edsug.Tel = _sug.Tel;
                await db.SaveChangesAsync();
                return Json("Ok", JsonRequestBehavior.AllowGet);

            }
        }
    }
}