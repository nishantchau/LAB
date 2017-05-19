using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class SessionModel
    {
        public SessionModel()
        {
            this.StudentModel = new StudentModel();
            this.FacultyModel = new FacultyModel();
        }

        public DTO.LABURNUM.COM.StudentModel StudentModel { get; set; }
        public DTO.LABURNUM.COM.FacultyModel FacultyModel { get; set; }
        public long LoginBy { get; set; }
        public long LoginByUserId { get; set; }
        public long LoginActivityId { get; set; }
        public string AcademicYear { get; set; }
        public long AcademicYearId { get; set; }
        public DateTime LastLoginAt { get; set; }
    }
}
