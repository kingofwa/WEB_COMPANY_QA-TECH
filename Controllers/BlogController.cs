using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Web_companyEntities db = new Web_companyEntities();
        public ActionResult Index(int pageNumber = 1,int pageSize = 5)
        {
            ViewBag.brand = db.Brands.Where(x => x.status == true).ToList();

            List<Post> products = db.Posts.Where(x => x.Status == true).OrderBy(x => x.Id).ToList();
            PagedList<Post> model = new PagedList<Post>(products, pageNumber, pageSize);

            return View(model);
        }

        public ActionResult Sidebar()
        {
            var list_data_news_all_brand = db.f__Count_post().ToList();
            ViewData["list_data_news_all_brand"] = list_data_news_all_brand;

            var list_data_news_all = db.Posts.Where(x => x.Status == true && x.Prominence_Nb == true).ToList();
            ViewData["list_data_news_all"] = list_data_news_all;

            var list_data_danhmuccha_all = db.Categories.Where(x => x.C_status == true).ToList();
            ViewData["list_data_danhmuccha_all"] = list_data_danhmuccha_all;

            return PartialView();
        }

    }
}