using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;
namespace Admin.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        BanHoaQuaEntities db = new BanHoaQuaEntities();
        // GET: Admin/Default
        public ActionResult Index()
        {
            return RedirectToAction("Index","QuanLySanPham");
        }
        public ActionResult ThongTin()
        {
            TaiKhoanAdmin admin = (TaiKhoanAdmin)Session["Admin"];
            //ma = admin.MaAdmin;
            return View(admin);
        }
        
    }
}