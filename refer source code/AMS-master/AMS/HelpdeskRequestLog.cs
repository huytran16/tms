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
    
    public partial class HelpdeskRequestLog
    {
        public int Id { get; set; }
        public Nullable<int> HelpdeskRequestId { get; set; }
        public Nullable<int> ChangeFromUserId { get; set; }
        public Nullable<int> AssignToUserId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> StatusFrom { get; set; }
        public Nullable<int> StatusTo { get; set; }
        public Nullable<System.DateTime> DeadLine { get; set; }
    
        public virtual HelpdeskRequest HelpdeskRequest { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
