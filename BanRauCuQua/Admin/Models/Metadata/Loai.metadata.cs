using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Admin.Models.Metadata
{
    public class Loai
    {
        internal sealed class KhachHangMetadata
        {
            [Display(Name = "Mã loại")]
            public int MaLoai { get; set; }

            [Display(Name = "Tên loại")]
            public string TenLoai { get; set; }
        }
    }
}