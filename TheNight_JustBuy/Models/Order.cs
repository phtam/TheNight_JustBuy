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

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        [DisplayName("Order ID")]
        public int OrderID { get; set; }
        
        public Nullable<int> UserID { get; set; }
        [DisplayName("Created Date")]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Note { get; set; }
        public Nullable<int> Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DisplayName("Order Detail")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual User User { get; set; }
    }
}
