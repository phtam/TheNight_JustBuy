using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheNight_JustBuy.ViewModels
{
    public class CustomerLoginModel
    {
        [Key]
        [Required(ErrorMessage = "Username must be not empty")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password must be not empty")]
        public string Password { get; set; }
    }
}