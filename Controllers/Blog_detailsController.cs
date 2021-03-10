using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;
using Web_congty.Modal.FW.View_model;

namespace Web_congty.Controllers
{
    public class Blog_detailsController : Controller
    {
        // GET: Blog_details
        Web_companyEntities db = new Web_companyEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detals_News(int id)
        {
            //if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            //{
            //    return RedirectToAction("Dangky", "Register");
            //}
            var list_data_news = db.Post.Where(x => x.Status == true && x.Id == id).ToList();
            ViewData["list_data_news"] = list_data_news;
            if (list_data_news.Any())
            {
                var id_cate = list_data_news[0].Id_brand;
                var danh_muc = db.Brand.Find(id_cate);
                ViewBag.danhmuc = danh_muc.Name;
            }
            var view = db.Post.Find(id);
            if (view.View_client == null)
            {
                view.View_client = 1;
            }
            else
            {
                view.View_client = view.View_client + 1;
            }
            db.SaveChanges();

            List<NextOrLast_News> list_news_new = new List<NextOrLast_News>();
            foreach (var item in list_data_news)
            {
                var list_news = new NextOrLast_News();
                list_news.Id_first = item.Id - 1;
                list_news.Id_last = item.Id + 1;
                var name_ = db.Post.Find(list_news.Id_first);
                if (name_.Status == true)
                {
                    list_news.Id_first = list_news.Id_first;
                }
                else
                {
                    list_news.Id_first = 3000;
                }
                list_news.Name_news_first = name_.Name;
                list_news.Image_first = name_.Image;
                var name_last = db.Post.Find(list_news.Id_last);
                if (name_last != null)
                {
                    list_news.Image_last = name_last.Image;
                    list_news.Name_news_last = name_last.Name;
                }
                else
                {
                    list_news.Image_last = "";
                    list_news.Name_news_last = "";
                }

                list_news_new.Add(list_news);
            }
            ViewData["list_news_new"] = list_news_new;
            ViewBag.Id_details = id;

            ViewData["list_reply_comment"] = db.List_reply_comment().Where(x => x.Id_post == id && x.Type_comment == 2).ToList();

            var list_commment_result = db.list_comment().Where(x => x.Status == true && x.Id_post == id && x.Type_comment == 1).ToList();
            ViewData["list_commment_result"] = list_commment_result;
            var total_comment = list_commment_result.Count();
            ViewBag.tongso = total_comment;

            var comment_up_vote_one = db.Comment.Where(x => x.Status == true && x.Id_post == id && x.Type_comment == 1 && x.Vote != null).OrderByDescending(x => x.Vote).Take(1).ToList();
            //bài viết chưa có comment log eurro
            if (comment_up_vote_one.Any())
            {
                var id_userr = comment_up_vote_one[0].Id_uer;
                var user = db.tbl_Uers.Find(id_userr);
                List<Comment_Most> comment_most = new List<Comment_Most>();
                if (user != null)
                {
                    var comment = new Comment_Most();
                    comment.id_user = user.Id;
                    comment.Image_user = user.Image_cus;
                    comment.name_user = user.name;
                    comment.time = (DateTime)comment_up_vote_one[0].Time;
                    comment.content_comment = comment_up_vote_one[0].Noi_dung;
                    comment_most.Add(comment);
                }
                ViewData["Binhluanhaynhat"] = comment_most;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Comment(Comment cm, FormCollection f)
        {
            var id = f["ID"].ToString();
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
                {
                    return RedirectToAction("Dangky", "Register");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    ViewBag.thongbao = "Bình luận thành công";
                    var tv = (tbl_Uers)Session["Taikhoan"];
                    cm.Id_uer = tv.Id;
                    cm.Time = DateTime.Now;
                    cm.Type_comment = 1;
                    cm.Id_post = Convert.ToInt32(id);
                    cm.Status = false;
                    cm.felling = 1;
                    db.Comment.Add(cm);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.thongbao = "Bình luận thất bại";
                }
            }
            return Redirect("Detals_News/" + id);
        }

        public JsonResult Vote_up(int id)
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                var thongbao = "Mời đăng nhập để bình chọn";
                return Json(thongbao, JsonRequestBehavior.AllowGet);
            }
            var tv = (tbl_Uers)Session["Taikhoan"];
            var up_vote = db.Comment.Find(id);
            if (up_vote.id_user_vote == null)
            {
                up_vote.id_user_vote = tv.Id + "|";
                up_vote.Vote = 1;
            }
            else
            {
                var a = up_vote.id_user_vote.Split('|');
                var leng_user = a.Length;
                for (var i = 0; i < leng_user; i++)
                {
                    if (up_vote.Vote == null)
                    {
                        up_vote.id_user_vote = tv.Id + "|";
                        up_vote.Vote = +1;
                    }
                    else
                    {
                        if (up_vote.id_user_vote == null)
                        {
                            up_vote.id_user_vote = tv.Id + "|";
                            up_vote.Vote = up_vote.Vote + 1;
                        }
                        else
                        {
                            if (a[i] != "")
                            {
                                if (tv.Id == Convert.ToInt32(a[i]))
                                {
                                    up_vote.Vote = up_vote.Vote;
                                    return Json(up_vote.Vote, JsonRequestBehavior.AllowGet);
                                }
                            }
                        }
                    }
                }
                up_vote.Vote = up_vote.Vote + 1;
                up_vote.id_user_vote = up_vote.id_user_vote + tv.Id + "|";
            }
            db.SaveChanges();
            var data = up_vote.Vote;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Vote_down(int id)
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                var thongbao = "Mời đăng nhập để bình chọn";
                return Json(thongbao, JsonRequestBehavior.AllowGet);
            }
            var tv = (tbl_Uers)Session["Taikhoan"];
            var up_vote = db.Comment.Find(id);
            if (up_vote.id_user_vote == null)
            {
                up_vote.id_user_vote = tv.Id + "|";
                up_vote.Vote = - 1;
            }
            else
            {
                var a = up_vote.id_user_vote.Split('|');
                var leng_user = a.Length;
                for (var i = 0; i < leng_user; i++)
                {
                    if (up_vote.Vote == null)
                    {
                        up_vote.id_user_vote = tv.Id + "|";
                        up_vote.Vote = -1;
                    }
                    else
                    {
                        if (up_vote.id_user_vote == null)
                        {
                            up_vote.id_user_vote = tv.Id + "|";
                            up_vote.Vote = up_vote.Vote - 1;
                        }
                        else
                        {
                            if (a[i] != "")
                            {
                                if (tv.Id == Convert.ToInt32(a[i]))
                                {
                                    up_vote.Vote = up_vote.Vote;
                                    return Json(up_vote.Vote, JsonRequestBehavior.AllowGet);
                                }
                            }
                        }
                    }
                }
                up_vote.Vote = up_vote.Vote - 1;
                up_vote.id_user_vote = up_vote.id_user_vote + tv.Id + "|";
            }
            db.SaveChanges();
            var data = up_vote.Vote;
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Reply_Comment(int id, string noidung, int id_post)
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                var thongbao = "Mời đăng nhập để trả lời bình luận";
                return Json(thongbao, JsonRequestBehavior.AllowGet);
            }
            var value = false;
            try
            {
                var comment = new Comment();
                //var comment = db.Comment.ToList();
                var tv = (tbl_Uers)Session["Taikhoan"];
                comment.Noi_dung = noidung;
                comment.Id_uer = tv.Id;
                comment.Id_reply = id;
                comment.Type_comment = 2;
                comment.Time = DateTime.Now;
                comment.Status = true;
                comment.Id_post = id_post;
                db.Comment.Add(comment);
                db.SaveChanges();
                value = true;
            }
            catch (Exception)
            {
                value = false;
            }

            return Json(value, JsonRequestBehavior.AllowGet);
        }
    }
}