//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tms
{
    using System;
    using System.Collections.Generic;
    
    public partial class BusinessRuleTrigger
    {
        public int ID { get; set; }
        public Nullable<int> Action { get; set; }
        public Nullable<int> Value { get; set; }
        public Nullable<int> BusinessRuleID { get; set; }
    
        public virtual BusinessRule BusinessRule { get; set; }
    }
}
