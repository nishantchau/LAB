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
        }

        public long AttendanceId { get; set; }
        public long ClassId { get; set; }
        public long SectionId { get; set; }
        public long StudentId { get; set; }
        public long FacultyId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string StudentName { get; set; }

        public ApiClientModel ApiClientModel { get; set; }
    }
}
