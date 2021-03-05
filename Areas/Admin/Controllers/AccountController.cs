using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.DAO;
using Web_congty.Modal.FW;

namespace Web_congty.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: Admin/Account
        [HttpGet]
        public ActionResult Index()
        {
            var list_user = db.tbl_Uers_Admin.ToList();
            ViewData["list_user"] = list_user;
            return View();
        }
        [HttpPost]
        public ActionResult Index(tbl_Uers_Admin admin, HttpPostedFileBase image)
        {
            ViewData["list_user"] = db.tbl_Uers_Admin.ToList();
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    string file_name = System.IO.Path.GetFileName(image.FileName);
                    string Url_image = Server.MapPath("~/Image/" + image);
                    image.SaveAs(Url_image);
                    admin.Image_user = "/Image/" + file_name;
                }
                admin.Status = true;
                admin.Password_user = new CustommerDAO().MD5Hash(admin.Password_user);
                db.tbl_Uers_Admin.Add(admin);
                db.SaveChanges();
                ViewBag.thongbao = "Đăng ký thành công";

                return View();
            }
            else
            {
                ViewBag.thongbao = "Đăng ký thất bại";
            }

            return View();
        }
    }

}