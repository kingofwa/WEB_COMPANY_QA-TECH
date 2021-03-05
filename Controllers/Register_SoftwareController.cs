using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Web_congty.DAO;
using Web_congty.Modal.FW;

namespace Web_congty.Controllers
{
    public class Register_SoftwareController : Controller
    {
        // GET: Register_Software
        Web_companyEntities db = new Web_companyEntities();


        [HttpGet]
        public ActionResult Choose(string idpvc)
        {
            var ma = idpvc.Split('|');
            var _id = Convert.ToInt32(ma[0]);
            var phanmem = db.SoftWare_Case.Where(v => v.Id == _id).ToList();
            ViewBag.phanmem = phanmem[0].Sw_name;
            ViewBag.hinhanhphanmem = phanmem[0].Sw_image;
            var thongtin = db.Information_company.ToList();
            ViewBag.sdt = thongtin[0].Phone_hot;
            ViewBag.bank = thongtin[0].Bank_number;
            ViewBag.email = thongtin[0].Email_true;
            return View();
        }
        [HttpPost]
        public ActionResult Choose(string idpvc, tbl_Register_Software_Client register_sw)
        {
            try
            {
                var ma = idpvc.Split('|');
                var _id = Convert.ToInt32(ma[0]);
                var thoigiansudung = Convert.ToInt32(ma[1]);
                var goidichvu = Convert.ToInt32(ma[2]);
                var phanmem = db.SoftWare_Case.Where(v => v.Id == _id).ToList();
                if (ModelState.IsValid)
                {
                    Random rd = new Random();
                    string textRd;
                    textRd = Convert.ToString((char)rd.Next(65, 90));//CHỮ IN HOA
                    textRd = Convert.ToString((char)rd.Next(97, 122));//chữ thường

                    var pass = textRd+register_sw.Pass_login+"qa";
                    register_sw.Status = 1;
                    register_sw.Option_time = goidichvu;
                    register_sw.Option_sw = thoigiansudung;
                    register_sw.Id_Sw = _id;
                    register_sw.Pass_login = new CustommerDAO().MD5Hash(pass);
                    db.tbl_Register_Software_Client.Add(register_sw);
                    db.SaveChanges();
                    ViewBag.phanmem = phanmem[0].Sw_name;
                    ViewBag.hinhanhphanmem = phanmem[0].Sw_image;
                    ViewBag.thongbao = "Đăng ký thành công";

                    var Thoigian = "";
                    if (register_sw.Option_sw == 1)
                    {
                        Thoigian = "Theo Tháng";
                    }
                    else if (register_sw.Option_sw == 2)
                    {
                        Thoigian = "Theo Năm";
                    }
                    else if (register_sw.Option_sw == 0)
                    {
                        Thoigian = "Dùng thử";
                    }

                    var Loaihinhsudung = "";
                    if (register_sw.Option_time == 1)
                    {
                        Loaihinhsudung = "Gói Thường";
                    }
                    else if (register_sw.Option_time == 2)
                    {
                        Loaihinhsudung = "Gói Vip";
                    }
                    else if (register_sw.Option_time == 3)
                    {
                        Loaihinhsudung = "Gói Pro";
                    }
                    else if (register_sw.Option_time == 0)
                    {
                        Loaihinhsudung = "Dùng thử";
                    }
                    string sdt = register_sw.Phone_Client.ToString();
                    var link = "";
                    if (phanmem[0].Id == 1)
                    {
                        link = "http://14.248.138.6:86/admin";
                    }
                    else if (phanmem[0].Id == 2)
                    {
                        link = "http://14.248.138.6:86/admin";
                    }
                    else if (phanmem[0].Id == 3)
                    {
                        link = "http://14.248.138.6:86/admin";
                    }
                    // gửi mail khách hàng
                    string content = System.IO.File.ReadAllText(Server.MapPath("~/tempalate/Newsforder.html"));

                    content = content.Replace("{{CustomerName}}", register_sw.Name_Client);
                    content = content.Replace("{{Phone}}", sdt);
                    content = content.Replace("{{Email}}", register_sw.Email_CLient);
                    content = content.Replace("{{Address}}", register_sw.Addred_Client);
                    content = content.Replace("{{Phanmem}}", phanmem[0].Sw_name);
                    content = content.Replace("{{Thoigian}}", Thoigian);
                    content = content.Replace("{{Loaihinhsudung}}", Loaihinhsudung);
                    content = content.Replace("{{TaiKhoan}}", register_sw.Name_login);
                    content = content.Replace("{{MatKhau}}", pass);
                    content = content.Replace("{{SoftWareLink}}", link);
                    var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                    new MailHelper().SendMail(register_sw.Email_CLient, "Tin mới từ QUOCANH-TECH", content);
                    new MailHelper().SendMail(toEmail, "Tin mới từ QUOCANH-TECH", content);
                }
                else
                {
                    ViewBag.phanmem = phanmem[0].Sw_name;
                    ViewBag.hinhanhphanmem = phanmem[0].Sw_image;
                    var thongtin = db.Information_company.ToList();
                    ViewBag.sdt = thongtin[0].Phone_hot;
                    ViewBag.bank = thongtin[0].Bank_number;
                    ViewBag.email = thongtin[0].Email_true;
                    ViewBag.thongbao = "Đăng ký thất bại";
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Thực thể của loại \"{0}\" in state \"{1}\" có các lỗi xác thực sau:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return View();
        }
    }
}