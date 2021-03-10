using CaptchaMvc.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.DAO;
using Web_congty.Modal.FW;

namespace Web_congty.Controllers
{
    public class RegisterController : Controller
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Dangky()
        {
            ViewBag.question = new SelectList(Loadding_cauhoi());

            return View();
        }
        [HttpPost]
        public ActionResult Dangky(tbl_Uers tv, FormCollection f)
        {
            ViewBag.question = new SelectList(Loadding_cauhoi());
            //kiểm tra capcha hợp lệ 
            //var pass = new CustommerDAO().MD5Hash(tv.password);
            if (db.tbl_Uers.Where(x => x.email == tv.email).Any())
            {
                ViewBag.thongbao = "Tài khoản email đã tồn tại";
                return View();
            }
            if (this.IsCaptchaValid("Mã capcha không đúng"))
            {
                if (ModelState.IsValid)
                {
                    ViewBag.thongbao = "Đăng ký thành công";
                    //thêm uers vào db 
                    tv.Day = DateTime.Now;
                    tv.type_uer = 1;
                    tv.public_private = 1;
                    tv.Run_status = 1;
                    tv.password = new CustommerDAO().MD5Hash(tv.password);
                    db.tbl_Uers.Add(tv);
                    db.SaveChanges();
                    return View();
                }
                else
                {
                    ViewBag.thongbao = "Đăng ký thất bại";
                }
            }
            ViewBag.thongbao = "Sai mã capcha";
            return View();
        }
        public List<string> Loadding_cauhoi()
        {
            List<string> Listcauhoi = new List<string>();
            Listcauhoi.Add("Người yêu của bạn tên gì ?");
            Listcauhoi.Add("Công việc của bạn là gì ?");
            Listcauhoi.Add("Ca sĩ mà bạn yêu thích nhất ?");
            Listcauhoi.Add("Con vật mà bạn yêu thích nhất ?");
            return Listcauhoi;
        }
    }
}