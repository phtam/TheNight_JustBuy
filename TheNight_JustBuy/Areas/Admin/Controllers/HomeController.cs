using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheNight_JustBuy.Areas.Admin.Models;
using TheNight_JustBuy.Models;
using TheNight_JustBuy.ViewModels;

namespace TheNight_JustBuy.Areas.Admin.Controllers
{
    [Authorize(Roles = "true")]
    public class HomeController : BaseController
    {
        private JustBuyEntities db = new JustBuyEntities();
        public ActionResult Index()
        {
            ReportModel report = CreateReport();

            var chartList = DrawSaleChart();
            ViewBag.LabelSaleChart = chartList.Select(x => x.Label.ToShortDateString());
            ViewBag.SaleChart = chartList.Select(x => x.Total);

            var cateChart = DrawCategoriesChart();
            ViewBag.CateLabel = cateChart.Select(x => x.Label);
            ViewBag.CateData = cateChart.Select(x => x.Quantity);

            ViewBag.RencentlyBlog = GetRecentlyAddedBlogs();
            ViewBag.RecentlyOrders = GetRecentlyOrder();

            return View(report);
        }

        [ChildActionOnly]
        public ActionResult Aside()
        {
            var admin = (AdminLoginModel)Session[Common.CommonConstants.ADMIN_LOGIN_SESSION];
            ViewBag.FullName = admin.FirstName + " " + admin.LastName;
            ViewBag.Avatar = admin.Avatar;
            ViewBag.UserRole = admin.Role;
            return PartialView();
        }

        private List<CategoryChart> DrawCategoriesChart()
        {
            List<CategoryChart> cateChart = new List<CategoryChart>();
            foreach (var item in db.Categories.ToList())
            {
                CategoryChart chart = new CategoryChart();
                chart.Label = item.CategoryName;
                chart.Quantity = item.Products.Count;
                cateChart.Add(chart);
            }

            return cateChart;
        }

        private List<MainChart> DrawSaleChart()
        {
            DateTime today = DateTime.Today;
            List<MainChart> chartList = new List<MainChart>();
            for (int i = 15; i >= 0; i--)
            {
                MainChart chart = new MainChart();
                chart.Label = today.AddDays(-(i + 1));
                DateTime end = today.AddDays(-i);
                DateTime start = today.AddDays(-(i + 1));
                chartList.Add(chart);
                db.OrderDetails.Where(n => n.Order.CreatedDate >= start && n.Order.CreatedDate < end).ToList().ForEach(item => chart.Total += (long)(item.UnitPrice*item.Quantity));
            }
            return chartList;
        }

        private ReportModel CreateReport()
        {
            var report = new ReportModel();
            report.UserRegistration = db.Users.Where(u => u.Role == false).ToList().Count;
            report.OrderTotal = db.Orders.ToList().Count;
            report.ProductTotal = db.Products.ToList().Count;
            report.Proceeds = 0;
            db.OrderDetails.ToList().ForEach(item => report.Proceeds += (long)(item.UnitPrice*item.Quantity));
            DateTime today = DateTime.Today;
            DateTime sevenDayAgo = today.AddDays(-7);
            db.OrderDetails.Where(i => i.Order.CreatedDate >= sevenDayAgo).ToList().ForEach(item => report.WeekProceeds += (long)(item.UnitPrice * item.Quantity));
            DateTime thirtyDayAgo = today.AddDays(-30);
            DateTime tomorrow = today.AddDays(-1);
            db.OrderDetails.Where(i => i.Order.CreatedDate >= thirtyDayAgo).ToList().ForEach(item => report.MonthProceeds += (long)(item.UnitPrice * item.Quantity));
            db.OrderDetails.Where(i => i.Order.CreatedDate >= tomorrow).ToList().ForEach(item => report.ToDayProceeds += (long)(item.UnitPrice * item.Quantity));
            report.TotalComments = db.ProductComments.ToList().Count + db.BlogComments.ToList().Count;
            report.TotalBlogs = db.Blogs.ToList().Count;
            report.SupplierTotal = db.Suppliers.ToList().Count;
            report.FeedbackTotal = db.Feedbacks.ToList().Count;
            return report;
        }

        private List<Blog> GetRecentlyAddedBlogs()
        {
            return db.Blogs.Where(b => b.Status == 1).OrderByDescending(b => b.CreatedDate).Take(5).ToList();
        }

        private List<Order> GetRecentlyOrder()
        {
            return db.Orders.Where(o => o.Status == 1).OrderByDescending(o => o.CreatedDate).Take(8).ToList();
        }
    }
}