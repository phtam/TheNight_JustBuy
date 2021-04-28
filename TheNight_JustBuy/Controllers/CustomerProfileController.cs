using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheNight_JustBuy.Areas.Admin.Models;
using TheNight_JustBuy.Models;
using TheNight_JustBuy.ViewModels;

namespace TheNight_JustBuy.Controllers
{
    public class CustomerProfileController : Controller
    {
        private JustBuyEntities db = new JustBuyEntities();
        // GET: CustomerProfile
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "FirstName,LastName,CreditCard,Gender,Birthday,Phone,Email,Avatar,EditedImage")] UserModelForEdit user)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(user.EditedImage.FileName) + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(user.EditedImage.FileName);

                user.Avatar = "~/public/uploadedFiles/userPictures/" + fileName;

                string uploadFolderPath = Server.MapPath("~/public/uploadedFiles/userPictures/");

                if (Directory.Exists(uploadFolderPath) == false)
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }

                fileName = Path.Combine(uploadFolderPath, fileName);

                user.EditedImage.SaveAs(fileName);
                var u = (CustomerInformation)Session[Common.CommonConstants.USER_LOGIN_MODEL];
                if (u is null)
                {

                    return RedirectToAction("Index", "Register");
                }
                var userEntity = db.Users.Find(u.UserID);
                userEntity.FirstName = user.FirstName;
                userEntity.LastName = user.LastName;
                userEntity.CreditCard = user.CreditCard;
                userEntity.Gender = user.Gender;
                userEntity.Birthday = user.Birthday;
                userEntity.Phone = user.Phone;
                userEntity.Email = user.Email;
                userEntity.Avatar = user.Avatar;


                if (db.SaveChanges() > 0)
                    ViewBag.Mess = "Successfully updated!";

                return View();
            }

            return View();
        }
    }
}