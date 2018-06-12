using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;
using PagedList;
namespace Admin.Controllers
{
    public class TimKiemController : Controller
    {
        BanHoaQuaEntities db = new BanHoaQuaEntities();
        // GET: TimKiem
        [HttpPost]
        public ActionResult KetQua(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;

            List<view1> lstKQTK = db.view1.Where(n => n.TenSP.Contains(@"" + sTuKhoa + "")).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.view1.OrderBy(n => n.TenSP).ToPagedList(pageNumber, pageSize));
            }
            else
            {
                ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả với từ khoá "+sTuKhoa;
                return View(lstKQTK.OrderBy(n => n.TenSP).ToPagedList(pageNumber, pageSize));
            }
        }
        [HttpGet]
        public ActionResult KetQua(int? page, string sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<view1> lstKQTK = db.view1.Where(n => n.TenSP.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.view1.OrderBy(n => n.TenSP).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả!";
            return View(lstKQTK.OrderBy(n => n.TenSP).ToPagedList(pageNumber, pageSize));
        }
    }
}