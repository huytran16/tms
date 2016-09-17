//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReceiptDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReceiptDetail()
        {
            this.Transactions = new HashSet<Transaction>();
        }
    
        public int Id { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> UtilityServiceId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
        public Nullable<int> FromNumber { get; set; }
        public Nullable<int> ToNumber { get; set; }
        public Nullable<int> ReceiptId { get; set; }
    
        public virtual Receipt Receipt { get; set; }
        public virtual UtilityService UtilityService { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}