using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;
using PagedList;

namespace Web_congty.Controllers
{
    public class TimKiemController : Controller
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: TimKiem
        [HttpGet]
        public ActionResult KQ_TimKiem(string STuKhoa, int pageNumber = 1, int pageSize = 5)
        {
            //tim kiem theo ten bai viet
            var listNews = db.Post.Where(n => n.Name.Contains(STuKhoa));
            ViewData["listNews"] = listNews;
            ViewBag.brand = db.Brand.Where(x => x.status == true).ToList();
            List<Post> products = db.Post.Where(x => x.Status == true).OrderBy(x => x.Id).ToList();
            PagedList<Post> model = new PagedList<Post>(products, pageNumber, pageSize);

            return View(model);
        }

        [HttpPost]
        public ActionResult LayTuKhoaTimKiem(string STuKhoa)
        {
            // gọi về hàm get tìm kiếm
            return RedirectToAction("KQ_TimKiem",new {@STuKhoa = STuKhoa });
        }
    }
}