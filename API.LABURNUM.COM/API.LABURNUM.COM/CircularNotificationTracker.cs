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
    
    public partial class CircularNotificationTracker
    {
        public long CircularNotificationTrackerId { get; set; }
        public long CircularId { get; set; }
        public System.DateTime ReadOn { get; set; }
        public long UserId { get; set; }
        public long UserTypeId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    
        public virtual Circular Circular { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
