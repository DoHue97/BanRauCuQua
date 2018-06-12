using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Admin.Models
{
    [MetadataTypeAttribute(typeof(CTDHMetadata))]
    public partial class ChiTietDonHang
    {
        internal sealed class CTDHMetadata
        {
            [Display(Name = "Mã đơn hàng")]
            public int MaDH { get; set; }
            [Display(Name = "Mã sản phẩm")]
            public int MaSP { get; set; }
            [Display(Name = "Số lượng")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public Nullable<double> SoLuong { get; set; }
            [Display(Name = "Giảm giá")]
            public Nullable<double> GiamGia { get; set; }
            [Display(Name = "Đơn giá")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public Nullable<double> DonGia { get; set; }

            [Display(Name = "Thành tiền")]
            public Nullable<double> ThanhTien { get; set; }
        }
    }
}