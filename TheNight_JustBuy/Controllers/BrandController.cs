using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheNight_JustBuy.Models;

namespace TheNight_JustBuy.Controllers
{
    public class BrandController : Controller
    {
        private JustBuyEntities db = new JustBuyEntities();
        // GET: Brand
        public ActionResult Index(int? id, int? page)
        {
            if (db.Suppliers.Find(id) == null || id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (page == null) page = 1;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            var list = db.Products.Where(m => m.SupplierID == id && m.Status == true).ToList();
            var model = list.ToPagedList(pageNumber, pageSize);
            ViewBag.Child = db.Suppliers.Find(id).CompanyName;
            ViewBag.Cate = db.Suppliers.Find(id).CompanyName;
            ViewBag.CateID = id;
            return View(model);
        }
    }
}