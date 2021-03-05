using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_congty.Modal.FW.View_model
{
    public partial class NextOrLast_News
    {
        public Nullable<int> Id_first { set; get; }
        public Nullable<int> Id_last { set; get; }
        public string Name_news_first { set; get; }
        public string Name_news_last { set; get; }
        public string Image_last { set; get; }
        public string Image_first { set; get; }
    }
}