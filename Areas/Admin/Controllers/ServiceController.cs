using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Admin/Service
        Web_companyEntities db = new Web_companyEntities();
        public ActionResult Index()
        {
            var list_service = db.Services.ToList();
            ViewData["list_service"] = list_service;
            return View();
        }
        public JsonResult Save_Service(Services[] service)
        {
            var value = 0;
            try
            {
                if (service[0].Id > 0)
                {
                    var update = db.Services.Find(service[0].Id);
                    update.Services_desc = service[0].Services_desc;
                    update.Services_image = service[0].Services_image;
                    update.Services_link = service[0].Services_link;
                    update.Services_name = service[0].Services_name;
                    update.Services_note = service[0].Services_note;
                    update.Services_title = service[0].Services_title;
                    db.SaveChanges();
                    value = service[0].Id;
                }
                else
                {
                    var servicenew = new Services();
                    var layid = (from SLi in db.Services
                                 where SLi.Id > 0
                                 orderby SLi.Id descending
                                 select new
                                 {
                                     id_ = SLi.Id
                                 }).Take(1).ToArray();

                    if (layid.Any())
                    {
                        servicenew.Id = layid[0].id_ + 1;
                    }
                    else
                    {
                        servicenew.Id = 1;
                    }
                    servicenew.Services_desc = service[0].Services_desc;
                    servicenew.Services_image = service[0].Services_image;
                    servicenew.Services_link = service[0].Services_link;
                    servicenew.Services_name = service[0].Services_name;
                    servicenew.Services_note = service[0].Services_note;
                    servicenew.Services_title = service[0].Services_title;
                    servicenew.Services_status = true;
                    servicenew.Services_maketting = true;
                    db.Services.Add(servicenew);
                    db.SaveChanges();
                    value = servicenew.Id;
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
                var update = db.Services.Find(Id_User);
                update.Services_status = !update.Services_status;
                db.SaveChanges();
                value = (Boolean)update.Services_status;
            }
            catch
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Save_Maketting(int Id_User)
        {
            var value = false;
            try
            {
                var update = db.Services.Find(Id_User);
                update.Services_maketting = !update.Services_maketting;
                db.SaveChanges();
                value = (Boolean)update.Services_maketting;
            }
            catch
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteService(int Id_User)
        {
            var value = false;
            try
            {
                var layid = db.Services.Find(Id_User);
                db.Services.Remove(layid);
                db.SaveChanges();
                value = true;
            }
            catch (Exception)
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Edit_Service(int Id_User)
        {
            return Json(db.Services.Find(Id_User), JsonRequestBehavior.AllowGet);
        }
    }
}