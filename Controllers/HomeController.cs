using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.DAO;
using Web_congty.Modal.FW;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc;
using Web_congty.Modal.FW.View_model;

namespace Web_congty.Controllers
{
    public class HomeController : Controller
    {
        Web_companyEntities db = new Web_companyEntities();
        public ActionResult Index()
        {
            var list_slides = db.Sliders.Where(x => x.S_active == true).ToList();
            ViewData["list_slides"] = list_slides;
            var list_intro = db.Introductions.Where(x => x.Intro_status == true).Take(1).ToList();
            ViewData["list_intro"] = list_intro;

            var list_softw = db.SoftWare_Case.Where(x => x.Sw_Status == true).ToList();
            ViewData["list_softw"] = list_softw;

            var list_service_maketting = db.Services.Where(x => x.Services_maketting == true).ToList();
            ViewData["list_service_maketting"] = list_service_maketting;

            var list_service = db.Services.Where(x => x.Services_status == true).ToList();
            ViewData["list_service"] = list_service;

            var list_fechback = db.FechBack_Cus.Where(x => x.F_Status == 1).ToList();
            ViewData["list_fechback"] = list_fechback;

            var list_post_pb = db.Posts.Where(x => x.Status == true && x.Common_Pb == true).OrderByDescending(x => x.Id).ToList();
            ViewBag.baivietphobien = list_post_pb;



            return View();
        }
        public JsonResult GetData_Information_Register()
        {
            var information = db.Information_company.ToList();

            return Json(information, JsonRequestBehavior.AllowGet);
        }
        [ChildActionOnly]
        public ActionResult Top_Header()
        {
            return PartialView();
        }
        [ChildActionOnly]//chi duoc nhung , khong duoc goi.
        public ActionResult Footer()
        {
            ViewBag.danhmuccha = db.f__Count_post().ToList();
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult Partner()
        {
            var list_partner = db.Partner_DT.Where(x => x.Status == 1).ToList();
            ViewData["list_partner"] = list_partner;
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult Header()
        {
            var list_danhmucmenu = db.Categories.Where(x => x.C_status == true).ToList();
            ViewData["list_danhmucmenu"] = list_danhmucmenu;
            var list_con = db.Brands.Where(x => x.status == true).ToList();
            ViewData["list_con"] = list_con;
            // get data history chang website
            List<list_news_comment_website> list_change_web = new List<list_news_comment_website>();
            var list_comment_blog = db.Binhluan_blog().Where(x => x.Status == true).OrderByDescending(x => x.Time).Take(2).ToList();
            var list_comment_software = db.Binhlan_phanmem().Where(x => x.Status == true).OrderByDescending(x => x.Time).Take(2).ToList();
            var list_register_software = db.tbl_Register_Software_Client.OrderByDescending(x => x.Time_register).Take(2).ToList();
            if (list_comment_blog.Count > 0 || list_comment_software.Count > 0)
            {
                foreach (var item_commemnt_blog_ in list_comment_blog)
                {
                    var list_change_web_show__ = new list_news_comment_website();
                    list_change_web_show__.id_custommer = item_commemnt_blog_.Id_uer;
                    var name_user = db.tbl_Uers.Find(list_change_web_show__.id_custommer);
                    list_change_web_show__.Name_custommer = name_user.name;
                    list_change_web_show__.id_post = item_commemnt_blog_.Id_post;
                    var post = db.Posts.Find(list_change_web_show__.id_post);
                    list_change_web_show__.Name_post_news = post.Name;// lấy tên bài viết
                    var timechange = (DateTime)item_commemnt_blog_.Time;
                    DateTime The_present_time = DateTime.Now;
                    TimeSpan Time = The_present_time - timechange;
                    int TongSoNgay = Time.Days;
                    int TongSoGio = Time.Hours;
                    int TongSoPhut = Time.Minutes;
                    var stringtime = TongSoNgay + "|" + TongSoGio + "|" + TongSoPhut;
                    list_change_web_show__.Time_change = stringtime;
                    list_change_web.Add(list_change_web_show__);
                }
                foreach (var item_commemnt_software_ in list_comment_software)
                {
                    var list_change_web_show__ = new list_news_comment_website();
                    list_change_web_show__.id_custommer = item_commemnt_software_.Id_uer;
                    var name_user = db.tbl_Uers.Find(list_change_web_show__.id_custommer);
                    list_change_web_show__.Name_custommer = name_user.name;
                    list_change_web_show__.id_software = item_commemnt_software_.Id_software;
                    var software = db.SoftWare_Case.Find(list_change_web_show__.id_software);
                    list_change_web_show__.Name_software = software.Sw_name;// lấy tên phần mềm
                    var timechange = (DateTime)item_commemnt_software_.Time;
                    DateTime The_present_time = DateTime.Now;
                    TimeSpan Time = The_present_time - timechange;
                    int TongSoNgay = Time.Days;
                    int TongSoGio = Time.Hours;
                    int TongSoPhut = Time.Minutes;
                    var stringtime = TongSoNgay + "|" + TongSoGio + "|" + TongSoPhut;
                    list_change_web_show__.Time_change = stringtime;
                    list_change_web.Add(list_change_web_show__);
                }
                foreach (var item_register_software_ in list_register_software)
                {
                    var list_change_web_show__ = new list_news_comment_website();
                    list_change_web_show__.id_register_software = item_register_software_.Id_Sw;
                    var software_register = db.SoftWare_Case.Find(list_change_web_show__.id_register_software);
                    list_change_web_show__.Name_register_software = software_register.Sw_name;
                    list_change_web_show__.Name_custommer = item_register_software_.Name_Client;
                    list_change_web_show__.id_custommer = 0;
                    var timechange = (DateTime)item_register_software_.Time_register;
                    DateTime The_present_time = DateTime.Now;
                    TimeSpan Time = The_present_time - timechange;
                    int TongSoNgay = Time.Days;
                    int TongSoGio = Time.Hours;
                    int TongSoPhut = Time.Minutes;
                    var stringtime = TongSoNgay + "|" + TongSoGio + "|" + TongSoPhut;
                    list_change_web_show__.Time_change = stringtime;
                    list_change_web.Add(list_change_web_show__);
                }
                ViewData["list_web_show__"] = list_change_web;
            }
            else
            {
                ViewBag.thongbao = "Data null";
            }
            return PartialView();
        }

        public JsonResult Question_CLient(string question, string email)
        {
            var value = false;
            try
            {
                var Question_client_now = new tbl_Question_client();
                Question_client_now.Conten_question = question;
                Question_client_now.Email_question = email;
                Question_client_now.Status = 1;
                Question_client_now.Time_question = DateTime.Now;
                db.tbl_Question_client.Add(Question_client_now);
                db.SaveChanges();
                value = true;
            }
            catch
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Register_revice_news_client(string email)
        {
            var value = false;
            try
            {
                if (db.tbl_KH_Register_Receive_News.Where(x=>x.Email_KH == email).Any())
                {
                    var thongbao = "Email" + " " + email + " " + "đã đăng ký nhận tin";
                    var data = new { thongbao = thongbao };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                var Email_register__ = new tbl_KH_Register_Receive_News();
                Email_register__.Email_KH = email;
                Email_register__.Time_KH = DateTime.Now;
                db.tbl_KH_Register_Receive_News.Add(Email_register__);
                db.SaveChanges();
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