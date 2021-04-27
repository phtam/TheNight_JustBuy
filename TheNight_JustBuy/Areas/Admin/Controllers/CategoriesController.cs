using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheNight_JustBuy.Common;
using TheNight_JustBuy.Models;

namespace TheNight_JustBuy.Areas.Admin.Controllers
{
    [Authorize(Roles = "true")]
    public class CategoriesController : BaseController
    {
        private JustBuyEntities db = new JustBuyEntities();

        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName,CategoryImage,ImageFile")] Category category)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(category.ImageFile.FileName) + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(category.ImageFile.FileName);

                category.CategoryImage = "~/public/uploadedFiles/categoryPictures/" + fileName;

                string uploadFolderPath = Server.MapPath("~/public/uploadedFiles/categoryPictures/");

                if (Directory.Exists(uploadFolderPath) == false)
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }

                fileName = Path.Combine(uploadFolderPath, fileName);

                category.ImageFile.SaveAs(fileName);


                db.Categories.Add(category);

                if (db.SaveChanges() > 0)
                {
                    TempData.Add(Common.CommonConstants.CREATE_SUCCESSFULLY, true);
                }

                return RedirectToAction("Index");

            }

            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            Session.Add(CommonConstants.TEMP_CATEGORY_IMAGE, category.CategoryImage);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName,CategoryImage,ImageFile")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                try
                {
                    if (category.ImageFile == null)
                    {
                        category.CategoryImage = Session[CommonConstants.TEMP_CATEGORY_IMAGE].ToString();
                    }
                    else
                    {
                        string fileName = Path.GetFileNameWithoutExtension(category.ImageFile.FileName) + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(category.ImageFile.FileName);

                        category.CategoryImage = "~/public/uploadedFiles/categoryPictures/" + fileName;

                        string uploadFolderPath = Server.MapPath("~/public/uploadedFiles/categoryPictures/");

                        if (Directory.Exists(uploadFolderPath) == false)
                        {
                            Directory.CreateDirectory(uploadFolderPath);
                        }

                        fileName = Path.Combine(uploadFolderPath, fileName);

                        try
                        {
                            System.IO.File.Delete(Server.MapPath(Session[Common.CommonConstants.TEMP_CATEGORY_IMAGE].ToString()));
                        }
                        catch (Exception)
                        {
                        }
                        category.ImageFile.SaveAs(fileName);

                    }

                    if (db.SaveChanges() > 0)
                    {
                        Session.Remove(CommonConstants.TEMP_CATEGORY_IMAGE);
                        TempData.Add(CommonConstants.SAVE_SUCCESSFULLY, true);
                    }
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    TempData.Add(CommonConstants.SAVE_FAILED, true);
                    ex.Entries.Single().Reload();
                }

                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            try
            {
                Category category = db.Categories.Find(id);
                db.Categories.Remove(category);
                db.SaveChanges();
                try
                {
                    System.IO.File.Delete(Server.MapPath(category.CategoryImage));
                }
                catch (Exception) { }
                TempData.Add(CommonConstants.DELETE_SUCCESSFULLY, true);
            }
            catch (Exception)
            {
                TempData.Add(CommonConstants.DELETE_FAILED, true);
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
