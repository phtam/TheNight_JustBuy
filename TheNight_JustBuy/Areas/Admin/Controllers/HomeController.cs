using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheNight_JustBuy.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Aside()
        {
            ViewBag.FullName = "Phạm Hoàng Tâm";
            ViewBag.Avatar = "";
            return PartialView();
        }
    }
}