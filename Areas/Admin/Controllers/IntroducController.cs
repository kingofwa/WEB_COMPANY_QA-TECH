using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Areas.Admin.Controllers
{
    public class IntroducController : BaseController
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: Admin/Introduc
        public ActionResult Index()
        {
            var list_introduction = db.Introduction.Where(x => x.Intro_status == true).ToList();
            ViewData["list_introduction"] = list_introduction;
            return View();
        }
        public JsonResult Save_Intro(Introduction[] intro)
        {
            var value = 0;
            try
            {
                if (intro[0].Id > 0)
                {
                    var update = db.Introduction.Find(intro[0].Id);
                    update.Intro_desc = intro[0].Intro_desc;
                    update.Intro_image = intro[0].Intro_image;
                    update.Intro_link = intro[0].Intro_link;
                    update.Intro_name = intro[0].Intro_name;
                    update.Intro_title = intro[0].Intro_title;
                    db.SaveChanges();
                    value = intro[0].Id;
                }
                else
                {
                    var intronew = new Introduction();
                    var layid = (from In in db.Introduction
                                 where In.Id > 0
                                 orderby In.Id descending
                                 select new
                                 {
                                     Id_Intro = In.Id
                                 }).Take(1).ToArray();

                    if (layid.Any())
                    {
                        intronew.Id = layid[0].Id_Intro + 1;
                    }
                    else
                    {
                        intronew.Id = 1;
                    }
                    intronew.Intro_desc = intro[0].Intro_desc;
                    intronew.Intro_image = intro[0].Intro_image;
                    intronew.Intro_link = intro[0].Intro_link;
                    intronew.Intro_name = intro[0].Intro_name;
                    intronew.Intro_title = intro[0].Intro_title;
                    intronew.Intro_status = true;
                    db.Introduction.Add(intronew);
                    db.SaveChanges();
                    value = intronew.Id;
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
                var update = db.Introduction.Find(Id_User);
                update.Intro_status = !update.Intro_status;
                db.SaveChanges();
                value = (Boolean)update.Intro_status;
            }
            catch
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Edit_Intro(int Id)
        {
            return Json(db.Introduction.Find(Id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteIntro(int Id)
        {
            var value = false;
            try
            {
                var layid = db.Introduction.Find(Id);
                db.Introduction.Remove(layid);
                db.SaveChanges();
                value = true;
            }
            catch (Exception)
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
    }
}