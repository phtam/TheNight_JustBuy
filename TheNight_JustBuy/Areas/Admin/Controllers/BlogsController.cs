using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheNight_JustBuy.Areas.Admin.Models;
using TheNight_JustBuy.Models;

namespace TheNight_JustBuy.Areas.Admin.Controllers
{
    public class BlogsController : Controller
    {
        private JustBuyEntities db = new JustBuyEntities();

        // GET: Admin/Blogs
        public ActionResult Index()
        {
            var list = db.Blogs.Include(b => b.BlogCategory).Include(b => b.User).Where(b => b.Status == 1 || b.Status == 0).ToList();
            return View(list);
        }

        // GET: Admin/Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            BlogCategory blogCategories = db.BlogCategories.Find(blog.CategoryID);
            ViewBag.BlogCategory = blogCategories.CategoryName;
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Admin/Blogs/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.BlogCategories, "CategoryID", "CategoryName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username");
            ViewBag.StatusList = new SelectList(new List<SelectListItem> { new SelectListItem { Text = "Show", Value = "1" }, new SelectListItem { Text = "Hide", Value = "0" }, }, "Value", "Text");
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "BlogID,BlogName,UserID,CategoryID,ShortDescription,Content,Thumbnail,CreatedDate,Status,ImageFile")] BlogModelForCreate blog)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(blog.ImageFile.FileName) + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(blog.ImageFile.FileName);

                blog.Thumbnail = "~/public/uploadedFiles/blogPictures/" + fileName;

                string uploadFolderPath = Server.MapPath("~/public/uploadedFiles/blogPictures/");

                if (Directory.Exists(uploadFolderPath) == false)
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }

                fileName = Path.Combine(uploadFolderPath, fileName);

                blog.ImageFile.SaveAs(fileName);
                var user = 1;
                blog.UserID = user;

                var blogEntity = new Blog(blog);

                db.Blogs.Add(blogEntity);

                if (db.SaveChanges() > 0)
                {
                    TempData.Add(Common.CommonConstants.CREATE_SUCCESSFULLY, true);
                }

                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.BlogCategories, "CategoryID", "CategoryName", blog.CategoryID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", blog.UserID);
            return View(blog);
        }

        // GET: Admin/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            Session.Add(Common.CommonConstants.TEMP_BLOG_IMAGE, blog.Thumbnail);
            ViewBag.CategoryID = new SelectList(db.BlogCategories, "CategoryID", "CategoryName", blog.CategoryID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", blog.UserID);
            ViewBag.StatusList = new SelectList(new List<SelectListItem> { new SelectListItem { Text = "Show", Value = "1" }, new SelectListItem { Text = "Hide", Value = "0" }, }, "Value", "Text");
            return View(new BlogModelForEdit(blog));
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "BlogID,BlogName,UserID,CategoryID,ShortDescription,Content,Thumbnail,CreatedDate,Status,ImageFile")] BlogModelForEdit blog)
        {
            if (ModelState.IsValid)
            {
                if (blog.ImageFile == null)
                {
                    blog.Thumbnail = Session[Common.CommonConstants.TEMP_BLOG_IMAGE].ToString();
                }
                else
                {
                    string fileName = Path.GetFileNameWithoutExtension(blog.ImageFile.FileName) + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(blog.ImageFile.FileName);

                    blog.Thumbnail = "~/public/uploadedFiles/blogPictures/" + fileName;

                    string uploadFolderPath = Server.MapPath("~/public/uploadedFiles/blogPictures/");

                    if (Directory.Exists(uploadFolderPath) == false)
                    {
                        Directory.CreateDirectory(uploadFolderPath);
                    }
                    fileName = Path.Combine(uploadFolderPath, fileName);
                    try
                    {
                        System.IO.File.Delete(Server.MapPath(Session[Common.CommonConstants.TEMP_BLOG_IMAGE].ToString()));
                    }
                    catch (Exception)
                    {
                    }
                    blog.ImageFile.SaveAs(fileName);

                }
                var blogEntity = db.Blogs.Find(blog.BlogID);
                blogEntity.BlogID = blog.BlogID;
                blogEntity.BlogName = blog.BlogName;
                blogEntity.CategoryID = blog.CategoryID;
                blogEntity.Content = blog.Content;
                blogEntity.Thumbnail = blog.Thumbnail;
                blogEntity.CreatedDate = blog.CreatedDate;
                blogEntity.Status = blog.Status;
                blogEntity.ShortDescription = blog.ShortDescription;

                if (db.SaveChanges() > 0)
                {
                    Session.Remove(Common.CommonConstants.TEMP_BLOG_IMAGE);
                    TempData.Add(Common.CommonConstants.SAVE_SUCCESSFULLY, true);
                }
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.BlogCategories, "CategoryID", "CategoryName", blog.CategoryID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", blog.UserID);
            ViewBag.StatusList = new SelectList(new List<SelectListItem> { new SelectListItem { Text = "Show", Value = "1" }, new SelectListItem { Text = "Hide", Value = "0" }, }, "Value", "Text");
            return View(blog);
        }

        // GET: Admin/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            BlogCategory blogCategories = db.BlogCategories.Find(blog.CategoryID);
            ViewBag.BlogCategory = blogCategories.CategoryName;
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Blog blog = db.Blogs.Find(id);
                db.Blogs.Remove(blog);
                if (db.SaveChanges() > 0)
                {
                    try
                    {
                        System.IO.File.Delete(Server.MapPath(blog.Thumbnail));
                    }
                    catch (Exception)
                    {
                    }
                    TempData.Add(Common.CommonConstants.DELETE_SUCCESSFULLY, true);
                }
            }
            catch (Exception)
            {
                TempData.Add(Common.CommonConstants.DELETE_FAILED, true);
            }

            return RedirectToAction("Index");
        }

        public JsonResult ActiveStatus(int id)
        {
            var blog = db.Blogs.Find(id);
            blog.Status = 1;
            db.SaveChanges();
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DisableStatus(int id)
        {
            var blog = db.Blogs.Find(id);
            blog.Status = 0;
            db.SaveChanges();
            return Json(new
            {
                status = true
            });
        }


        public ActionResult Approve()
        {
            var list = db.Blogs.Include(b => b.BlogCategory).Include(b => b.User).Where(b => b.Status == -1).ToList();
            return View(list);
        }

        public JsonResult ApproveBlog(int id)
        {
            var blog = db.Blogs.Find(id);
            blog.Status = 1;
            db.SaveChanges();
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Ignore(int id)
        {
            var blog = db.Blogs.Find(id);
            blog.Status = -2;
            db.SaveChanges();
            return Json(new
            {
                status = true
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
