using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopThoiTrang.Models;
using WebShopThoiTrang.Models.EF;

namespace WebShopThoiTrang.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        // GET: Admin/Order
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Order
        public ActionResult Index(int? page)
        {
            //var pageSize = 5;
            //if (page == null)
            //{
            //    page = 1;
            //}
            //IEnumerable<Order> items = db.Orders.OrderByDescending(x => x.Id);
            //if (!string.IsNullOrEmpty(Searchtext))
            //{
            //    items = items.Where(x => x.Code.Contains(Searchtext)
            //                        || x.CustomerName.Contains(Searchtext)
            //                        );
            //}
            //var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            //items = items.ToPagedList(pageIndex, pageSize);
            //ViewBag.PageSize = pageSize;
            //ViewBag.Page = page;
            //return View(items);
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 20;
            var lsCategories = db.Orders.AsNoTracking()
                .OrderByDescending(x => x.Id);
            PagedList<Order> models = new PagedList<Order>(lsCategories, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;

            return View(models);
        }


        public ActionResult View(int id)
        {
            var item = db.Orders.Find(id);
            return View(item);
        }

        public ActionResult Partial_SanPham(int id)
        {
            var items = db.OrderDetails.Where(x => x.OrderId == id).ToList();
            return PartialView(items);
        }

        [HttpPost]
        public ActionResult UpdateTT(int id, int trangthai)
        {
            var item = db.Orders.Find(id);
            if (item != null)
            {
                db.Orders.Attach(item);
                item.TypePayment = trangthai;
                db.Entry(item).Property(x => x.TypePayment).IsModified = true;
                db.SaveChanges();
                return Json(new { message = "Success", Success = true });
            }
            return Json(new { message = "Unsuccess", Success = false });
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}