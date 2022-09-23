using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Controllers
{
    public class Because_chooseController : Controller
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: Because_choose
        public ActionResult BecauChoose()
        {
            var visaochon = db.Introductions.Where(x => x.Intro_status == true).ToList();
            ViewData["visaochon"] = visaochon;

            return View();
        }
    }
}
