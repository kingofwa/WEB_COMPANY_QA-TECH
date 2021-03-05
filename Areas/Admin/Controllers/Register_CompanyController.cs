using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Areas.Admin.Controllers
{
    public class Register_CompanyController : Controller
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: Admin/Register_Company
        public ActionResult Index()
        {
            ViewData["Register"] = db.Information_company.ToList();
            return View();
        }

        public JsonResult Save_Register_Admin(Information_company[] arr_list_Register)
        {
            var value = false;
            try
            {
                var update_register = db.Information_company.Find(1);
                update_register.Addred = arr_list_Register[0].Addred;
                update_register.Advertisement_QC = arr_list_Register[0].Advertisement_QC;
                update_register.Best_Company = arr_list_Register[0].Best_Company;
                update_register.Email = arr_list_Register[0].Email;
                update_register.Email_CPN = arr_list_Register[0].Email_CPN;
                update_register.Facebook = arr_list_Register[0].Facebook;
                update_register.Google = arr_list_Register[0].Google;
                update_register.Logo = arr_list_Register[0].Logo;
                update_register.Name_CPN = arr_list_Register[0].Name_CPN;
                update_register.Notification_TB = arr_list_Register[0].Notification_TB;
                update_register.Phone = arr_list_Register[0].Phone;
                update_register.Phone_hot = arr_list_Register[0].Phone_hot;
                update_register.Email_true = arr_list_Register[0].Email_true;
                update_register.Bank_number = arr_list_Register[0].Bank_number;
                update_register.Register = arr_list_Register[0].Register;
                update_register.Slogan = arr_list_Register[0].Slogan;
                update_register.Viber = arr_list_Register[0].Viber;
                update_register.Youtube = arr_list_Register[0].Youtube;
                db.SaveChanges();
                value = true;
            }
            catch
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);

        }
    }
}