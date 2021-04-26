using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheNight_JustBuy.Models;

namespace TheNight_JustBuy.Areas.Admin.Controllers
{
    public class BlogCommentsController : Controller
    {
        private JustBuyEntities db = new JustBuyEntities();

        // GET: Admin/BlogComments
        public ActionResult Index()
        {
            var blogComments = db.BlogComments.Include(b => b.Blog).Include(b => b.User);
            return View(blogComments.ToList());
        }

        // GET: Admin/BlogComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogComment blogComment = db.BlogComments.Find(id);
            if (blogComment == null)
            {
                return HttpNotFound();
            }
            return View(blogComment);
        }

        // GET: Admin/BlogComments/Create
        public ActionResult Create()
        {
            ViewBag.BlogID = new SelectList(db.Blogs, "BlogID", "BlogName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username");
            return View();
        }

        // POST: Admin/BlogComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,UserID,BlogID,Content,CreatedDate,Status")] BlogComment blogComment)
        {
            if (ModelState.IsValid)
            {
                db.BlogComments.Add(blogComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BlogID = new SelectList(db.Blogs, "BlogID", "BlogName", blogComment.BlogID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", blogComment.UserID);
            return View(blogComment);
        }

        // GET: Admin/BlogComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogComment blogComment = db.BlogComments.Find(id);
            if (blogComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogID = new SelectList(db.Blogs, "BlogID", "BlogName", blogComment.BlogID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", blogComment.UserID);
            return View(blogComment);
        }

        // POST: Admin/BlogComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentID,UserID,BlogID,Content,CreatedDate,Status")] BlogComment blogComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlogID = new SelectList(db.Blogs, "BlogID", "BlogName", blogComment.BlogID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", blogComment.UserID);
            return View(blogComment);
        }

        public JsonResult ActiveStatus(int id)
        {
            var comment = db.BlogComments.Find(id);
            comment.Status = true;
            db.SaveChanges();
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DisableStatus(int id)
        {
            var comment = db.BlogComments.Find(id);
            comment.Status = false;
            db.SaveChanges();
            return Json(new
            {
                status = true
            });
        }

        // GET: Admin/BlogComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogComment blogComment = db.BlogComments.Find(id);
            if (blogComment == null)
            {
                return HttpNotFound();
            }
            return View(blogComment);
        }

        // POST: Admin/BlogComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                BlogComment comment = db.BlogComments.Find(id);
                db.BlogComments.Remove(comment);
                if (db.SaveChanges() > 0)
                {
                    TempData.Add(Common.CommonConstants.DELETE_SUCCESSFULLY, true);
                }
            }
            catch (Exception)
            {
                TempData.Add(Common.CommonConstants.DELETE_FAILED, true);
            }
            return RedirectToAction("Index");
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
