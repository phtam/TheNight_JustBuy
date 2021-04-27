using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheNight_JustBuy.Models;

namespace TheNight_JustBuy.ViewModels
{
    [Serializable]
    public class Cart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public long OldTotal { get; set; }
        public long NewTotal { get; set; }
    }
}