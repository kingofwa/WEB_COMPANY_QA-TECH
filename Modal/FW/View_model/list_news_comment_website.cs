using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_congty.Modal.FW.View_model
{
    public class list_news_comment_website
    {
        public Nullable<int> id_custommer { set; get; }
        public string Name_custommer { set; get; }
        public string Time_change { set; get; }
        public string Name_post_news { set; get; }
        public Nullable<int> id_post { set; get; }
        public string vote_type_news { set; get; }
        public string Name_software { set; get; }
        public Nullable<int> id_software { set; get; }

        public Nullable<int> id_register_software { set; get; }
        public string Name_register_software { set; get; }


    }
}