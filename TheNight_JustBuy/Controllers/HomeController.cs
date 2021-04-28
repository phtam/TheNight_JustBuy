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
            ViewBag.SupplierList = db.Suppliers.ToList();
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

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Contact(string FullName, string Subject, string Email, string Content)
        {
            if (FullName == "")
            {
                ViewBag.Fullname = "Do not be empty!";
                return View();
            }
            if(Subject == "")
            {
                ViewBag.Subject = "Do not be empty!";
                return View();
            }
            if (Email == "")
            {
                ViewBag.Email = "Do not be empty! Must be in the correct format!";
                return View();
            }
            if (Subject == "")
            {
                ViewBag.Subject = "Do not be empty!";
                return View();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var f = new Feedback();
                    f.FullName = FullName;
                    f.Subject = Subject;
                    f.Email = Email;
                    f.Content = Content;
                    db.Feedbacks.Add(f);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return View();
                }
            }
            ViewBag.Mess = "Submitted successfully!";
            return View();
        }
    }
}