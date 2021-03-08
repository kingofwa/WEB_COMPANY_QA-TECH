using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_congty.Common
{
    [Serializable]
    public class UserLogin
    {
        public long Id_user { set; get; }
        public string Email_user { set; get; }
    }
}