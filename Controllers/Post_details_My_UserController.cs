using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Controllers
{
    public class Post_details_My_UserController : Controller
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: Post_details_My_User
        public ActionResult Detals_Post(int id)
        {
            var list_data_news = db.Post_user.Where(x => x.Status == true && x.Id == id).ToList();
            ViewData["list_data_news"] = list_data_news;
            ViewBag.name_post = list_data_news[0].Name;
            if(list_data_news[0].View_client == null)
            {
                list_data_news[0].View_client = 1;
            }
            else
            {
                list_data_news[0].View_client += 1;
            }
            db.SaveChanges();
            return View();
        }
    }
}