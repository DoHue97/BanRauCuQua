using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;
using PagedList;
namespace Admin.Areas.Admin.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        BanHoaQuaEntities db = new BanHoaQuaEntities();
        static DateTime ngaydat;
        // GET: Admin/QuanLyDonHang
        public ActionResult Index(int page = 1)
        {
            int pagesize = 12;
            int pagenumber = page;
            return View(db.DonHangs.OrderBy(n => n.MaDH).ToPagedList(pagenumber, pagesize));
        }
        [HttpGet]
        public ActionResult ThemMoi()
        {
            ViewBag.listKH = new SelectList(db.KhachHangs, "MaKH", "TenKH");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoi([Bind(Include = "MaDH,MaKH,NgayDat,NgayGiao,DaThanhToan")] DonHang DonHang)
        {
            ViewBag.listKH = new SelectList(db.KhachHangs, "MaKH", "TenKH");
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(DonHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(DonHang);
        }
        [HttpGet]
        public ActionResult Sua(int MaDH)
        {
            //Lấy ra đối tượng sách theo mã 
            ViewBag.listKH = new SelectList(db.KhachHangs, "MaKH", "TenKH");
            DonHang DonHang = db.DonHangs.SingleOrDefault(n => n.MaDH == MaDH);
            
            if (DonHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }            
            return View(DonHang);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Sua(DonHang DonHang, FormCollection f)
        {
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhận trong model
                db.Entry(DonHang).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Xoa(int Madh)
        {
            DonHang sp = db.DonHangs.Find(Madh);
            if (Madh == 0)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        [HttpPost]
        [ActionName("Xoa")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoa(int Madh)
        {
            DonHang donhang = db.DonHangs.SingleOrDefault(n => n.MaDH == Madh);
            IEnumerable<ChiTietDonHang> ctdh = db.ChiTietDonHangs.Where(i => i.MaDH == Madh);            
            if (donhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            foreach (var item in ctdh)
            {
                db.ChiTietDonHangs.Remove(item);               
            }
            db.DonHangs.Remove(donhang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult HienThi(int MaDH)
        {

            //Lấy ra đối tượng sách theo mã 
            DonHang dh = db.DonHangs.SingleOrDefault(n => n.MaDH == MaDH);
            if (dh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dh);
        }
    }
}