using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_congty.Modal.FW
{
    [MetadataTypeAttribute(typeof(Commentmetadata))]
    public partial class Comment
    {
        internal sealed class Commentmetadata
        {
            [Required(ErrorMessage ="Bình luận không được để trống")]
            [MaxLength(500,ErrorMessage ="Bình luận không được quá  500 ký tự")]
            public string Noi_dung { get; set; }
        }
    }
}