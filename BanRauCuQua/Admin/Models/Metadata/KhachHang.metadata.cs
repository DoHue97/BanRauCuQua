using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Admin.Models
{
    [MetadataTypeAttribute(typeof(KhachHangMetadata))]
    public partial class KhachHang
    {
        internal sealed class KhachHangMetadata
        {
            [Display(Name = "Mã khách hàng")]
            public int MaKH { get; set; }
            [Display(Name = "Tên khách hàng")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string TenKH { get; set; }
            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string DiaChi { get; set; }
            [Display(Name = "Điện thoại")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string DienThoai { get; set; }
            [Display(Name = "Tên đăng nhập")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string TenDN { get; set; }
            [Display(Name = "Mật khẩu")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string MatKhau { get; set; }
            [Display(Name = "Email")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string Email { get; set; }
        }
    }
}