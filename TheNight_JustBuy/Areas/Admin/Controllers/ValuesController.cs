using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TheNight_JustBuy.Models;

namespace TheNight_JustBuy.Areas.Admin.Controllers
{
    public class ValuesController : Controller
    {
        // GET: Admin/Values
        private JustBuyEntities db = new JustBuyEntities();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ActiveStatus(String userid)
        {
            var jsonUsername = new JavaScriptSerializer().Deserialize<int>(userid);
            var user = db.Users.Find(jsonUsername);
            user.Status = true;
            db.SaveChanges();
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DisableStatus(String userid)
        {
            var jsonUsername = new JavaScriptSerializer().Deserialize<int>(userid);
            var user = db.Users.Find(jsonUsername);
            user.Status = false;
            db.SaveChanges();
            return Json(new
            {
                status = true
            });
        }
    }
}