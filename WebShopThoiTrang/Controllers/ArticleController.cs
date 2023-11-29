using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopThoiTrang.Models;

namespace WebShopThoiTrang.Controllers
{
    public class ArticleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Article
        public ActionResult Index(string alias)
        {
            var item = db.Posts.FirstOrDefault(x => x.Alias == alias);
            return View(item);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}