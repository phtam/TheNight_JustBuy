using Scrypt;
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
    public class AdministratorsController : Controller
    {
        private JustBuyEntities db = new JustBuyEntities();

        // GET: Admin/Users
        public ActionResult Index()
        {
            var user = db.Users.Where(u => u.Role == true);
            return View(user.ToList());
        }



        // GET: Admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        
        public ActionResult Address(int? id)
        {
            if (id != null && db.Users.Find(id) != null)
            {
                ViewBag.UserId = id;
                var list = db.Addresses.ToList();
                ViewBag.List = list;
                ViewBag.Username = db.Users.Find(id).Username;
                return View();
            }
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Address([Bind(Include = "AddressID,UserID,AddressDetail,City,District,ZipCode")] Address address)
        {
            if (ModelState.IsValid)
            {

                db.Addresses.Add(address);
                if (db.SaveChanges() > 0)
                    TempData.Add(Common.CommonConstants.CREATE_SUCCESSFULLY, true);
                return RedirectToAction("Address", "Administrators", new { @id = address.UserID });
            }

            return RedirectToAction("Address", "Administrators", new { @id = address.UserID });
        }

        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Username,FirstName,LastName,Password,CreditCard,Gender,Birthday,Phone,Email,Avatar,ImageFile")] UserModelForCreate user)
        {
            if (ModelState.IsValid)
            {

                string fileName = Path.GetFileNameWithoutExtension(user.ImageFile.FileName) + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(user.ImageFile.FileName);

                user.Avatar = "~/public/uploadedFiles/userPictures/" + fileName;

                string uploadFolderPath = Server.MapPath("~/public/uploadedFiles/userPictures/");

                if (Directory.Exists(uploadFolderPath) == false)
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }

                fileName = Path.Combine(uploadFolderPath, fileName);

                user.ImageFile.SaveAs(fileName);

                ScryptEncoder encoder = new ScryptEncoder();
                user.Password = encoder.Encode(user.Password);
                user.Role = true;
                user.Status = true;
                var userEntity = new User(user);

                db.Users.Add(userEntity);
                if (db.SaveChanges() > 0)
                    TempData.Add(Common.CommonConstants.CREATE_SUCCESSFULLY, true);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            Session["OldImage_User"] = user.Avatar;
            return View(new UserModelForEdit(user));
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Username,FirstName,LastName,CreditCard,Gender,Birthday,Phone,Email,Avatar,Status,EditedImage")] UserModelForEdit user, String imageOldFile_User)
        {
            if (ModelState.IsValid)
            {
                if (user.EditedImage == null)
                {
                    user.Avatar = imageOldFile_User;
                }
                else
                {
                    string fileName = Path.GetFileNameWithoutExtension(user.EditedImage.FileName) + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(user.EditedImage.FileName);

                    user.Avatar = "~/public/uploadedFiles/userPictures/" + fileName;

                    string uploadFolderPath = Server.MapPath("~/public/uploadedFiles/userPictures/");

                    if (Directory.Exists(uploadFolderPath) == false)
                    {
                        Directory.CreateDirectory(uploadFolderPath);
                    }

                    fileName = Path.Combine(uploadFolderPath, fileName);

                    try
                    {
                        System.IO.File.Delete(Server.MapPath(imageOldFile_User));
                    }
                    catch (Exception)
                    {
                    }
                    user.EditedImage.SaveAs(fileName);
                }

                var userEntity = db.Users.Find(user.UserID);
                userEntity.FirstName = user.FirstName;
                userEntity.LastName = user.LastName;
                userEntity.CreditCard = user.CreditCard;
                userEntity.Gender = user.Gender;
                userEntity.Birthday = user.Birthday;
                userEntity.Phone = user.Phone;
                userEntity.Email = user.Email;
                userEntity.Avatar = user.Avatar;
                userEntity.Status = user.Status;
        
                if (db.SaveChanges() > 0)
                {
                    Session.Remove("OldImage_User");
                    TempData.Add(Common.CommonConstants.SAVE_SUCCESSFULLY, true);
                }
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

       

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            try
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                try
                {
                    System.IO.File.Delete(Server.MapPath(user.Avatar));
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
