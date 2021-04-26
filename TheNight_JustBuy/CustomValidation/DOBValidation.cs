using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheNight_JustBuy.CustomValidation
{
    public class DOBValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Date of birth must be not empty.");
            }
            DateTime dob = Convert.ToDateTime(value);
            if ((DateTime.Now.Year - dob.Year) == 14)
            {
                if ((DateTime.Now.Month - dob.Month) == 0)
                {
                    if ((DateTime.Now.Day - dob.Day) > 0)
                    {
                        return new ValidationResult("Age must greater than 14 years old.");
                    }
                }
                else if ((DateTime.Now.Month - dob.Month) > 0)
                {
                    return new ValidationResult("Age must greater than 14 years old.");
                }
            }
            else if ((DateTime.Now.Year - dob.Year) < 14)
            {
                return new ValidationResult("Age must greater than 14 years old.");
            }
            return ValidationResult.Success;

        }
    }
}