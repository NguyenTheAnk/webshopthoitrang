using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopThoiTrang.Models;
using WebShopThoiTrang.Models.EF;

namespace WebShopThoiTrang.Areas.Admin.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Search
        public ActionResult FindCategory(string keyword)
        {
            List<Category> ls = new List<Category>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                //return PartialView("ListProductsSearchPartial", null);
                ls = db.Categories
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Take(20).ToList();
            }

            else
            {
                //return PartialView("ListProductsSearchPartial", ls);
                ls = db.Categories
               .AsNoTracking()
               .Where(x => (x.Id).ToString().Contains(keyword))
               .OrderByDescending(x => x.Title)
               .Take(20).ToList();
            }
            return PartialView("ListCategoriesSearchPartial", ls);
        }
        public ActionResult FindOrders(string keyword)
        {
            List<Order> ls = new List<Order>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                //return PartialView("ListProductsSearchPartial", null);
                ls = db.Orders
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Take(10).ToList();
            }

            else
            {
                //return PartialView("ListProductsSearchPartial", ls);
                ls = db.Orders
               .AsNoTracking()
               .Where(x => x.CustomerName.Contains(keyword))
               .OrderByDescending(x => x.CustomerName)
               .Take(10).ToList();
            }
            return PartialView("ListOrdersSearchPartial", ls);
        }
    }
}