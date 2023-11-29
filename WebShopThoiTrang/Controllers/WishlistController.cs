using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;
using WebShopThoiTrang.Models;
using WebShopThoiTrang.Models.EF;

namespace WebShopThoiTrang.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: Wishlist
        public ActionResult Index(int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Wishlist> items = db.Wishlists.Where(w => w.UserName == User.Identity.Name).OrderByDescending(x=>x.CreateDate);
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostWishlist(int ProductId)
        {
            if (Request.IsAuthenticated== false)
            {
                return Json(new { Success = false, Message = "Bạn chưa đăng nhập." });
            }
            var checkItem = db.Wishlists.FirstOrDefault(x => x.ProductId == ProductId && x.UserName == User.Identity.Name);
            if(checkItem != null)
            {
                return Json(new { Success = false, Message = "Sản phẩm đã được yêu thích rồi." });
            }
            var item = new Wishlist();
            item.ProductId = ProductId;
            item.UserName = User.Identity.Name;
            item.CreateDate = DateTime.Now;
            db.Wishlists.Add(item);
            db.SaveChanges();
            return Json(new {Success = true});
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Wishlists.Find(id);
            if (item != null)
            {
                db.Wishlists.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult PostDeleteWishlist(int ProductId)
        {
            var checkItem = db.Wishlists.FirstOrDefault(x => x.ProductId == ProductId && x.UserName == User.Identity.Name);
            if (checkItem != null)
            {
                db.Wishlists.Remove(checkItem);
                db.SaveChanges();
                return Json(new { Success = false, Message = "Xóa thành công" });
            }
            return Json(new { Success = false, Message = "Xóa thất bại." });
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}