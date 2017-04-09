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
    
    public partial class StudentFee
    {
        public long StudentFeeId { get; set; }
        public long StudentId { get; set; }
        public long ClassId { get; set; }
        public long SectionId { get; set; }
        public long AdmissionTypeId { get; set; }
        public double AdmissionFee { get; set; }
        public double DevelopementFee { get; set; }
        public double AnnualCharges { get; set; }
        public double ExamFee { get; set; }
        public double SportsFee { get; set; }
        public double SecurityFee { get; set; }
        public double DiscountAmount { get; set; }
        public string DiscountRemarks { get; set; }
        public long CollectedById { get; set; }
        public long AcademicYearId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    
        public virtual AcademicYearTable AcademicYearTable { get; set; }
        public virtual AdmissionType AdmissionType { get; set; }
        public virtual Class Class { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual Section Section { get; set; }
        public virtual Student Student { get; set; }
    }
}
