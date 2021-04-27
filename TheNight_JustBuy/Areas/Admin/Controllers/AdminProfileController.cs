using Scrypt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TheNight_JustBuy.Areas.Admin.Models;
using TheNight_JustBuy.Models;
using TheNight_JustBuy.ViewModels;

namespace TheNight_JustBuy.Areas.Admin.Controllers
{
    [Authorize(Roles = "true")]
    public class AdminProfileController : BaseController
    {
        private JustBuyEntities db = new JustBuyEntities();
        public ActionResult Index()
        {
            var admin = (AdminLoginModel)Session[Common.CommonConstants.ADMIN_LOGIN_SESSION];
            ViewBag.AdminInfo = admin;
            Session.Add(Common.CommonConstants.TEMP_ADMIN_IMAGE, admin.Avatar);
            var model = new UserModelForEdit(admin);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserID,Username,FirstName,LastName,CreditCard,Gender,Birthday,Phone,Email,Avatar,Status,EditedImage")] UserModelForEdit user)
        {
            if (ModelState.IsValid)
            {
                if (user.EditedImage == null)
                {
                    user.Avatar = Session[Common.CommonConstants.TEMP_ADMIN_IMAGE].ToString();
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
                        System.IO.File.Delete(Server.MapPath(Session[Common.CommonConstants.TEMP_ADMIN_IMAGE].ToString()));
                    }
                    catch (Exception)
                    {
                    }
                    user.EditedImage.SaveAs(fileName);

                }
                var userEntity = db.Users.Find(user.UserID);
                userEntity.FirstName = user.FirstName;
                userEntity.LastName = user.LastName;
                userEntity.Birthday = user.Birthday;
                userEntity.Gender = user.Gender;
                userEntity.CreditCard = user.CreditCard;
                userEntity.Phone = user.Phone;
                userEntity.Email = user.Email;
                userEntity.Avatar = user.Avatar;

                if (db.SaveChanges() > 0)
                {
                    Session.Remove(Common.CommonConstants.TEMP_ADMIN_IMAGE);
                    var admin = new AdminLoginModel(userEntity);
                    Session.Add(Common.CommonConstants.ADMIN_LOGIN_SESSION, admin);
                    TempData.Add(Common.CommonConstants.SAVE_SUCCESSFULLY, true);
                }
                return RedirectToAction("Index");
            }
            var ad = (AdminLoginModel)Session[Common.CommonConstants.ADMIN_LOGIN_SESSION];
            ViewBag.AdminInfo = ad;
            Session.Add(Common.CommonConstants.TEMP_ADMIN_IMAGE, ad.Avatar);
            return View(user);
        }

        public JsonResult ChangePassword(String currentpass, String newpass)
        {
            var jsonCurrent = new JavaScriptSerializer().Deserialize<string>(currentpass);
            var jsonNew = new JavaScriptSerializer().Deserialize<string>(newpass);

            ScryptEncoder encoder = new ScryptEncoder();
            var admin = (AdminLoginModel)Session[Common.CommonConstants.ADMIN_LOGIN_SESSION];
            var user = db.Users.SingleOrDefault(model => model.Username == admin.Username);

            bool isValidPass = encoder.Compare(jsonCurrent, user.Password);

            if (isValidPass)
            {
                user.Password = encoder.Encode(jsonNew);
                db.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }

    }
}