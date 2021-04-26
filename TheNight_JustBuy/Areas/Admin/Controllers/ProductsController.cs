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
    public class ProductsController : Controller
    {
        private JustBuyEntities db = new JustBuyEntities();

        // GET: Admin/Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Discount).Include(p => p.Supplier);
            return View(products.ToList());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Images(int ?id)
        {
            if (id == null && db.Products.Find(id) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.ProductId = id;
            var list = db.ProductImages.ToList();
            ViewBag.List = list;
            ViewBag.ProductName = db.Products.Find(id).ProductName;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Images(int ProductID, HttpPostedFileBase ImageFile)
        {
            ProductImage productImage = new ProductImage();
            productImage.ProductID = ProductID;

            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName) + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(ImageFile.FileName);

            String thumbnail = "~/public/uploadedFiles/productImagePictures/" + fileName;

            string uploadFolderPath = Server.MapPath("~/public/uploadedFiles/productImagePictures/");

            if (Directory.Exists(uploadFolderPath) == false)
            {
                Directory.CreateDirectory(uploadFolderPath);
            }

            fileName = Path.Combine(uploadFolderPath, fileName);

            ImageFile.SaveAs(fileName);
            productImage.ImageFileName = thumbnail;

            db.ProductImages.Add(productImage);
            if (db.SaveChanges() > 0)
                TempData.Add(Common.CommonConstants.CREATE_SUCCESSFULLY, true);
            return RedirectToAction("Images", "Products", new { @id = ProductID });
        }

        [HttpPost, ActionName("DeleteImage")]
        public ActionResult DeleteImage(int ImageId, int ProductId)
        {
            try
            {
                ProductImage productImage = db.ProductImages.Find(ImageId);
                db.ProductImages.Remove(productImage);
                if (db.SaveChanges() > 0)
                {
                    try
                    {
                        System.IO.File.Delete(Server.MapPath(productImage.ImageFileName));
                    }
                    catch (Exception) { }
                    TempData.Add(Common.CommonConstants.DELETE_SUCCESSFULLY, true);
                }
            }
            catch (Exception)
            {
                TempData.Add(Common.CommonConstants.DELETE_FAILED, true);
            }

            return RedirectToAction("Images", "Products", new { @id = ProductId });


        }


            // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.DiscountID = new SelectList(db.Discounts, "DiscountID", "DiscountName");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,UnitPrice,OldUnitPrice,ShortDescription,Description,Thumbnail,UnitsInStock,LaunchDate,VotedAverageMark,SupplierID,CategoryID,DiscountID,Status,ImageFile")] ProductModelForCreate product)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName) + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(product.ImageFile.FileName);

                product.Thumbnail = "~/public/uploadedFiles/productsPictures/" + fileName;

                string uploadFolderPath = Server.MapPath("~/public/uploadedFiles/productsPictures/");

                if (Directory.Exists(uploadFolderPath) == false)
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }

                fileName = Path.Combine(uploadFolderPath, fileName);

                product.ImageFile.SaveAs(fileName);

                var productEntity = new Product(product);

                db.Products.Add(productEntity);
                if (db.SaveChanges() > 0)
                    TempData.Add(Common.CommonConstants.CREATE_SUCCESSFULLY, true);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.DiscountID = new SelectList(db.Discounts, "DiscountID", "DiscountName", product.DiscountID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            Session.Add(Common.CommonConstants.TEMP_PRODUCT_IMAGE, product.Thumbnail);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.DiscountID = new SelectList(db.Discounts, "DiscountID", "DiscountName", product.DiscountID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
            return View(new ProductModelForEdit(product));
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,UnitPrice,OldUnitPrice,ShortDescription,Description,Thumbnail,UnitsInStock,LaunchDate,VotedAverageMark,SupplierID,CategoryID,DiscountID,Status,ImageFile")] ProductModelForEdit product)
        {
            if (ModelState.IsValid)
            {
                if (product.ImageFile == null)
                {
                    product.Thumbnail = Session[Common.CommonConstants.TEMP_PRODUCT_IMAGE].ToString();
                }
                else
                {
                    string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName) + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(product.ImageFile.FileName);

                    product.Thumbnail = "~/public/uploadedFiles/productsPictures/" + fileName;

                    string uploadFolderPath = Server.MapPath("~/public/uploadedFiles/productsPictures/");

                    if (Directory.Exists(uploadFolderPath) == false)
                    {
                        Directory.CreateDirectory(uploadFolderPath);
                    }

                    fileName = Path.Combine(uploadFolderPath, fileName);

                    try
                    {
                        System.IO.File.Delete(Server.MapPath(Session[Common.CommonConstants.TEMP_PRODUCT_IMAGE].ToString()));
                    }
                    catch (Exception)
                    {
                    }
                    product.ImageFile.SaveAs(fileName);

                    
                }
                var p = db.Products.Find(product.ProductID);
                p.ProductID = product.ProductID;
                p.ProductName = product.ProductName;
                p.UnitPrice = product.UnitPrice;
                p.OldUnitPrice = product.OldUnitPrice;
                p.ShortDescription = product.ShortDescription;
                p.Description = product.ShortDescription;
                p.Thumbnail = product.Thumbnail;
                p.UnitsInStock = product.UnitsInStock;
                p.LaunchDate = product.LaunchDate;
                p.SupplierID = product.SupplierID;
                p.CategoryID = product.CategoryID;
                p.DiscountID = product.DiscountID;
                p.Status = product.Status;

                if (db.SaveChanges() > 0)
                {
                    Session.Remove(Common.CommonConstants.TEMP_PRODUCT_IMAGE);
                    TempData.Add(Common.CommonConstants.SAVE_SUCCESSFULLY, true);
                }
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.DiscountID = new SelectList(db.Discounts, "DiscountID", "DiscountName", product.DiscountID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Product product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                try
                {
                    System.IO.File.Delete(Server.MapPath(product.Thumbnail));
                }
                catch (Exception) { }
                TempData.Add(Common.CommonConstants.DELETE_SUCCESSFULLY, true);
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
