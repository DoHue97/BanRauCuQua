using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;
namespace Admin.Models
{
    [MetadataTypeAttribute(typeof(SanPhamMetadata))]
    public partial class SanPham
    {
        internal sealed class SanPhamMetadata
        {
            [Display(Name = "Mã sản phẩm")]
            public int MaSP { get; set; }
            [Display(Name = "Tên sản phẩm")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string TenSP { get; set; }
            [Display(Name = "Mã nhà cung cấp")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public Nullable<int> MaNCC { get; set; }
            [Display(Name = "Mô tả")]

            public string MoTa { get; set; }
            [Display(Name = "Số lượng tồn")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public Nullable<double> SLTon { get; set; }
            [Display(Name = "Giá bán")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public Nullable<double> GiaBan { get; set; }
            [Display(Name = "Ảnh")]
            public string Anh { get; set; }
            [Display(Name = "Mã đơn vị")]
            public Nullable<int> MaDV { get; set; }
            [Display(Name = "Mã loại")]
            public Nullable<int> MaLoai { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [Display(Name = "Ngày cập nhật")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            //[Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public Nullable<System.DateTime> NgayCapNhat { get; set; }
        }
    }
}