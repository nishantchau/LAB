//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.LABURNUM.COM
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoginActivity
    {
        public long LoginActivityId { get; set; }
        public long StudentId { get; set; }
        public long UserTypeId { get; set; }
        public System.DateTime LoginAt { get; set; }
        public Nullable<System.DateTime> LogoutAt { get; set; }
        public long ClientId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    
        public virtual ApiClient ApiClient { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
