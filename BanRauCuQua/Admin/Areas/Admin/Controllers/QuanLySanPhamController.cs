using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;
using PagedList;
using System.IO;
namespace Admin.Areas.Admin.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        BanHoaQuaEntities db = new BanHoaQuaEntities();
        
        // GET: Admin/QuanLySanPham
        public ActionResult Index(int page=1)
        {
            int pagenumber = page;
            int pagesize = 12;
            return View(db.SanPhams.OrderBy(n=>n.TenSP).ToPagedList(pagenumber,pagesize));
        }
        public PartialViewResult DanhMucSanPham()
        {
            return PartialView(db.Loais.ToList());
        }
        public ViewResult SanPhamTheoDanhMuc(int maLoai, int page = 1)
        {
            int pagesize = 12;
            int pagenumber = page;
            ViewBag.maLoai = maLoai;
            return View(db.SanPhams.Where(n => n.MaLoai == maLoai).OrderBy(n => n.TenSP).ToPagedList(pagenumber, pagesize));
        }
        [HttpGet]
        public ActionResult ThemMoi()
        {
            ViewBag.listNhaCungCap = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            ViewBag.listDonVi = new SelectList(db.DonVis, "MaDV", "TenDV");
            ViewBag.listLoai = new SelectList(db.Loais, "MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoi(SanPham sp, HttpPostedFileBase fileUpload)
        {
            
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Chọn hình ảnh";
                return View();
            }
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/Content/images/sanpham"), fileName);
                //Kiểm tra hình ảnh đã tồn tại chưa
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }
                sp.Anh = fileUpload.FileName;
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.listNhaCungCap = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            ViewBag.listDonVi = new SelectList(db.DonVis, "MaDV", "TenDV");
            ViewBag.listLoai = new SelectList(db.Loais, "MaLoai", "TenLoai");
            return View(sp);
        }
        [HttpGet]
        public ActionResult ChinhSua(int MaSP)
        {
            
            //Lấy ra đối tượng sách theo mã 
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Đưa dữ liệu vào dropdownlist
            ViewBag.listNhaCungCap = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            ViewBag.listDonVi = new SelectList(db.DonVis, "MaDV", "TenDV");
            ViewBag.listLoai = new SelectList(db.Loais, "MaLoai", "TenLoai");
            return View(sp);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(SanPham sp, FormCollection f, HttpPostedFileBase fileUpload)
        {
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Chọn hình ảnh";
                return View();
            }
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/Content/images/sanpham"), fileName);
                //Kiểm tra hình ảnh đã tồn tại chưa
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }
                sp.Anh = fileUpload.FileName;
                //Thực hiện cập nhận trong model
                db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            //Đưa dữ liệu vào dropdownlist
            ViewBag.listDonVi= new SelectList(db.DonVis.ToList().OrderBy(n => n.TenDV), "MaDV", "TenDV", sp.MaDV);
            ViewBag.listLoai = new SelectList(db.Loais.ToList().OrderBy(n => n.TenLoai), "MaLoai", "TenLoai", sp.MaLoai);
            ViewBag.listNhaCungCap = new SelectList(db.NhaCungCaps.ToList().OrderBy(n => n.TenNCC), "MaNCC", "TenNCC", sp.MaNCC);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Xoa(int MaSP)
        {
            SanPham sp = db.SanPhams.Find(MaSP);
            if (MaSP == 0)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        [HttpPost]
        [ActionName("Xoa")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoa(int MaSP)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.SanPhams.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index","QuanLySanPham");
        }
        public ActionResult HienThi(int MaSP)
        {

            //Lấy ra đối tượng sách theo mã 
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }
    }
}