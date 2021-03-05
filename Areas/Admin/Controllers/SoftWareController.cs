using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Areas.Admin.Controllers
{
    public class SoftWareController : Controller
    {
        // GET: Admin/SoftWare
        Web_companyEntities db = new Web_companyEntities();
        public ActionResult Index()
        {
            var list_software = db.SoftWare_Case.ToList();
            ViewData["list_software"] = list_software;
            return View();
        }
        public JsonResult Save_SoftWare(SoftWare_Case[] soft)
        {
            var value = 0;
            try
            {
                if (soft[0].Id > 0)
                {
                    var update = db.SoftWare_Case.Find(soft[0].Id);
                    update.Sw_author = soft[0].Sw_author;
                    update.Sw_desc = soft[0].Sw_desc;
                    update.Sw_image = soft[0].Sw_image;
                    update.Sw_link = soft[0].Sw_link;
                    update.Sw_name = soft[0].Sw_name;
                    update.Sw_note = soft[0].Sw_note;
                    update.Sw_title = soft[0].Sw_title;
                    db.SaveChanges();
                    value = soft[0].Id;
                }
                else
                {
                    var softnew = new SoftWare_Case();
                    var layid = (from SLi in db.SoftWare_Case
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
                    softnew.Sw_author = soft[0].Sw_author;
                    softnew.Sw_desc = soft[0].Sw_desc;
                    softnew.Sw_image = soft[0].Sw_image;
                    softnew.Sw_link = soft[0].Sw_link;
                    softnew.Sw_name = soft[0].Sw_name;
                    softnew.Sw_note = soft[0].Sw_note;
                    softnew.Sw_title = soft[0].Sw_title;
                    softnew.Sw_Status = true;
                    db.SoftWare_Case.Add(softnew);
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
            var value = false;
            try
            {
                var update = db.SoftWare_Case.Find(Id_User);
                update.Sw_Status = !update.Sw_Status;
                db.SaveChanges();
                value = (Boolean)update.Sw_Status;
            }
            catch
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteSoftWare(int Id_User)
        {
            var value = false;
            try
            {
                var layid = db.SoftWare_Case.Find(Id_User);
                db.SoftWare_Case.Remove(layid);
                db.SaveChanges();
                value = true;
            }
            catch (Exception)
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Edit_SoftWare(int Id_User)
        {
            return Json(db.SoftWare_Case.Find(Id_User), JsonRequestBehavior.AllowGet);
        }

    }
}