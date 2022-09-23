using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Controllers
{
    public class SoftWareHomeController : Controller
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: SoftWare
        public ActionResult Index()
        {
            var list_softw = db.SoftWare_Case.Where(x => x.Sw_Status == true).ToList();
            ViewData["list_softw"] = list_softw;
            


            return View();
        }
    }
}