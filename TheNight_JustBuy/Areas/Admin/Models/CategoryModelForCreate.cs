using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheNight_JustBuy.CustomValidation;

namespace TheNight_JustBuy.Areas.Admin.Models
{
    public class CategoryModelForCreate
    {
        public CategoryModelForCreate()
        {

        }
        [DisplayName("Category ID")]
        public int CategoryID { get; set; }



        [DisplayName("Category Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid category name!")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "The category name must be between 3 and 50 characters long.")]
        public string CategoryName { get; set; }

        [DisplayName("Image")]
        public string CategoryImage { get; set; }
        [ImageValidationForCreate]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}