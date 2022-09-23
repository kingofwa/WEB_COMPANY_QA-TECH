using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_congty.Modal.FW;

namespace Web_congty.Areas.Admin.Controllers
{
    public class Project_SystemController : BaseController
    {
        Web_companyEntities db = new Web_companyEntities();
        // GET: Admin/Project_System
        public ActionResult Index()
        {
            ViewData["list_system"] = db.Project_system.ToList();
            return View();
        }

        public JsonResult Save_System(Project_system[] system)
        {
            var value = 0;
            try
            {
                if (system[0].Id > 0)
                {
                    var update = db.Project_system.Find(system[0].Id);
                    update.ChiTietDuAn = system[0].ChiTietDuAn;
                    update.Diachi_DuAn = system[0].Diachi_DuAn;
                    update.Ghi_chu = system[0].Ghi_chu;
                    update.Hinhanhmota = system[0].Hinhanhmota;
                    update.Motangan = system[0].Motangan;
                    update.Ten_DuAn = system[0].Ten_DuAn;
                    update.Ten_KySu = system[0].Ten_KySu;
                    update.Thoigianhoanthanh = system[0].Thoigianhoanthanh;
                    update.Thoigiankhoicong = system[0].Thoigiankhoicong;
                    update.Tongtien_DuAn = system[0].Tongtien_DuAn;
                    update.Hinhanhchitiet = system[0].Hinhanhchitiet;
                    db.SaveChanges();
                    value = system[0].Id;
                }
                else
                {
                    var systemnew = new Project_system();
                    var layid = (from SLi in db.Project_system
                                 where SLi.Id > 0
                                 orderby SLi.Id descending
                                 select new
                                 {
                                     id_soft = SLi.Id
                                 }).Take(1).ToArray();

                    if (layid.Any())
                    {
                        systemnew.Id = layid[0].id_soft + 1;
                    }
                    else
                    {
                        systemnew.Id = 1;
                    }
                    systemnew.ChiTietDuAn = system[0].ChiTietDuAn;
                    systemnew.Diachi_DuAn = system[0].Diachi_DuAn;
                    systemnew.Ghi_chu = system[0].Ghi_chu;
                    systemnew.Hinhanhmota = system[0].Hinhanhmota;
                    systemnew.Motangan = system[0].Motangan;
                    systemnew.Ten_DuAn = system[0].Ten_DuAn;
                    systemnew.Ten_KySu = system[0].Ten_KySu;
                    systemnew.Thoigianhoanthanh = system[0].Thoigianhoanthanh;
                    systemnew.Thoigiankhoicong = system[0].Thoigiankhoicong;
                    systemnew.Tongtien_DuAn = system[0].Tongtien_DuAn;
                    systemnew.Hinhanhchitiet = system[0].Hinhanhchitiet;
                    systemnew.TheLoai_DuAn = 1;
                    db.Project_system.Add(systemnew);
                    db.SaveChanges();
                    value = systemnew.Id;
                }
            }
            catch (Exception)
            {
                value = 0;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteSystem(int Id_User)
        {
            var value = false;
            try
            {
                var layid = db.Project_system.Find(Id_User);
                db.Project_system.Remove(layid);
                db.SaveChanges();
                value = true;
            }
            catch (Exception)
            {
                value = false;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit_System(int Id_User)
        {
            return Json(db.Project_system.Find(Id_User), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save_Status(int id)
        {
            var status = db.Project_system.Find(id);
            var value = 0;
            try
            {
                if (status.TheLoai_DuAn == 1)
                {
                    status.TheLoai_DuAn = 2;
                }
                else if (status.TheLoai_DuAn == 2)
                {
                    status.TheLoai_DuAn = 3;
                }
                else if (status.TheLoai_DuAn == 3)
                {
                    status.TheLoai_DuAn = 1;
                }
                db.SaveChanges();
                value = (int)status.TheLoai_DuAn;
            }
            catch (Exception)
            {
                value = 0;
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

    }
}