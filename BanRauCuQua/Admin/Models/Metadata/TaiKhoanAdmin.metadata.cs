using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    [MetadataTypeAttribute(typeof(TaiKhoanAdminMetadata))]
    public partial class TaiKhoanAdmin
    {
        internal sealed class TaiKhoanAdminMetadata
        {
            [Display(Name = "Mã admin")]
            public int MaAdmin { get; set; }

            [Display(Name = "Họ tên")]
            public string HoTen { get; set; }

            [Display(Name = "Địa chỉ")]
            public string DiaChi { get; set; }

            [Display(Name = "Điện thoại")]
            public string DienThoai { get; set; }

            [Display(Name = "Tên đăng nhập")]
            public string TenDN { get; set; }

            [Display(Name = "Mật khẩu")]
            public string MatKhau { get; set; }

            [Display(Name = "Email")]
            public string Email { get; set; }
        }
    }
}