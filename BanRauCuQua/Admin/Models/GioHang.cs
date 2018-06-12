using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class GioHang
    {
        BanHoaQuaEntities db = new BanHoaQuaEntities();
        public int iMaSP { get; set; }
        public string sTenSP { get; set; }
        public string sAnh { get; set; }
        public double dDonGia { get; set; }
        public double iSoLuong { get; set; }
        public string sDonVi { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        //Hàm tạo cho giỏ hàng
        public GioHang(int MaSP)
        {
            iMaSP = MaSP;
            view1 sp = db.view1.Single(n => n.MaSP == iMaSP);
            sTenSP = sp.TenSP;
            sAnh = sp.Anh;
            dDonGia = double.Parse(sp.GiaBan.ToString());
            iSoLuong = 1;
            sDonVi = sp.TenDV;
        }
    }
}