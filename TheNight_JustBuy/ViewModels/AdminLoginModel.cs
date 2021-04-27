using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheNight_JustBuy.Models;

namespace TheNight_JustBuy.ViewModels
{
    public class AdminLoginModel
    {
        public AdminLoginModel()
        {

        }
        public AdminLoginModel(User user)
        {
            this.UserID = user.UserID;
            this.Username = user.Username;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Password = user.Password;
            this.CreditCard = user.CreditCard;
            this.Gender = user.Gender;
            this.Birthday = user.Birthday;
            this.Phone = user.Phone;
            this.Email = user.Email;
            this.Avatar = user.Avatar;
            this.Role = user.Role;
            this.Status = user.Status;
            this.Cart = user.Cart;
        }
        public int UserID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your username!")]
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your password!")]
        public string Password { get; set; }
        public string CreditCard { get; set; }
        public Nullable<bool> Gender { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public Nullable<bool> Role { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Cart { get; set; }
        public HttpPostedFileBase EditedImage { get; set; }
    }
}