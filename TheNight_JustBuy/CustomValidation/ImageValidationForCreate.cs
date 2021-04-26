using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace TheNight_JustBuy.CustomValidation
{
    public class ImageValidationForCreate :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("The image file is required. Please select a file for this field!");
            }
            HttpPostedFileBase file = (HttpPostedFileBase)value;
            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            if ((extension == ".png" || extension == ".jpg" || extension == ".jpeg") == false)
            {
                return new ValidationResult("The File, which has extension is " + extension + ", hasn't accepted. The extension of the image must be .png or .jpg or .jpeg.");
            }

            long fileSize = ((file.ContentLength) / 1024);
            if (fileSize > 5120)
            {
                return new ValidationResult("The File, which size greater than 5MB, hasn't accepted. Please try again!");
            }
            return ValidationResult.Success;

        }
    }
}