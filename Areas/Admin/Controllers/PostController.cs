using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        // GET: Admin/Post
        Web_companyEntities db = new Web_companyEntities();
        public ActionResult Index()
        {
            ViewData["list_danhmuc"] = db.Brand.Where(x => x.status == true).ToList();
            ViewData["list_post"] = db.Post.ToList();
            return View();
        }
        public JsonResult Save_Post(Post [] post)
        {
            var value = 0;
            try
            {
                if (post[0].Id > 0)
                {
                    var update = db.Post.Find(post[0].Id);
                    update.Author = post[0].Author;
                    update.Details = post[0].Details;
                    update.Image = post[0].Image;
                    update.Name = post[0].Name;
                    update.Title = post[0].Title;
                    update.Id_brand = post[0].Id_brand;
                    db.SaveChanges();
                    value = post[0].Id;
                }
                else
                {
                    var postnew = new Post();
                    var layid = (from SLi in db.Post
                                 where SLi.Id > 0
                                 orderby SLi.Id descending
                                 select new
                                 {
                                     id_soft = SLi.Id
                                 }).Take(1).ToArray();

                    if (layid.Any())
                    {
                        postnew.Id = layid[0].id_soft + 1;
                    }
                    else
                    {
                        postnew.Id = 1;
                    }
                    postnew.Author = post[0].Author;
                    postnew.Details = post[0].Details;
                    postnew.Image = post[0].Image;
                    postnew.Name = post[0].Name;
                    postnew.Title = post[0].Title;
                    postnew.Id_brand = post[0].Id_brand;
                    postnew.Common_Pb = false;
                    postnew.Prominence_Nb = false;
                    postnew.Type_post = false;
                    postnew.Status = true;
                    postnew.Time_up_post = DateTime.Now;
                    db.Post.Add(postnew);
                    db.SaveChanges();
                    value = postnew.Id;
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
                var update = db.Post.Find(Id_User);
                update.Status = !update.Status;
                db.SaveChanges();
                value = (Boolean)update.Status;
            }
            catch
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Save_Common(int Id_User)
        {
            var value = false;
            try
            {
                var update = db.Post.Find(Id_User);
                update.Common_Pb = !update.Common_Pb;
                db.SaveChanges();
                value = (Boolean)update.Common_Pb;
            }
            catch
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Save_Prominence(int Id_User)
        {
            var value = false;
            try
            {
                var update = db.Post.Find(Id_User);
                update.Prominence_Nb = !update.Prominence_Nb;
                db.SaveChanges();
                value = (Boolean)update.Prominence_Nb;
            }
            catch
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Save_Type_post(int Id_User)
        {
            var value = false;
            try
            {
                var update = db.Post.Find(Id_User);
                update.Type_post = !update.Type_post;
                db.SaveChanges();
                value = (Boolean)update.Type_post;
            }
            catch
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeletePost(int Id_User)
        {
            var value = false;
            try
            {
                var layid = db.Post.Find(Id_User);
                db.Post.Remove(layid);
                db.SaveChanges();
                value = true;
            }
            catch (Exception)
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Edit_Post(int Id_User)
        {
            return Json(db.Post.Find(Id_User), JsonRequestBehavior.AllowGet);
        }


    }
}