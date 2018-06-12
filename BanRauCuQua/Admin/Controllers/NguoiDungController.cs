using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;
namespace Admin.Controllers
{
    public class NguoiDungController : Controller
    {
        BanHoaQuaEntities db = new BanHoaQuaEntities();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                //Them du lieu
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string tendn = f["TenDN"].ToString();
            string matkhau = f.Get("MatKhau").ToString();
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TenDN == tendn && n.MatKhau == matkhau);
            TaiKhoanAdmin admin = db.TaiKhoanAdmins.SingleOrDefault(n => n.TenDN == tendn && n.MatKhau == matkhau);
            if (tendn == "DoHue" && matkhau == "1234")
            {
                Session["Admin"] = admin;
                return RedirectToAction("Index", "Admin");
            }
            else if (kh != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công";
                Session["TaiKhoan"] = kh;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ThongBao = "Tài khoản hoặc mật khẩu không đúng";
            return View();
        }
       
    }
}