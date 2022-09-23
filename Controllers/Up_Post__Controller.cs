using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Controllers
{
    public class Up_Post__Controller : Controller
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: Up_Post__
        public ActionResult Up_Post__()
        {
            ViewData["list_danhmuc"] = db.Brands.Where(c => c.status == true).ToList();
            return View();
        }

        [HttpPost , ValidateInput(false)]
        public ActionResult Up_Post__(Post_user post)// , HttpPostedFileBase image
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("Dangky", "Register");
            }
            ViewData["list_danhmuc"] = db.Brands.Where(c => c.status == true).ToList();
            
            var a = (tbl_Uers)Session["Taikhoan"];
            ViewBag.user = a.Id;
            if(a != null)
            {
                //if (image != null)
                //{
                //    string file_name = System.IO.Path.GetFileName(image.FileName);
                //    string Url_image = Server.MapPath("~/Image/"+image);
                //    image.SaveAs(Url_image);
                //    post.Image = "/Image/"+file_name;
                //}
                if (ModelState.IsValid)
                {
                    post.Time_up = DateTime.Now;
                    post.Type_post = true;
                    post.Status = false;
                    post.Id_uer = a.Id;
                    post.Common = false;
                    db.Post_user.Add(post);
                    
                    db.SaveChanges();
                    ViewBag.thongbao = "Đăng bài viết thành công";
                    return View();
                }
                else
                {
                    ViewBag.thongbao = "Đăng ký thất bại";
                }
            }
            else
            {
                ViewBag.thongbao = "Vui lòng đăng nhập !";
            }
            return View();
        }
    }
}