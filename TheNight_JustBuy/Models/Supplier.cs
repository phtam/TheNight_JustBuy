//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TheNight_JustBuy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            this.Products = new HashSet<Product>();
        }

        [DisplayName("Supplier ID")]
        public int SupplierID { get; set; }


        [DisplayName("CompanyName")]
        public string CompanyName { get; set; }


        [DisplayName("Contact Name")]
        public string ContactName { get; set; }


        
        public string Address { get; set; }


        [StringLength(maximumLength: 15, MinimumLength = 3, ErrorMessage = "Phone number must be between 3 and 15 characters long.")]
        [RegularExpression(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$", ErrorMessage = "The phone number is incorrect format. Try again, please!")]
        public string Phone { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid email!")]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "The email must be between 5 and 30 characters long.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "The email is incorrect format. Try again, please!")]
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
