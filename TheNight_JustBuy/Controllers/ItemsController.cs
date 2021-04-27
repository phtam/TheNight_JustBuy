using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheNight_JustBuy.Models;

namespace TheNight_JustBuy.Controllers
{
    public class ItemsController : Controller
    {
        private JustBuyEntities db = new JustBuyEntities();
        // GET: Items
        public ActionResult Index(int? id, int? page)
        {
            if (db.Categories.Find(id) == null || id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (page == null) page = 1;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            var list = db.Products.Where(m => m.CategoryID == id && m.Status == true).ToList();
            var model = list.ToPagedList(pageNumber, pageSize);
            ViewBag.Child = db.Categories.Find(id).CategoryName;
            ViewBag.Cate = db.Categories.Find(id).CategoryName;
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(string txtSearch, int? page)
        {
            if (page == null) page = 1;
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            if (txtSearch != null)
            {
                var list = db.Products.Where(m => m.ProductName.Contains(txtSearch) && m.Status == true).ToList();
                var model = list.ToPagedList(pageNumber, pageSize);
                return View(model);
            }

            return View();
        }



        public ActionResult Detail(int? id, int? page)
        {
            if (id == null || db.Products.Find(id) == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (page == null) page = 1;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var courseComments = db.ProductComments.Where(m => m.ProductID == id).OrderByDescending(m => m.CommentedDate).ToList();
            var model = courseComments.ToPagedList(pageNumber, pageSize);

            var course = db.Products.FirstOrDefault(m => m.ProductID == id && m.Status == true);
            ViewBag.Product = course;
            ViewBag.Image = db.ProductImages.Where(m => m.ProductID == id).ToList();
            int i = (int)db.Products.Find(id).CategoryID;
            ViewBag.Related = db.Products.Where(m => m.CategoryID == i).ToList();
            ViewBag.ProductName = db.Products.Find(id).ProductName; 
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Comment(string comment, int? ProductID)
        {
           

            var cmt = new ProductComment();

            cmt.UserID = 1;
            cmt.Content = comment;
            cmt.ProductID = (int)ProductID;
            cmt.CommentedDate = DateTime.Now;
            bool isValid = false;
            try
            {
                db.ProductComments.Add(cmt);
                if (db.SaveChanges() > 0)
                {
                    isValid = true;
                }
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Please complete the form before submitting";
                return RedirectToAction("Detail", "Items", new { id = ProductID });
            }

            if (isValid == true)
            {
                return RedirectToAction("Detail", "Items", new { id = cmt.ProductID });
            }
            return RedirectToAction("Detail", "Items", new { id = cmt.ProductID });
        }

        [ChildActionOnly]
        public ActionResult FilterProducts()
        {
            ViewBag.Category = db.Categories.ToList();
            ViewBag.Brand = db.Suppliers.ToList();
            return PartialView();
        }
    }
}