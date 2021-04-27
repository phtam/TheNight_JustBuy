using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheNight_JustBuy.CustomValidation;

namespace TheNight_JustBuy.Areas.Admin.Models
{
    public class ProductModelForCreate
    {
        public ProductModelForCreate()
        {

        }

        [DisplayName("Product ID")]
        public int ProductID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid product name!")]
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "The product name must be between 5 and 50 characters long.")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter unit price")]
        [Range(maximum: Int64.MaxValue, minimum: 1, ErrorMessage = "Unit price must be a number")]
        [DisplayName("Unit Price")]
        public Nullable<int> UnitPrice { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter old unit price")]
        [Range(maximum: Int64.MaxValue, minimum: 1, ErrorMessage = "Old unit price must be a number")]
        [DisplayName("Old Unit Price")]
        public Nullable<int> OldUnitPrice { get; set; }
        [DisplayName("Short Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter short description!")]
        [StringLength(maximumLength: 1000, MinimumLength = 5, ErrorMessage = "Short description must be between 5 and 100 characters long.")]
        public string ShortDescription { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter description!")]
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter unit in stock for this product!")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Unit in stock must be greater than 0.")]
        public Nullable<int> UnitsInStock { get; set; }
        [DisplayName("Launch Date")]
        [Required(ErrorMessage = "Please enter a valid launch date!")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}")]
        public Nullable<System.DateTime> LaunchDate { get; set; }
        public Nullable<int> VotedAverageMark { get; set; }
        [DisplayName("Supplier")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select a supplier for the product!")]
        public Nullable<int> SupplierID { get; set; }
        [DisplayName("Category")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select a category for the product!")]
        public Nullable<int> CategoryID { get; set; }
        public Nullable<bool> Status { get; set; }
        [ImageValidationForCreate]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}