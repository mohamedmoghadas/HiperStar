//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HiperStar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerProjectTicket
    {
        public long Id { get; set; }
        public long IdCustomer { get; set; }
        public long IdProduct { get; set; }
        public string Message { get; set; }
        public System.DateTime dateinsert { get; set; }
        public Nullable<System.DateTime> daterespond { get; set; }
        public Nullable<System.DateTime> datedelete { get; set; }
        public long IdUnit { get; set; }
        public string ResponseMessage { get; set; }
        public Nullable<long> IdUserRespond { get; set; }
        public Nullable<long> IdUserDelete { get; set; }
        public Nullable<bool> Statedelete { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
