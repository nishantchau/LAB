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
    
    public partial class Event
    {
        public long EventId { get; set; }
        public long EventTypeId { get; set; }
        public long AcademicYearId { get; set; }
        public string EventName { get; set; }
        public string Classes { get; set; }
        public System.DateTime EventDate { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    
        public virtual AcademicYearTable AcademicYearTable { get; set; }
        public virtual EventType EventType { get; set; }
    }
}
