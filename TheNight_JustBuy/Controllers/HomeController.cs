using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheNight_JustBuy.Models;
using TheNight_JustBuy.ViewModels;

namespace TheNight_JustBuy.Controllers
{
    public class HomeController : Controller
    {
        private JustBuyEntities db = new JustBuyEntities();
        public ActionResult Index()
        {
            List<Configuration> slidebar = db.Configurations.Where(c => c.ConfigName.Contains("slidebar")).ToList();
            ViewBag.Slidebar = slidebar;

            return View();
        }

        [ChildActionOnly]
        public ActionResult HeaderClient()
        {
            ViewBag.CategoryList = db.Categories.ToList();
            ViewBag.BlogCategoryList = db.BlogCategories.ToList();
            var user = (CustomerInformation)Session[Common.CommonConstants.USER_LOGIN_MODEL];
            var cart = (List<Cart>)Session[Common.CommonConstants.CART_SESSION];
            int itemQty = 0;
            int total = 0;
            if (cart != null)
            {
                ViewBag.Items = cart.Count;
                foreach (var item in cart)
                {
                    itemQty += item.Quantity;
                    total += (int)(item.Product.UnitPrice * item.Quantity);
                }
            }
            ViewBag.ItemQuantity = itemQty;
            ViewBag.Total = total;
            
            if (user == null)
            {
                ViewBag.IsLoggedIn = false;
            }
            else
            {
                ViewBag.IsLoggedIn = true;
                ViewBag.CustomerFullName = user.FirstName + " " + user.LastName;
            }

            return PartialView();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}