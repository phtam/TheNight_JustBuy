using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheNight_JustBuy.CustomValidation;
using TheNight_JustBuy.Models;

namespace TheNight_JustBuy.ViewModels
{
    public class CustomerInformation
    {
        public CustomerInformation()
        {
        }
        public CustomerInformation(User user)
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
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid first name!")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "The first name must be between 3 and 20 characters long.")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid last name!")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "The last name must be between 3 and 20 characters long.")]
        public string LastName { get; set; }
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter a valid credit card!")]
        [StringLength(maximumLength: 30, MinimumLength = 8, ErrorMessage = "The credit card must be between 8 and 30 characters long.")]
        public string CreditCard { get; set; }
        public Nullable<bool> Gender { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The date of birth must be not empty.")]
        [DataType(DataType.Date, ErrorMessage = "The date of birth must be date.")]
        [DOBValidation]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of birth")]
        public Nullable<System.DateTime> Birthday { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid phone number!")]
        [StringLength(maximumLength: 15, MinimumLength = 3, ErrorMessage = "Phone number must be between 3 and 20 characters long.")]
        [RegularExpression(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$", ErrorMessage = "The phone number is incorrect format. Try again, please!")]
        public string Phone { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid email!")]
        [StringLength(maximumLength: 60, MinimumLength = 6, ErrorMessage = "The email must be between 6 and 50 characters long.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "The email is incorrect format. Try again, please!")]
        public string Email { get; set; }
        public string Avatar { get; set; }
        public Nullable<bool> Role { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Cart { get; set; }
        [ImageValidationForUpdate]
        public HttpPostedFileBase EditedImage { get; set; }
    
}
}