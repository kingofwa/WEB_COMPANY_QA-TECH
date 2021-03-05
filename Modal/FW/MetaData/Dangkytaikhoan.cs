using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Web_congty.Modal.FW
{
    [MetadataType(typeof(tbl_register_usermetaData))]
    public partial class tbl_Uers_Admin
    {
        internal sealed class tbl_register_usermetaData
        {
            public int Id_user { get; set; }
            [Required(ErrorMessage = "Email không được để trống")]
            [StringLength(250, ErrorMessage = "Tên Email không được quá 250 ký tự")]
            [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email không chính xác")]
            [EmailAddress]
            public string Email_user { get; set; }
            [Required(ErrorMessage = "Mật khẩu không được để trống")]
            public string Password_user { get; set; }

            public string Image_user { get; set; }
        }
    }
}