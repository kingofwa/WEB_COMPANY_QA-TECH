using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Controllers
{
    public class Details_SW_Controller : Controller
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: Details_SW_
        public ActionResult Index(int id)
        {
            var list_detais_software = db.SoftWare_Case.Where(x => x.Sw_Status == true && x.Id == id).ToList();
            ViewData["list_detais_software"] = list_detais_software;

            //lay truyen id phần mềm  xuong view để update vào lại bảng comment
            ViewBag.Id_details_SoftWare = id;

            ViewData["list_reply_comment_software"] = db.List_reply_comment().Where(x => x.Id_software == id && x.Type_comment == 2).ToList();

            var list_commment_result = db.list_comment().Where(x => x.Status == true && x.Id_software == id && x.Type_comment == 1).ToList();
            ViewData["list_commment_result_software"] = list_commment_result;
            var total_comment = list_commment_result.Count();
            ViewBag.tongso = total_comment;


            return View();
        }
        [HttpPost]
        public ActionResult Comment_Soft_Ware(Comment cm_soft_ware, FormCollection f_software)
        {
            var id = f_software["ID_Soft_Ware"].ToString();
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("Dangky", "Register");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    ViewBag.thongbao = "Bình luận thành công";
                    var tv = (tbl_Uers)Session["Taikhoan"];
                    cm_soft_ware.Id_uer = tv.Id;
                    cm_soft_ware.Time = DateTime.Now;
                    cm_soft_ware.Type_comment = 1;
                    cm_soft_ware.Id_software = Convert.ToInt32(id);
                    cm_soft_ware.Status = false;
                    cm_soft_ware.felling = 1;
                    db.Comments.Add(cm_soft_ware);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.thongbao = "Bình luận thất bại";
                }
                return Redirect("Index/" + id);
            }
        }

        //trả lời bình luận
        public JsonResult Reply_Comment(int id, string noidung, int id_software)
        {
            string binhluanthanhcong = "";
            string mesage = "";
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                 mesage = "Vui lòng đăng nhập để trả lời bình luận";
            }
            else
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
                comment.Id_software = id_software;
                db.Comments.Add(comment);
                db.SaveChanges();
                binhluanthanhcong = "1";
            }
            var data = new { valueee = binhluanthanhcong, mesage = mesage };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Vote_up(int id)
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                var thongbao = "Mời đăng nhập để bình chọn";
                return Json(thongbao, JsonRequestBehavior.AllowGet);
            }
            var tv = (tbl_Uers)Session["Taikhoan"];
            var up_vote = db.Comments.Find(id);
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
            var up_vote = db.Comments.Find(id);
            if (up_vote.id_user_vote == null)
            {
                up_vote.id_user_vote = tv.Id + "|";
                up_vote.Vote = -1;
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
        
        //public ActionResult Choose(string idpvc)
        //{
        //    var ma = idpvc.Split('|');
        //    var _id = Convert.ToInt32(ma[0]);
        //    var phanmem = db.SoftWare_Case.Where(v => v.Id == _id).ToList();
        //    ViewBag.phanmem = phanmem[0].Sw_name;
        //    ViewBag.hinhanhphanmem = phanmem[0].Sw_image;

        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Choose(string Id, tbl_Register_Software_Client register_sw)
        //{
        //    var ma = Id.Split('|');
        //    var id = Convert.ToInt32(ma[0]);
        //    var thoigiansudung = Convert.ToInt32(ma[1]);
        //    var goidichvu = ma[2];
        //    var phanmem = db.SoftWare_Case.Where(v => v.Id == id).ToList();
        //    if (ModelState.IsValid)
        //    {
        //        register_sw.Status = 1;
        //        register_sw.Option_time = goidichvu;
        //        register_sw.Option_sw = thoigiansudung;
        //        register_sw.Id_Sw = id;
        //        db.tbl_Register_Software_Client.Add(register_sw);
        //        db.SaveChanges();
        //        ViewBag.phanmem = phanmem[0].Sw_name;
        //        ViewBag.hinhanhphanmem = phanmem[0].Sw_image;
        //        ViewBag.thongbao = "Đăng ký thành công";
        //    }
        //    else
        //    {
        //        ViewBag.phanmem = phanmem[0].Sw_name;
        //        ViewBag.hinhanhphanmem = phanmem[0].Sw_image;
        //        ViewBag.thongbao = "Đăng ký thất bại";
        //    }
        //    return View();
        //}

    }
}