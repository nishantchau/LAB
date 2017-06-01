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
    
    public partial class Student
    {
        public Student()
        {
            this.AttendanceClass1 = new HashSet<AttendanceClass1>();
            this.AttendanceClass10 = new HashSet<AttendanceClass10>();
            this.AttendanceClass11 = new HashSet<AttendanceClass11>();
            this.AttendanceClass12 = new HashSet<AttendanceClass12>();
            this.AttendanceClass2 = new HashSet<AttendanceClass2>();
            this.AttendanceClass3 = new HashSet<AttendanceClass3>();
            this.AttendanceClass4 = new HashSet<AttendanceClass4>();
            this.AttendanceClass5 = new HashSet<AttendanceClass5>();
            this.AttendanceClass6 = new HashSet<AttendanceClass6>();
            this.AttendanceClass7 = new HashSet<AttendanceClass7>();
            this.AttendanceClass8 = new HashSet<AttendanceClass8>();
            this.AttendanceClass9 = new HashSet<AttendanceClass9>();
            this.AttendanceClassLKGs = new HashSet<AttendanceClassLKG>();
            this.AttendanceClassPreNurseries = new HashSet<AttendanceClassPreNursery>();
            this.AttendanceClassUKGs = new HashSet<AttendanceClassUKG>();
            this.StudentFees = new HashSet<StudentFee>();
            this.StudentFeeDetails = new HashSet<StudentFeeDetail>();
        }
    
        public long StudentId { get; set; }
        public string AdmissionNumber { get; set; }
        public string StudentPhoto { get; set; }
        public long ClassId { get; set; }
        public long ClassStartWithId { get; set; }
        public long SectionId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public long SalutationId { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public System.DateTime DOB { get; set; }
        public string Landline { get; set; }
        public string StudentAadharNumber { get; set; }
        public string FatherName { get; set; }
        public string FatherMobile { get; set; }
        public string FatherProfession { get; set; }
        public string PAN { get; set; }
        public string FatherAadharNumber { get; set; }
        public string MotherName { get; set; }
        public string MotherMobile { get; set; }
        public string MotherProfession { get; set; }
        public string MotherAadharNumber { get; set; }
        public bool IsTransportRqd { get; set; }
        public long BusRouteId { get; set; }
        public string StudentUserName { get; set; }
        public string StudentPassword { get; set; }
        public string ParentUserName { get; set; }
        public string ParentPassword { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    
        public virtual ICollection<AttendanceClass1> AttendanceClass1 { get; set; }
        public virtual ICollection<AttendanceClass10> AttendanceClass10 { get; set; }
        public virtual ICollection<AttendanceClass11> AttendanceClass11 { get; set; }
        public virtual ICollection<AttendanceClass12> AttendanceClass12 { get; set; }
        public virtual ICollection<AttendanceClass2> AttendanceClass2 { get; set; }
        public virtual ICollection<AttendanceClass3> AttendanceClass3 { get; set; }
        public virtual ICollection<AttendanceClass4> AttendanceClass4 { get; set; }
        public virtual ICollection<AttendanceClass5> AttendanceClass5 { get; set; }
        public virtual ICollection<AttendanceClass6> AttendanceClass6 { get; set; }
        public virtual ICollection<AttendanceClass7> AttendanceClass7 { get; set; }
        public virtual ICollection<AttendanceClass8> AttendanceClass8 { get; set; }
        public virtual ICollection<AttendanceClass9> AttendanceClass9 { get; set; }
        public virtual ICollection<AttendanceClassLKG> AttendanceClassLKGs { get; set; }
        public virtual ICollection<AttendanceClassPreNursery> AttendanceClassPreNurseries { get; set; }
        public virtual ICollection<AttendanceClassUKG> AttendanceClassUKGs { get; set; }
        public virtual BusRoute BusRoute { get; set; }
        public virtual Class Class { get; set; }
        public virtual Class Class1 { get; set; }
        public virtual Salutation Salutation { get; set; }
        public virtual Section Section { get; set; }
        public virtual ICollection<StudentFee> StudentFees { get; set; }
        public virtual ICollection<StudentFeeDetail> StudentFeeDetails { get; set; }
    }
}
