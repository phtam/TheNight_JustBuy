using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TheNight_JustBuy.Common;
using TheNight_JustBuy.Models;
using TheNight_JustBuy.ViewModels;

namespace TheNight_JustBuy.Controllers
{
    public class CartController : Controller
    {
        private JustBuyEntities db = new JustBuyEntities();

        public ActionResult Index()
        {
            var cart = Session[CommonConstants.CART_SESSION];
            var list = new List<Cart>();
            if (cart != null)
            {
                list = (List<Cart>)cart;
            }
            long price = 0;
            long old_price = 0;
            foreach (var item in list)
            {
                price += (long)(item.Product.UnitPrice * item.Quantity);
                old_price += (long)(item.Product.OldUnitPrice * item.Quantity);
                item.OldTotal = (long)(item.Product.UnitPrice * item.Quantity);
                item.NewTotal = (long)(item.Product.OldUnitPrice * item.Quantity);
            }
            ViewBag.Price = price;
            ViewBag.OldPrice = old_price;
            return View(list);
        }

        public ActionResult AddItem(int productID, int quantity)
        {
            var product = db.Products.Find(productID);
            var cart = Session[CommonConstants.CART_SESSION];
            if (cart != null)
            {
                var list = (List<Cart>)cart;
                if (list.Exists(x => x.Product.ProductID == productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ProductID == productID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new Cart();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CommonConstants.CART_SESSION] = list;
            }
            else
            {
                var item = new Cart();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<Cart>();
                list.Add(item);
                Session[CommonConstants.CART_SESSION] = list;
            }

            return RedirectToAction("Index");

        }

        public ActionResult Delete(long id)
        {
            var sessionCart = (List<Cart>)Session[CommonConstants.CART_SESSION];
            sessionCart.RemoveAll(x => x.Product.ProductID == id);
            Session[CommonConstants.CART_SESSION] = sessionCart;
            return RedirectToAction("Index");
        }

        public JsonResult DeleteAll()
        {
            Session[CommonConstants.CART_SESSION] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<Cart>>(cartModel);
            var sessionCart = (List<Cart>)Session[CommonConstants.CART_SESSION];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ProductID == item.Product.ProductID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
                if (item.Quantity == 0)
                {
                    sessionCart.Remove(item);
                }
            }
            Session[CommonConstants.CART_SESSION] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public ActionResult CheckOut()
        {
            if (Session[Common.CommonConstants.USER_LOGIN_MODEL] == null)
            {
                return RedirectToAction("Index", "CustomerLogin");
            }
            var cart = Session[CommonConstants.CART_SESSION];

            var list = new List<Cart>();
            if (cart != null)
            {
                list = (List<Cart>)cart;
            }
            long total = 0;
            foreach (var item in list)
            {
                total += (long)(item.Product.UnitPrice * item.Quantity);
            }
            ViewBag.TotalTogether = total;
            return View(list);
        }

        [HttpPost]
        public ActionResult CheckOut(string Note)
        {
            if (Session[Common.CommonConstants.USER_LOGIN_MODEL] == null)
            {
                return RedirectToAction("Index", "CustomerLogin");
            }
            var cus = (CustomerInformation)Session[Common.CommonConstants.USER_LOGIN_MODEL];
            var order = new Order();
            order.UserID = cus.UserID;
            order.Note = Note;
            order.CreatedDate = DateTime.Now;
            order.Status = 0;

            try
            {
                var id = db.Orders.Add(order).OrderID;
                var cart = (List<Cart>)Session[CommonConstants.CART_SESSION];
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.OrderID = id;
                    orderDetail.ProductID = item.Product.ProductID;
                    orderDetail.UnitPrice = item.Product.UnitPrice;
                    orderDetail.Quantity = item.Quantity;

                    if (db.Products.Find(item.Product.ProductID).UnitsInStock < item.Quantity)
                    {
                        TempData["CheckoutMessage"] = orderDetail.Product.ProductName + "is in stock less than the quantity you ordered!";
                        return RedirectToAction("Checkout");
                    }
                    db.OrderDetails.Add(orderDetail);
                }
                db.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Cart");
            }
            Session[CommonConstants.CART_SESSION] = null;
            return RedirectToAction("Success");
        }

        public JsonResult AddMultiItem(int productID, int quantity)
        {
            var product = db.Products.Find(productID);
            var cart = Session[CommonConstants.CART_SESSION];
            if (cart != null)
            {
                var list = (List<Cart>)cart;
                if (list.Exists(x => x.Product.ProductID == productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ProductID == productID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new Cart();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CommonConstants.CART_SESSION] = list;
            }
            else
            {
                var item = new Cart();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<Cart>();
                list.Add(item);
                Session[CommonConstants.CART_SESSION] = list;
            }
            return Json(new
            {
                status = true
            });
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}