using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;
using PagedList;
namespace Admin.Areas.Admin.Controllers
{
    public class QuanLyKhachHangController : Controller
    {
        // GET: Admin/QuanLyKhachHang
        BanHoaQuaEntities db = new BanHoaQuaEntities();
        public ActionResult Index(int page=1)
        {
            int pagesize = 12;
            int pagenumber = page;
            return View(db.KhachHangs.OrderBy(n=>n.TenKH).ToPagedList(pagenumber,pagesize));
        }
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoi([Bind(Include = "MaKH,TenKH,DiaChi,DienThoai,TenDN,MatKhau,Email")] KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kh);
        }
        [HttpGet]
        public ActionResult Sua(int Makh)
        {
            //Lấy ra đối tượng sách theo mã 
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKH == Makh);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Sua(KhachHang kh, FormCollection f)
        {
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhận trong model
                db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Xoa(int Makh)
        {
            KhachHang sp = db.KhachHangs.Find(Makh);
            if (Makh == 0)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        [HttpPost]
        [ActionName("Xoa")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoa(int Makh)
        {
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKH == Makh);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KhachHangs.Remove(kh);
            db.SaveChanges();
            return View();
        }
    }
}