using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        Web_companyEntities db = new Web_companyEntities();
        public ActionResult Index()
        {
            ViewData["list_category"] = db.Categories.ToList();
            return View();
        }

        public JsonResult Save_Category(Categories[] category)
        {
            var value = 0;
            try
            {
                if (category[0].Id > 0)
                {
                    var update = db.Categories.Find(category[0].Id);
                    update.C_name = category[0].C_name;
                    update.C_note = category[0].C_note;
                    db.SaveChanges();
                    value = category[0].Id;
                }
                else
                {
                    var categorynew = new Categories();
                    var layid = (from SLi in db.Categories
                                 where SLi.Id > 0
                                 orderby SLi.Id descending
                                 select new
                                 {
                                     id_ = SLi.Id
                                 }).Take(1).ToArray();

                    if (layid.Any())
                    {
                        categorynew.Id = layid[0].id_ + 1;
                    }
                    else
                    {
                        categorynew.Id = 1;
                    }
                    categorynew.C_name = category[0].C_name;
                    categorynew.C_note = category[0].C_note;
                    categorynew.C_status = true;
                    db.Categories.Add(categorynew);
                    db.SaveChanges();
                    value = categorynew.Id;
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
                var update = db.Categories.Find(Id_User);
                update.C_status = !update.C_status;
                db.SaveChanges();
                value = (Boolean)update.C_status;
            }
            catch
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteCategory(int Id_User)
        {
            var value = false;
            try
            {
                var layid = db.Categories.Find(Id_User);
                db.Categories.Remove(layid);
                db.SaveChanges();
                value = true;
            }
            catch (Exception)
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Edit_Category(int Id_User)
        {
            return Json(db.Categories.Find(Id_User), JsonRequestBehavior.AllowGet);
        }
    }
}