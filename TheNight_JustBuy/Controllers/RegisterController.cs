using Scrypt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheNight_JustBuy.Models;
using TheNight_JustBuy.ViewModels;

namespace TheNight_JustBuy.Controllers
{
    public class RegisterController : Controller
    {
        private JustBuyEntities db = new JustBuyEntities();
        // GET: Register
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "UserID,Username,FirstName,LastName,Password,CreditCard,Gender,Birthday,Phone,Email,Avatar,ImageFile")] UserRegisterModel user)
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
                user.Role = false; //  => cus
                user.Status = true;

                var userEntity = new User(user);

                db.Users.Add(userEntity);

                if (db.SaveChanges() > 0)
                    ViewBag.Mess = "Dang ky ok";
                   
                return View();
            }

            return View();
        }
    }
}