using Scrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheNight_JustBuy.Models;
using TheNight_JustBuy.ViewModels;

namespace TheNight_JustBuy.Controllers
{
    public class CustomerLoginController : Controller
    {
        private JustBuyEntities db = new JustBuyEntities();

        public ActionResult Index()
        {
            if (Session[Common.CommonConstants.USER_LOGIN_MODEL] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(CustomerLoginModel account)
        {
            if (ModelState.IsValid)
            {
                ScryptEncoder encoder = new ScryptEncoder();
                var user = db.Users.SingleOrDefault(model => model.Username == account.Username);
                if (user == null)
                {
                    ViewBag.LoginMessage = "Username or password is incorrect";
                    account.Password = "";
                    return View(account);
                }

                bool isValidPass = encoder.Compare(account.Password, user.Password);

                if (isValidPass)
                {
                    if (user.Role == true)
                    {
                        ViewBag.LoginMessage = "Username or password is incorrect";
                        account.Password = "";
                        return View(account);
                    }

                    if (user.Status == false)
                    {
                        ViewBag.LoginMessage = "Your account has been locked.";
                        account.Password = "";
                        return View(account);
                    }

                    var us = new CustomerInformation(user);
                    Session.Add(Common.CommonConstants.USER_LOGIN_MODEL, us);
                    TempData.Add(Common.CommonConstants.LOGIN_SUCCESSFULLY, true);
                    

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.LoginMessage = "Username or password is incorrect";
                    account.Password = "";
                    return View(account);
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove(Common.CommonConstants.USER_LOGIN_MODEL);
            TempData.Remove(Common.CommonConstants.LOGIN_SUCCESSFULLY);
            return RedirectToAction("Index", "Home");
        }
    }
}