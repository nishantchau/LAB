using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class CommonAttendanceModel
    {
        public CommonAttendanceModel()
        {
            this.ApiClientModel = new ApiClientModel();
            this.Classes = new List<ClassModel>();
            this.Sections = new List<SectionModel>();
            this.Months = new List<MonthModel>();
        }

        public long AttendanceId { get; set; }
        public long ClassId { get; set; }
        public long SectionId { get; set; }
        public long StudentId { get; set; }
        public long FacultyId { get; set; }
        public System.DateTime MorningAttendanceDate { get; set; }
        public System.DateTime? LunchAttendanceDate { get; set; }
        public bool IsPresentInMorning { get; set; }
        public bool IsPresentAfterLuch { get; set; }
        

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string AdmissionNumber { get; set; }
        public string Mobile { get; set; }
        public int MonthId { get; set; }
        public List<DTO.LABURNUM.COM.MonthModel> Months { get; set; }

        public ApiClientModel ApiClientModel { get; set; }
        public List<ClassModel> Classes { get; set; }
        public List<SectionModel> Sections { get; set; }
    }
}
