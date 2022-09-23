using System;
using System.ComponentModel.DataAnnotations;
namespace Web_congty.Modal.FW
{
    [MetadataType(typeof(Post_usermetaData))]
    public partial class Post_user
    {
        internal sealed class Post_usermetaData
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Tên bài viết không được để trống")]
            [StringLength(250, ErrorMessage = "Tên bài viết không được quá 250 ký tự")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Chọn danh mục đăng lên")]
            public Nullable<int> Id_brand { get; set; }

            [Required(ErrorMessage = "Mời chọn ảnh")]
            public string Image { get; set; }

            [Required(ErrorMessage = "Tên tác giả không được để trống")]
            [StringLength(200, ErrorMessage = "Tên tác giả không được quá 200 ký tự")]
            public string Author { get; set; }

            [Required(ErrorMessage = "Tiêu đề không được để trống")]
            [StringLength(200, ErrorMessage = "Tiêu đề giả không được quá 200 ký tự")]
            public string Title { get; set; }

           [Required(ErrorMessage = "Chi tiết không được để trống")]
            public string Details { get; set; }
           
        }
    }
}