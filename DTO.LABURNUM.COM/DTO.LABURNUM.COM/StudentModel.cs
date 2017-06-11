using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class StudentModel
    {
        public StudentModel()
        {
            this.ApiClientModel = new ApiClientModel();
            this.Classes = new List<ClassModel>();
            this.Salutations = new List<SalutationModel>();
            this.Sections = new List<SectionModel>();
            this.BusRoutes = new List<BusRouteModel>();
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

        public DTO.LABURNUM.COM.ApiClientModel ApiClientModel { get; set; }
        public List<DTO.LABURNUM.COM.ClassModel> Classes { get; set; }
        public List<DTO.LABURNUM.COM.SalutationModel> Salutations { get; set; }
        public List<DTO.LABURNUM.COM.SectionModel> Sections { get; set; }
        public List<DTO.LABURNUM.COM.BusRouteModel> BusRoutes { get; set; }

        public bool IsStudentLogin { get; set; }
        public string StudentFullName { get; set; }
        public string ClassName { get; set; }
        public string SectionName { get; set; }
        public string ClassStartWithName { get; set; }
        public bool IsRedirecting { get; set; }
        public string SalutationText { get; set; }

        public bool IsNewAdmission { get; set; }
        public long StudentFeeId { get; set; }

        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ReNewPassword { get; set; }

        public long AcademicYearId { get; set; }

        public List<DTO.LABURNUM.COM.AcademicYearTableModel> AcademicYearList { get; set; }
    }
}
