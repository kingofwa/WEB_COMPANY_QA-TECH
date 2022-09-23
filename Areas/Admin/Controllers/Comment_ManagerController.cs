using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Areas.Admin.Controllers
{
    public class Comment_ManagerController : Controller
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: Admin/Comment_Manager
        public ActionResult Index()
        {
            var quanli_list_comment_phanmem = db.Binhlan_phanmem().OrderByDescending(x => x.Id).ToList();
            ViewData["quanli_list_comment_phanmem"] = quanli_list_comment_phanmem;
            var quanli_list_comment_baiviet = db.Binhluan_blog().OrderByDescending(x => x.Id).ToList();
            ViewData["quanli_list_comment_baiviet"] = quanli_list_comment_baiviet;
            return View();
        }
    }
}