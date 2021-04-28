using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheNight_JustBuy.Models;
using PagedList;
using TheNight_JustBuy.ViewModels;

namespace TheNight_JustBuy.Controllers
{
    public class BlogController : Controller
    {
        private JustBuyEntities db = new JustBuyEntities();
        // GET: Blog
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var list = db.Blogs.Where(m => m.Status == 1).OrderByDescending(m => m.CreatedDate).ToList();
            var model = list.ToPagedList(pageNumber, pageSize);
            return View(model);
        }

        public ActionResult Category(int? id, int? page)
        {
            if (id == null || db.BlogCategories.Find(id) == null)
            {
                return RedirectToAction("Index", "Blog");
            }
            if (page == null) page = 1;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var list = db.Blogs.Where(m => m.Status == 1 && m.CategoryID == id).OrderByDescending(m => m.CreatedDate).ToList();
            ViewBag.Child = db.BlogCategories.Find(id).CategoryName;
            ViewBag.Cate = db.BlogCategories.Find(id).CategoryName;
            var model = list.ToPagedList(pageNumber, pageSize);
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Comment(string comment, int? blogID)
        {
            var user = (CustomerInformation)Session[Common.CommonConstants.USER_LOGIN_MODEL];
            if (user is null)
            {

                return RedirectToAction("Index", "Register");
            }
            if (comment == null)
            {
                ViewBag.MessComment = "Please enter a comment!";
                return RedirectToAction("Detail", "Blog", new { id = blogID });
            }
            if (comment.Length == 0)
            {
                ViewBag.MessComment = "Please enter a comment!";
                return RedirectToAction("Detail", "Blog", new { id = blogID });
            }
          
            var cmt = new BlogComment();

            cmt.UserID = user.UserID;
            cmt.Content = comment;
            cmt.BlogID = (int)blogID;
            cmt.CreatedDate = DateTime.Now;
            cmt.Status = true;
            bool isValid = false;
            try
            {
                db.BlogComments.Add(cmt);
                if (db.SaveChanges() > 0)
                {
                    isValid = true;
                }
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Please complete the form before submitting";
                return RedirectToAction("Detail", "Blog", new { id = blogID });
            }

            if (isValid == true)
            {
                return RedirectToAction("Detail", "Blog", new { id = cmt.BlogID });
            }

            return RedirectToAction("Detail", "Blog", new { id = cmt.BlogID });
        }


        public ActionResult Detail(int? id, int? page)
        {
            if (id == null || db.Blogs.Find(id) == null)
            {
                return RedirectToAction("Index", "Blog");
            }
            if (page == null) page = 1;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var blogComments = db.BlogComments.Where(m => m.BlogID == id && m.Status == true).OrderByDescending(m => m.CreatedDate).ToList();
            var model = blogComments.ToPagedList(pageNumber, pageSize);
            ViewBag.BlogDetail = db.Blogs.FirstOrDefault(m => m.BlogID == id && m.Status == 1);
            var a = db.Blogs.FirstOrDefault(m => m.BlogID == id && m.Status == 1);
            ViewBag.BlogName = a.BlogName;
            ViewBag.CategoryName = a.BlogCategory.CategoryName;
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(string txtSearch, int? page)
        {
            if (page == null) page = 1;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            if (txtSearch != null)
            {
                var list = db.Blogs.Where(m => m.BlogName.Contains(txtSearch) && m.Status == 1).ToList();
                var model = list.ToPagedList(pageNumber, pageSize);
                return View(model);
            }
            return View();
        }


        [ChildActionOnly]
        public ActionResult BlogFilter()
        {
            ViewBag.BlogCaterory = db.BlogCategories.ToList();
            ViewBag.RecentPosts = db.Blogs.Where(m => m.Status == 1).OrderByDescending(m => m.CreatedDate).Take(3).ToList();
            ViewBag.RecentComments = db.BlogComments.Where(m => m.Status == true).OrderByDescending(m => m.CreatedDate).Take(4).ToList();
            return PartialView();
        }
    }
}