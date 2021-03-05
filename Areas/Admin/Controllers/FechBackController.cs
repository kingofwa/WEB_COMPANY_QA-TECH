using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Areas.Admin.Controllers
{
    public class FechBackController : Controller
    {
        // GET: Admin/FechBack
        Web_companyEntities db = new Web_companyEntities();
        public ActionResult Index()
        {
            var list_fechback = db.FechBack_Cus.ToList();
            ViewData["list_fechback"] = list_fechback;
            return View();
        }

        public JsonResult Save_FechBack(FechBack_Cus[] soft)
        {
            var value = 0;
            try
            {
                if (soft[0].Id > 0)
                {
                    var update = db.FechBack_Cus.Find(soft[0].Id);
                    update.F_content = soft[0].F_content;
                    update.F_email = soft[0].F_email;
                    update.F_image = soft[0].F_image;
                    update.F_name = soft[0].F_name;
                    db.SaveChanges();
                    value = soft[0].Id;
                }
                else
                {
                    var softnew = new FechBack_Cus();
                    var layid = (from SLi in db.FechBack_Cus
                                 where SLi.Id > 0
                                 orderby SLi.Id descending
                                 select new
                                 {
                                     id_soft = SLi.Id
                                 }).Take(1).ToArray();

                    if (layid.Any())
                    {
                        softnew.Id = layid[0].id_soft + 1;
                    }
                    else
                    {
                        softnew.Id = 1;
                    }
                    softnew.F_content = soft[0].F_content;
                    softnew.F_email = soft[0].F_email;
                    softnew.F_image = soft[0].F_image;
                    softnew.F_name = soft[0].F_name;
                    softnew.F_Status = 1;
                    db.FechBack_Cus.Add(softnew);
                    db.SaveChanges();
                    value = softnew.Id;
                }
            }
            catch (Exception)
            {
                value = 0;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save_Status(int Id_User)
        {
            var update = db.FechBack_Cus.Find(Id_User);
            if (update.F_Status == 1)
            {
                update.F_Status = 0;
            }
            else
            {
                update.F_Status = 1;
            }
            db.SaveChanges();
            var value = update.F_Status;
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteFechBack(int Id_User)
        {
            var value = false;
            try
            {
                var layid = db.FechBack_Cus.Find(Id_User);
                db.FechBack_Cus.Remove(layid);
                db.SaveChanges();
                value = true;
            }
            catch (Exception)
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Edit_FechBack(int Id_User)
        {
            return Json(db.FechBack_Cus.Find(Id_User), JsonRequestBehavior.AllowGet);
        }
    }
}