using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Areas.Admin.Controllers
{
    public class AdminHomeController : BaseController
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            var list_comment_phanmem = db.Binhlan_phanmem().Where(x=>x.Status == false).OrderByDescending(x => x.Id).ToList();
            ViewData["list_comment_phanmem"] = list_comment_phanmem;
            var list_comment_baiviet = db.Binhluan_blog().Where(x => x.Status == false).OrderByDescending(x => x.Id).ToList();
            ViewData["list_comment_baiviet"] = list_comment_baiviet;
            var list_taikhoankhachhang = db.tbl_Uers.OrderByDescending(x => x.Id).ToList();
            ViewData["list_taikhoankhachhang"] = list_taikhoankhachhang;
            var list_client_register = db.Client_register_now_software().OrderByDescending(x => x.Id).ToList();
            ViewData["list_client_register"] = list_client_register;

            var list_question = db.tbl_Question_client.Where(x => x.Status == 1).ToList();
            ViewData["list_question"] = list_question;
            ViewBag.danhsach_cauhoicuakhachhang = list_question.Count();
            ViewBag.danhsach_comment_phanmem = list_comment_phanmem.Where(x=>x.Status == false).Count();
            ViewBag.danhsach_comment_baiviet = list_comment_baiviet.Where(x => x.Status == false).Count();
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
                var update = db.Comments.Find(id);
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
        public JsonResult PheDuyetBinhLuan_Blog(int id)
        {
            var value = false;
            try
            {
                var update = db.Comments.Find(id);
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



        //gửi mail câu trả lời
        public JsonResult Send_Mail_Custummer(int id, string emailhoi, string cauhoi, string cautraloi)
        {
            var value = false;
            try
            {
                var list_question = db.tbl_Question_client.Find(id);
                list_question.Status = 2;
                db.SaveChanges();
                // gửi mail trả lời câu hỏi
                string content = System.IO.File.ReadAllText(Server.MapPath("~/tempalate/traloikhachhang.html"));
                content = content.Replace("{{email_datcauhoi}}", emailhoi);
                content = content.Replace("{{cauhoi}}", cauhoi);
                content = content.Replace("{{thoigianhoi}}", list_question.Time_question.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"));
                content = content.Replace("{{cautraloi}}", cautraloi);
                //var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();// gửi đến admin 
                new MailHelper().SendMail(emailhoi, "Tin mới từ QUOCANH-TECH", content);
                //new MailHelper().SendMail(toEmail, "Tin mới từ QUOCANH-TECH", content);// gửi đến admin 
                value = true;
            }
            catch
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

    }
}
