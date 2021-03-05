using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;
using Web_congty.Modal.FW.View_model;

namespace Web_congty.Controllers
{
    public class SystemController : Controller
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: System
        public ActionResult Index()
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                ViewBag.moidangnhap = "Xin mời đăng nhập";
            }
            else
            {
                var taikhoan = (tbl_Uers)Session["Taikhoan"];
                if (taikhoan.type_uer == 0)
                {
                    ViewData["list_system_project"] = db.Project_system.OrderByDescending(x => x.Id).ToList();
                }
                else
                {
                    ViewBag.thongbao = "Chỉ dành cho nhân viên kỹ thuật Công ty";
                }
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var view_details_system_project = db.Project_system.Where(x => x.Id == id).ToList();
            ViewBag.details = view_details_system_project;
            ViewBag.Title = view_details_system_project[0].Ten_DuAn;
            var hinhanh = view_details_system_project[0].Hinhanhchitiet;//show image details 
            if(hinhanh != null)
            {
                var list_hinhanh = hinhanh.Split('|');
                ViewBag.listhinhanh = list_hinhanh;
            }
            else
            {
                ViewBag.messenger = "DỰ ÁN CHƯA ĐƯỢC CUNG CẤP HÌNH ẢNH";
            }
            List<ProjectNextOrLast> list_project = new List<ProjectNextOrLast>();//get list project new obj db.Project_system
            foreach(var item  in view_details_system_project)
            {
                var project = new ProjectNextOrLast();
                project.Id_first = item.Id - 1;
                project.Id_last = item.Id + 1;
                var __image_f = db.Project_system.Find(project.Id_first);
                if(__image_f != null)
                {
                    project.Image_first = __image_f.Hinhanhmota;
                    project.Name_news_first = __image_f.Ten_DuAn;
                }
                var __image_l = db.Project_system.Find(project.Id_last);
                if (__image_l != null)
                {
                    project.Image_last = __image_l.Hinhanhmota;
                    project.Name_news_last = __image_l.Ten_DuAn;
                }
                list_project.Add(project);
            }
            ViewData["list_project"] = list_project;
            var list_project_sidebar = db.Project_system.Where(x => x.TheLoai_DuAn == 2).ToList();//get data list project Most
            ViewData["list_project_sidebar"] = list_project_sidebar;

            return View();
        }


    }
}