using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Areas.Admin.Views.AdminHome
{
    public class SlideController : Controller
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: Admin/Slide
        public ActionResult Index()
        {
            var list_slider = db.Slider.Where(x => x.S_active == true).ToList();
            ViewData["list_slider"] = list_slider;
            return View();
        }
        public JsonResult Save_Slide(Slider[] slide)
        {
            var value = 0;
            try
            {
                if (slide[0].Id > 0)
                {
                    var update = db.Slider.Find(slide[0].Id);
                    update.S_description = slide[0].S_description;
                    update.S_image = slide[0].S_image;
                    update.S_link = slide[0].S_link;
                    update.S_name = slide[0].S_name;
                    db.SaveChanges();
                    value = slide[0].Id;
                }
                else
                {
                    var slidenew = new Slider();
                    var layid = (from SLi in db.Slider
                                 where SLi.Id > 0
                                 orderby SLi.Id descending
                                 select new
                                 {
                                     Id_slide = SLi.Id
                                 }).Take(1).ToArray();

                    if (layid.Any())
                    {
                        slidenew.Id = layid[0].Id_slide + 1;
                    }
                    else
                    {
                        slidenew.Id = 1;
                    }
                    slidenew.S_name = slide[0].S_name;
                    slidenew.S_link = slide[0].S_link;
                    slidenew.S_image = slide[0].S_image;
                    slidenew.S_description = slide[0].S_description;
                    slidenew.S_active = true;
                    db.Slider.Add(slidenew);
                    db.SaveChanges();
                    value = slidenew.Id;
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
                var update = db.Slider.Find(Id_User);
                update.S_active = !update.S_active;
                db.SaveChanges();
                value = (Boolean)update.S_active;
            }
            catch
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteSlide(int Id_User)
        {
            var value = false;
            try
            {
                var layid = db.Slider.Find(Id_User);
                db.Slider.Remove(layid);
                db.SaveChanges();
                value = true;
            }
            catch (Exception)
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Edit_Slide(int Id_User)
        {
            return Json(db.Slider.Find(Id_User), JsonRequestBehavior.AllowGet);
        }
    }
}