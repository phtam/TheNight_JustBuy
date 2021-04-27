using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheNight_JustBuy.CustomValidation;
using TheNight_JustBuy.Models;

namespace TheNight_JustBuy.Areas.Admin.Models
{
    public class CategoryModelForEdit
    {
        public CategoryModelForEdit()
        {

        }
        public CategoryModelForEdit(Category category)
        {
            this.CategoryID = category.CategoryID;
            this.CategoryName = category.CategoryName;
            this.CategoryImage = category.CategoryImage;
        }
        [DisplayName("Category ID")]
        public int CategoryID { get; set; }



        [DisplayName("Category Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid category name!")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "The category name must be between 3 and 50 characters long.")]
        public string CategoryName { get; set; }

        [DisplayName("Image")]
        public string CategoryImage { get; set; }
        [ImageValidationForUpdate]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}