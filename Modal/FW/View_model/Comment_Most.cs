using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_congty.Modal.FW.View_model
{
    public partial class Comment_Most
    {
        public Nullable<int> id_user { set; get; }
        public string Image_user { set; get; }
        public DateTime time { set; get; }
        public string name_user { set; get; }
        public string content_comment { set; get; }
    }
}