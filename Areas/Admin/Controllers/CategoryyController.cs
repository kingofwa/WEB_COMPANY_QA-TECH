using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Areas.Admin.Controllers
{
    public class CategoryyController : Controller
    {
        // GET: Admin/Categoryy
        Web_companyEntities db = new Web_companyEntities();
        public ActionResult Index()
        {
            ViewData["list_categoryy"] = db.Brand.ToList(); 
            ViewData["list_cate"] = db.Categories.ToList();
            return View();
        }

        public JsonResult Save_Categoryy(Brand[] categoryy)
        {
            var value = 0;
            try
            {
                if (categoryy[0].Id > 0)
                {
                    var update = db.Brand.Find(categoryy[0].Id);
                    update.id_categories = categoryy[0].id_categories;
                    update.Name = categoryy[0].Name;
                    db.SaveChanges();
                    value = categoryy[0].Id;
                }
                else
                {
                    var categorynew = new Brand();
                    var layid = (from SLi in db.Brand
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
                    categorynew.id_categories = categoryy[0].id_categories;
                    categorynew.Name = categoryy[0].Name;
                    categorynew.status = true;
                    db.Brand.Add(categorynew);
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
                var update = db.Brand.Find(Id_User);
                update.status = !update.status;
                db.SaveChanges();
                value = (Boolean)update.status;
            }
            catch
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteCategoryy(int Id_User)
        {
            var value = false;
            try
            {
                var layid = db.Brand.Find(Id_User);
                db.Brand.Remove(layid);
                db.SaveChanges();
                value = true;
            }
            catch (Exception)
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Edit_Categoryy(int Id_User)
        {
            return Json(db.Brand.Find(Id_User), JsonRequestBehavior.AllowGet);
        }
    }
}