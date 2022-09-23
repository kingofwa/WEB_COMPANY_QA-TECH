using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_congty.Modal.FW
{
    [MetadataTypeAttribute(typeof(tbl_UersMetaData))]
    public partial class tbl_Uers
    {
        internal sealed class tbl_UersMetaData
        {
            public int Id { get; set; }
            [Required(ErrorMessage ="Tài khoản không được để trống")]
            [StringLength(20,ErrorMessage ="Tài khoản không được quá 20 ký tự")]
            public string name { get; set; }
            [Required(ErrorMessage = "Email không được để trống")]
            [StringLength(30, ErrorMessage = "Email không được quá 30 ký tự")]
            public string email { get; set; }
            [Required(ErrorMessage = "Password không được để trống")]
            [MinLength(6, ErrorMessage = "Password không được ít hơn 6 ký tự")]
            public string password { get; set; }
            public string Image_cus { get; set; }
            public Nullable<System.DateTime> Day { get; set; }
            public Nullable<int> Run_status { get; set; }
            public Nullable<int> phone { get; set; }
            public string question { get; set; }
            [MaxLength(200, ErrorMessage = "Trả lời không được nhiều hơn 200 ký tự")]
            [Required(ErrorMessage = "Trả lời không được để trống")]
            public string reply { get; set; }
            public string addred { get; set; }
            public Nullable<int> type_uer { get; set; }
        }
    }
}