using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShopThoiTrang.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}