using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;
using PagedList;
namespace Admin.Controllers
{
    public class HomeController : Controller
    {
        BanHoaQuaEntities db = new BanHoaQuaEntities();
        public ActionResult Index(int page = 1)
        {
            int pagesize = 12;
            int pagenumber = page;
            return View(db.view1.OrderBy(n => n.TenSP).ToPagedList(pagenumber, pagesize));
        }
        public PartialViewResult Menu()
        {
            return PartialView();
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            Session["Admin"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}