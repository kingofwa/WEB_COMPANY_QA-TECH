using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;
using Web_congty.Modal.FW.View_model;

namespace Web_congty.Controllers
{
    public class Profile_UserController : Controller
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: Profile_User
        public new ActionResult Profile(int id)
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("Dangky", "Register");
            }
            var user = db.tbl_Uers.Where(x => x.Run_status == 1 && x.Id == id).ToList();
            ViewData["user"] = user;

            var folow = db.tbl_Uers.Find(id);
            if (folow.folow != null)
            {
                var a = folow.folow.Split('|');
                int b = 0;
                var c = (tbl_Uers)Session["Taikhoan"];
                for (var i = 0; i < a.Length; i++)
                {
                    if (a[i] != "")
                    {
                        if (Convert.ToInt32(a[i]) == Convert.ToInt32(c.Id))
                        {
                            b = id;
                        }
                    }
                }
                ViewBag.theodoi = b;
            }
            var baivietcuaban = db.Post_user.Where(x => x.Status == true && x.Id_uer == id).ToList();

            if (baivietcuaban.Count != 0)
            {
                ViewData["baivietcuaban"] = baivietcuaban;
                //hiển thị số ngày đăng bài trước đó
                var ngaydangtruocdo = "";
                var thangdangtruocdo = "";
                var namdangtruocdo = "";
                var ngayhientai = DateTime.Now.Day;
                var thanghientai = DateTime.Now.Month;
                var namhientai = DateTime.Now.Year;
                for (var j = 0; j < baivietcuaban.Count(); j++)
                {
                    var a = baivietcuaban[j].Time_up.GetValueOrDefault().Day;
                    ngaydangtruocdo += ngayhientai - a + "|";
                    var b = baivietcuaban[j].Time_up.GetValueOrDefault().Month;
                    thangdangtruocdo += thanghientai - b + "|";
                    var c = baivietcuaban[j].Time_up.GetValueOrDefault().Year;
                    namdangtruocdo += namhientai - c + "|";
                }
                var ngaydangtruocdo_splip = ngaydangtruocdo.Split('|');
                var thangdangtruocdo_splip = thangdangtruocdo.Split('|');
                var namdangtruocdo_splip = namdangtruocdo.Split('|');
                ViewBag.daynow = ngaydangtruocdo_splip;
                ViewBag.monthnow = thangdangtruocdo_splip;
                ViewBag.yearnow = namdangtruocdo_splip;
            }
            else
            {
                ViewBag.thogbaooo = "Chưa có đóng góp bài viết !";
            }
            // lấy danh sách theo dõi 
            var __id_folow_me = user[0].folow;
            if(__id_folow_me != null)
            {
                var list_folow_me = __id_folow_me.Split('|');
                List<__Folow_me> list_Folow_me = new List<__Folow_me>();
                for (var j = 0; j < list_folow_me.Length; j++)
                {
                    if (list_folow_me[j] != "")
                    {
                        var id_user = Convert.ToInt32(list_folow_me[j]);
                        foreach (var item in db.tbl_Uers.Where(x => x.Run_status == 1 && x.Id == id_user).ToList())
                        {
                            var ___list_folow_me__ = new __Folow_me();
                            ___list_folow_me__.id_folow = item.Id;
                            ___list_folow_me__.Email_folow = item.email;
                            ___list_folow_me__.Image_folow = item.Image_cus;
                            ___list_folow_me__.name_folow = item.name;
                            ___list_folow_me__.Sdt_folow = (int)item.phone;
                            ___list_folow_me__.Diachi_folow = item.addred;
                            list_Folow_me.Add(___list_folow_me__);
                        }
                    }
                }
                ViewData["list_folow_me_____"] = list_Folow_me;
            }
            else
            {
                ViewBag.Un_folow_me = "Chưa theo dõi ai";
            }

            return View();
        }
        public JsonResult Update_User(tbl_Uers[] update_user)
        {
            var value = 0;
            try
            {
                if (update_user[0].Id > 0)
                {
                    var update = db.tbl_Uers.Find(update_user[0].Id);
                    update.Image_cus = update_user[0].Image_cus;
                    update.name = update_user[0].name;
                    update.phone = update_user[0].phone;
                    update.addred = update_user[0].addred;
                    db.SaveChanges();
                    value = update_user[0].Id;
                }
            }
            catch (Exception)
            {
                value = 0;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }


        //chuyển trạng thái private sang public
        public JsonResult Chang_Status_P_(int Id_User)
        {
            var value = "";
            var update = db.tbl_Uers.Find(Id_User);
            if (update.public_private == 1)
            {
                update.public_private = 2;
                value = "true";
            }
            else
            {
                update.public_private = 1;
            }
            db.SaveChanges();

            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Chang_Folow_Me_(int Id_User, int theodoi__)
        {
            var d = 0;
            if (theodoi__ == 1)
            {
                var a = db.tbl_Uers.Find(Id_User);
                var c = (tbl_Uers)Session["Taikhoan"];
                if (a.folow != null)
                {
                    var b = a.folow.Split('|');
                    for (var i = 0; i < b.Length; i++)
                    {
                        if (b[i] != "")
                        {
                            if (Convert.ToInt32(b[i]) == Convert.ToInt32(c.Id))
                            {
                                string numToRemove = b[i];
                                b = b.Where(x => x != numToRemove).ToArray();
                                string s = "";
                                for (var j = 0; j < b.Length; j++)
                                {
                                    if (b[j] != "")
                                    {
                                        if (s == "")
                                        {
                                            s = b[j] + "|";
                                        }
                                        else
                                        {
                                            s += "|" + b[j];
                                        }
                                    }
                                }
                                a.folow = s;
                                db.SaveChanges();
                                d = 1;
                                return Json(d, JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                    a.folow += c.Id + "|";
                }
                else
                {
                    a.folow = c.Id + "|";
                }
                db.SaveChanges();
            }
            else
            {
                var a = db.tbl_Uers.Find(Id_User);
                var c = (tbl_Uers)Session["Taikhoan"];
                if (a.folow != null)
                {
                    var b = a.folow.Split('|');
                    for (var i = 0; i < b.Length; i++)
                    {
                        if (b[i] != "")
                        {
                            if (Convert.ToInt32(b[i]) == Convert.ToInt32(c.Id))
                            {
                                d = 1;
                                return Json(d, JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                    a.folow += c.Id + "|";
                }
                else
                {
                    a.folow = c.Id + "|";
                }
                db.SaveChanges();
            }

            return Json(d, JsonRequestBehavior.AllowGet);
        }
    }
}