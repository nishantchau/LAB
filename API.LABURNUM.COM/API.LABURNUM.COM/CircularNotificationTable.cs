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
    
    public partial class CircularNotificationTable
    {
        public long CircularNotificationTableId { get; set; }
        public long CircularId { get; set; }
        public bool IsForFaculty { get; set; }
        public bool IsForParents { get; set; }
        public bool IsForStudent { get; set; }
        public bool IsForAdmin { get; set; }
        public string ClassIds { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    
        public virtual Circular Circular { get; set; }
    }
}
