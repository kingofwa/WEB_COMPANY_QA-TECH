using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            var list_comment_phanmem= db.Binhlan_phanmem().OrderByDescending(x=>x.Id).ToList();
            ViewData["list_comment_phanmem"] = list_comment_phanmem;
            var list_comment_baiviet = db.Binhluan_blog().OrderByDescending(x => x.Id).ToList();
            ViewData["list_comment_baiviet"] = list_comment_baiviet;
            var list_taikhoankhachhang = db.tbl_Uers.OrderByDescending(x => x.Id).ToList();
            ViewData["list_taikhoankhachhang"] = list_taikhoankhachhang;
            var list_client_register = db.Client_register_now_software().OrderByDescending(x => x.Id).ToList();
            ViewData["list_client_register"] = list_client_register;


            return View();
        }

        //trạng thái khách hàng
        public JsonResult Save_Status_KhachHang(int id)
        {
            var update = db.tbl_Uers.Find(id);
            if (update.Run_status == 1)
            {
                update.Run_status = 0;
            }
            else
            {
                update.Run_status = 1;
            }
            db.SaveChanges();
            var value = update.Run_status;
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        //cấp độ tài khoản
        public JsonResult Save_Status_CapDo(int id)
        {
            var update = db.tbl_Uers.Find(id);
            if (update.type_uer == 1)
            {
                update.type_uer = 0;
            }
            else
            {
                update.type_uer = 1;
            }
            db.SaveChanges();
            var value = update.type_uer;
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PheDuyetBinhLuan(int id)
        {
            var value = false;
            try
            {
                var update = db.Comment.Find(id);
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
    }
}
