using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheNight_JustBuy.Models;

namespace TheNight_JustBuy.CustomValidation
{
    public class ExistedUsername : ValidationAttribute
    {
        private JustBuyEntities db = new JustBuyEntities();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Please enter a valid username.");
            }
            if (value.ToString().Length < 6 || value.ToString().Length > 50)
            {
                return new ValidationResult("The username must be between 6 and 50 characters long.");
            }
            if (db.Users.FirstOrDefault(m => m.Username == value.ToString()) != null)
            {
                return new ValidationResult("The username '" + value + "' already exists. Try again, please!");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}