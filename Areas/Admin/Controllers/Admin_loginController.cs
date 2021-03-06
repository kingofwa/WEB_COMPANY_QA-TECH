using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Common;
using Web_congty.Modal.FW;

namespace Web_congty.Areas.Admin.Controllers
{
    public class Admin_loginController : Controller
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: Admin/Admin_login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.login(model.UserName, model.Password);
                switch (result)
                {
                    case 1:
                        var user = dao.GetById(model.UserName);
                        var userSesstion = new UserLogin();
                        Session["TaikhoanAdmin"] = model.UserName;
                        Session["userId"] = user.Id_user;
                        userSesstion.Email_user = user.Email_user;
                        userSesstion.Id_user = user.Id_user;
                        Session.Add(CommonConstants.USER_SESSTION, userSesstion);
                    return RedirectToAction("Index", "AdminHome");
                    case 0:
                        ModelState.AddModelError("", "Tài khoản không tồn tại !");
                        break;
                    case -1:
                        ModelState.AddModelError("", "Tài khoản đang bị khóa !");
                        break;
                    case -2:
                        ModelState.AddModelError("", "Sai mật khẩu!");
                        break;
                    default:
                        ModelState.AddModelError("", "Tên đăng nhập or mật khẩu không đúng !");
                        break;
                }
                return View(model);
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session["Taikhoan"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin_login");
        }
    }
}