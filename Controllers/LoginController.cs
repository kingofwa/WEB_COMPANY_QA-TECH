using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.DAO;
using Web_congty.Modal.FW;

namespace Web_congty.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Web_companyEntities db = new Web_companyEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Dangnhap(FormCollection l)
        {
            string sTaikhoan = l["textTendangnhap"].ToString();
            string sMatkhau = new CustommerDAO().MD5Hash(l["matkhau"].ToString());
            var dangnhap = db.tbl_Uers.Where(x => x.password == sMatkhau && x.email == sTaikhoan && x.Run_status == 0).ToList();
            if (dangnhap.Count() != 0)
            {
                return Content("Tài khoản tạm thời bị khóa !");
            }
            else
            {
                tbl_Uers tv = db.tbl_Uers.SingleOrDefault(x => x.email == sTaikhoan && x.password == sMatkhau);
                if (tv != null)
                {
                    Session["Taikhoan"] = tv;
                    return Content("<script>window.location.reload();</script>");
                }
                return Content("Tên đăng nhập hoặc mật khẩu không đúng");
            }
        }
        public ActionResult Dangxuat()
        {
            Session["Taikhoan"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}