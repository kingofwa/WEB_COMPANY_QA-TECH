using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_congty.DAO;

namespace Web_congty.Modal.FW
{
    public class UserDao
    {
        Web_companyEntities db = null;
        public UserDao()
        {
            db = new Web_companyEntities();
        }
        public long Isert(tbl_Uers_Admin entity)
        {
            db.tbl_Uers_Admin.Add(entity);
            db.SaveChanges();
            return entity.Id_user;
        }
        public tbl_Uers_Admin GetById(string userName)
        {
            return db.tbl_Uers_Admin.FirstOrDefault(x => x.Email_user == userName);
        }
        public int login(string userName, string password)
        {
            var pass = new CustommerDAO().MD5Hash(password);
            var result = db.tbl_Uers_Admin.FirstOrDefault(x => x.Email_user == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password_user == pass)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
    }
}