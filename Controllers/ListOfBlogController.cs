using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Controllers
{
    public class ListOfBlogController : Controller
    {
        // GET: ListOfBlog
        Web_companyEntities db = new Web_companyEntities();
        public ActionResult Index(int id , int pageNumber = 1, int pageSize = 3)
        {
            var list_data_news = db.Post.Where(x => x.Status == true && x.Id_brand == id).OrderBy(x => x.Id).ToList();
            if (list_data_news.Any())
            {
                var id_cate_ = list_data_news[0].Id_brand;
                var danh_muc = db.Brand.Find(id_cate_);
                ViewBag.danhmuc_cate = danh_muc.Name;
            }
            List<Post> products = list_data_news;
            PagedList<Post> model = new PagedList<Post>(products, pageNumber, pageSize);

            return View(model);
        }
    }
}