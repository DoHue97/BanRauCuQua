using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Admin.Models
{
    [MetadataTypeAttribute(typeof(NhaCungCapMetadata))]
    public partial class NhaCungCap
    {
        internal sealed class NhaCungCapMetadata
        {
            [Display(Name = "Mã nhà cung cấp")]
            public int MaNCC { get; set; }
            [Display(Name = "Tên nhà cung cấp")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string TenNCC { get; set; }
            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string DiaChi { get; set; }
            [Display(Name = "Điện thoại")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string DienThoai { get; set; }
        }
    }
}