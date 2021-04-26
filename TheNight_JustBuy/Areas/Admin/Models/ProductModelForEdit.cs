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
    public class ProductModelForEdit
    {
        public ProductModelForEdit()
        {

        }

        public ProductModelForEdit(Product product)
        {
            this.ProductID = product.ProductID;
            this.ProductName = product.ProductName;
            this.UnitPrice = product.UnitPrice;
            this.OldUnitPrice = product.OldUnitPrice;
            this.ShortDescription = product.ShortDescription;
            this.Description = product.Description;
            this.Thumbnail = product.Thumbnail;
            this.UnitsInStock = product.UnitsInStock;
            this.LaunchDate = product.LaunchDate;
            this.VotedAverageMark = product.VotedAverageMark;
            this.SupplierID = product.SupplierID;
            this.CategoryID = product.CategoryID;
            this.Status = product.Status;
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
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public Nullable<int> UnitsInStock { get; set; }
        [DisplayName("Launch Date")]
        [Required(ErrorMessage = "Please enter a valid date!")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}")]
        public Nullable<System.DateTime> LaunchDate { get; set; }
        public Nullable<int> VotedAverageMark { get; set; }
        [DisplayName("Supplier")]
        public Nullable<int> SupplierID { get; set; }
        [DisplayName("Category")]
        public Nullable<int> CategoryID { get; set; }
        [DisplayName("Discount")]
        public Nullable<bool> Status { get; set; }
        [ImageValidationForUpdate]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}