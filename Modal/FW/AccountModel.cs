using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Web_congty.Modal.FW
{
    public class AccountModel
    {
        private Web_companyEntities context = null;
        public AccountModel()
        {
            context = new Web_companyEntities();
        }
        public bool login(string UserName, string Passsword)
        {
            Object[] sqlparams =
            {
                new SqlParameter("@Name_User", UserName),
                 new SqlParameter("@Pass_User", Passsword),
            };
            var res = context.Database.SqlQuery<bool>("tbl_Uers_Admin @Email_user,@Pass_User", sqlparams).SingleOrDefault();
            return res;
        }
    }
}