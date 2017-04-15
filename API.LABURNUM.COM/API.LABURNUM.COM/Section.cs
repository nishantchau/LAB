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
    
    public partial class Section
    {
        public Section()
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
            this.ClassSubjectFacultyTables = new HashSet<ClassSubjectFacultyTable>();
            this.Faculties = new HashSet<Faculty>();
            this.HomeWork = new HashSet<HomeWork>();
            this.Students = new HashSet<Student>();
            this.StudentFees = new HashSet<StudentFee>();
            this.StudentFeeDetails = new HashSet<StudentFeeDetail>();
        }
    
        public long SectionId { get; set; }
        public string SectionName { get; set; }
        public long ClassId { get; set; }
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
        public virtual Class Class { get; set; }
        public virtual ICollection<ClassSubjectFacultyTable> ClassSubjectFacultyTables { get; set; }
        public virtual ICollection<Faculty> Faculties { get; set; }
        public virtual ICollection<HomeWork> HomeWork { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<StudentFee> StudentFees { get; set; }
        public virtual ICollection<StudentFeeDetail> StudentFeeDetails { get; set; }
    }
}
