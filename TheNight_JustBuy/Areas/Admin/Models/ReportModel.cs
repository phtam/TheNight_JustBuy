using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TheNight_JustBuy.Areas.Admin.Models
{
    public class ReportModel
    {
        [DisplayName("Registered Members")]
        public int UserRegistration { get; set; }

        [DisplayName("Order Total")]
        public int OrderTotal { get; set; }

        [DisplayName("Product Total")]
        public int ProductTotal { get; set; }

        public long Proceeds { get; set; }

        [DisplayName("Total sales last 7 days")]
        public long WeekProceeds { get; set; }

        [DisplayName("Total sales last 30 days")]
        public long MonthProceeds { get; set; }

        [DisplayName("Total sales last 1 day")]
        public long ToDayProceeds { get; set; }

        [DisplayName("Comment Total")]
        public int TotalComments { get; set; }

        [DisplayName("Blog Total")]
        public int TotalBlogs { get; set; }

        [DisplayName("Supplier Total")]
        public int SupplierTotal { get; set; }

        [DisplayName("Feedback Total")]
        public int FeedbackTotal { get; set; }
    }
}