using Scrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TheNight_JustBuy.Models;
using TheNight_JustBuy.ViewModels;

namespace TheNight_JustBuy.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private JustBuyEntities db = new JustBuyEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminLoginModel account)
        {
            if (ModelState.IsValid)
            {
                ScryptEncoder encoder = new ScryptEncoder();
                var user = db.Users.SingleOrDefault(model => model.Username == account.Username);
                if (user == null)
                {
                    ViewBag.ErrorLogin = "Username or password is incorrect";
                    account.Password = "";
                    return View(account);
                }
                bool isValidPass = encoder.Compare(account.Password, user.Password);
                if (isValidPass)
                {
                    if (user.Status == false)
                    {
                        ViewBag.ErrorLogin = "Your account has been locked.";
                        account.Password = "";
                        return View(account);
                    }

                    if (user.Role == false)
                    {
                        ViewBag.ErrorLogin = "Username or password is incorrect.";
                        return View(account);
                    }

                    FormsAuthentication.SetAuthCookie(user.Username, false);

                    var admin = new AdminLoginModel(user);

                    Session.Add(Common.CommonConstants.ADMIN_LOGIN_SESSION, admin);
                    TempData.Add(Common.CommonConstants.LOGIN_SUCCESSFULLY, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorLogin = "Username or password is incorrect";
                    account.Password = "";
                    return View(account);
                }
            }
                return View();
            }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove(Common.CommonConstants.ADMIN_LOGIN_SESSION);
            TempData.Remove(Common.CommonConstants.LOGIN_SUCCESSFULLY);
            return Redirect("Index");
        }
    }
}