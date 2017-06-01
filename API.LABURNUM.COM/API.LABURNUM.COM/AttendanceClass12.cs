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
    
    public partial class AttendanceClass12
    {
        public long AttendanceClass12Id { get; set; }
        public long StudentId { get; set; }
        public long ClassId { get; set; }
        public long SectionId { get; set; }
        public long FacultyId { get; set; }
        public System.DateTime MorningAttendanceDate { get; set; }
        public bool IsPresentInMorning { get; set; }
        public bool IsPresentAfterLuch { get; set; }
        public Nullable<System.DateTime> LunchAttendanceDate { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    
        public virtual Class Class { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual Section Section { get; set; }
        public virtual Student Student { get; set; }
    }
}
