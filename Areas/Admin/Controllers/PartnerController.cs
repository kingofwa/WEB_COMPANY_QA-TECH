using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Areas.Admin.Controllers
{
    public class PartnerController : BaseController
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: Admin/Partner
        public ActionResult Index()
        {
            var list_partner = db.Partner_DT.ToList();
            ViewData["list_partner"] = list_partner;
            return View();
        }
        public JsonResult Save_Partner(Partner_DT[] partner)
        {
            var value = 0;
            try
            {
                if (partner[0].Id > 0)
                {
                    var update = db.Partner_DT.Find(partner[0].Id);
                    update.image_partner = partner[0].image_partner;
                    update.Name_partner = partner[0].Name_partner;
                    db.SaveChanges();
                    value = partner[0].Id;
                }
                else
                {
                    var partnernew = new Partner_DT();
                    var layid = (from SLi in db.Partner_DT
                                 where SLi.Id > 0
                                 orderby SLi.Id descending
                                 select new
                                 {
                                     id_ = SLi.Id
                                 }).Take(1).ToArray();

                    if (layid.Any())
                    {
                        partnernew.Id = layid[0].id_ + 1;
                    }
                    else
                    {
                        partnernew.Id = 1;
                    }
                    partnernew.image_partner = partner[0].image_partner;
                    partnernew.Name_partner = partner[0].Name_partner;
                    partnernew.Status = 1;
                    db.Partner_DT.Add(partnernew);
                    db.SaveChanges();
                    value = partnernew.Id;
                }
            }
            catch (Exception)
            {
                value = 0;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save_Status(int Id_User)
        {
            var update = db.Partner_DT.Find(Id_User);
            if (update.Status == 1)
            {
                update.Status = 0;
            }
            else
            {
                update.Status = 1;
            }
            db.SaveChanges();
            var value = update.Status;
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeletePartner(int Id_User)
        {
            var value = false;
            try
            {
                var layid = db.Partner_DT.Find(Id_User);
                db.Partner_DT.Remove(layid);
                db.SaveChanges();
                value = true;
            }
            catch (Exception)
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Edit_Partner(int Id_User)
        {
            return Json(db.Partner_DT.Find(Id_User), JsonRequestBehavior.AllowGet);
        }
    }
}