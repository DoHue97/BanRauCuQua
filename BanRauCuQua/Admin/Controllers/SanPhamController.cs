using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;
using PagedList;
namespace Admin.Controllers
{
    public class SanPhamController : Controller
    {
        BanHoaQuaEntities db = new BanHoaQuaEntities();
        // GET: SanPham
        public PartialViewResult DanhMucSanPham()
        {
            return PartialView(db.Loais.ToList());
        }
        public JsonResult DanhMuc()
        {
            return Json(db.SanPhams.ToList());
        }
        public ViewResult SanPhamTheoDanhMuc(int maLoai, int page = 1)
        {
            int pagesize = 12;
            int pagenumber = page;
            ViewBag.maLoai = maLoai;
            return View(db.view1.Where(n => n.MaLoai == maLoai).OrderBy(n => n.TenSP).ToPagedList(pagenumber, pagesize));
        }
        public ViewResult ChiTietSanPham(int masp)
        {
            view1 sp = db.view1.Where(n => n.MaSP == masp).SingleOrDefault();
            return View(sp);
        }
    }
}