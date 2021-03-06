using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.DAO;
using Web_congty.Modal.FW;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc;

namespace Web_congty.Controllers
{
    public class HomeController : Controller
    {
        Web_companyEntities db = new Web_companyEntities();
        public ActionResult Index()
        {
            var list_slides = db.Slider.Where(x => x.S_active == true).ToList();
            ViewData["list_slides"] = list_slides;
            var list_intro = db.Introduction.Where(x => x.Intro_status == true).Take(1).ToList();
            ViewData["list_intro"] = list_intro;

            var list_softw = db.SoftWare_Case.Where(x => x.Sw_Status == true).ToList();
            ViewData["list_softw"] = list_softw;

            var list_service_maketting = db.Services.Where(x => x.Services_maketting == true).ToList();
            ViewData["list_service_maketting"] = list_service_maketting;

            var list_service = db.Services.Where(x => x.Services_status == true).ToList();
            ViewData["list_service"] = list_service; 

             var list_fechback = db.FechBack_Cus.Where(x => x.F_Status == 1).ToList();
            ViewData["list_fechback"] = list_fechback;

            var list_post_pb = db.Post.Where(x => x.Status == true && x.Common_Pb == true).OrderByDescending(x => x.Id).ToList();
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
            var list_con = db.Brand.Where(x => x.status == true).ToList();
            ViewData["list_con"] = list_con;
            return PartialView();
       }

        public JsonResult Question_CLient(string question,string email)
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
    }
}