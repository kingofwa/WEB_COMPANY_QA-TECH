using System;
using System.ComponentModel.DataAnnotations;
namespace Web_congty.Modal.FW
{
    [MetadataType(typeof(Dangkysudungphanmem))]
    public partial class tbl_Register_Software_Client
    {
        internal sealed class Dangkysudungphanmem
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Tên tài khoản không được để trống")]
            [MaxLength(50, ErrorMessage = "Tên tài khoản không được quá 50 ký tự")]
            [MinLength(6, ErrorMessage = "Tên tài khoản không được ít hơn 6 ký tự")]
            [RegularExpression(@"^\S*$", ErrorMessage = "Không được chứa khoảng trắng")]
            public string Name_login { get; set; }

            [Required(ErrorMessage = "Mật khẩu không được để trống")]
            [RegularExpression(@"^\S*$", ErrorMessage = "Không được chứa khoảng trắng")]
            public string Pass_login { get; set; }

            [Required(ErrorMessage = "Tên không được để trống")]
            [StringLength(250, ErrorMessage = "Tên không được quá 250 ký tự")]
            public string Name_Client { get; set; }

            [Required(ErrorMessage = "Số điện thoại không được để trống")]
            public Nullable<int> Phone_Client { get; set; }


            [Required(ErrorMessage = "Email không được để trống")]
            [StringLength(250, ErrorMessage = "Tên Email không được quá 250 ký tự")]
            [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email không chính xác")]
            [EmailAddress]
            public string Email_CLient { get; set; }

            [Required(ErrorMessage = "Địa chỉ không được để trống")]
            [StringLength(250, ErrorMessage = "Tên Địa chỉ không được quá 250 ký tự")]
            public string Addred_Client { get; set; }
              
            [Required(ErrorMessage = "Tên doanh nghiệp không được để trống")]
            [StringLength(500, ErrorMessage = "Tên doanh nghiệp không được quá 500 ký tự")]
            public string Name_Businet { get; set; }
        }
    }
}