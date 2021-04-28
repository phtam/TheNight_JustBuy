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

            ViewBag.Latest = db.Products.Where(m => m.Status == true).OrderByDescending(m => m.ProductID).Take(8).ToList();
            ViewBag.Expensive = db.Products.OrderByDescending(m => m.UnitPrice).FirstOrDefault(m => m.Status == true);
            ViewBag.Blog = db.Blogs.Where(m => m.Status == 1).OrderByDescending(m => m.BlogID).Take(8).ToList();
            ViewBag.ListCheap = db.Products.Where(m => m.Status == true).OrderByDescending(m => m.UnitPrice).Take(8).ToList();


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
        [ChildActionOnly]
        public ActionResult FooterClient()
        {
            ViewBag.FCategoryList = db.Categories.ToList();
            ViewBag.FBlogCategoryList = db.BlogCategories.ToList();
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