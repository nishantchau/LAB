using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class AttendanceClass8Model
    {
         public AttendanceClass8Model()
        {
            this.ApiClientModel = new ApiClientModel();
        }

        public long AttendanceClass8Id { get; set; }
        public long StudentId { get; set; }
        public long ClassId { get; set; }
        public long SectionId { get; set; }
        public long FacultyId { get; set; }
        public System.DateTime MorningAttendanceDate { get; set; }
        public Nullable<System.DateTime> LunchAttendanceDate { get; set; }
        public bool IsPresentInMorning { get; set; }
        public bool IsPresentAfterLuch { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string AdmissionNumber { get; set; }
        public long AttendanceId { get; set; }

        public ApiClientModel ApiClientModel { get; set; }
    }
}
