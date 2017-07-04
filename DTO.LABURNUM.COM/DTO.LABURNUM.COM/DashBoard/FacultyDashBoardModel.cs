using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM.DashBoard
{
    public class FacultyDashBoardModel
    {
        public FacultyDashBoardModel()
        {
            this.ClassAttendanceStatus = new ClassAttendanceStatus();
        }

        public ClassAttendanceStatus ClassAttendanceStatus { get; set; }
    }

    public class ClassAttendanceStatus
    {
        public int TotalStudents { get; set; }
        public int MorningPresentStudentCount { get; set; }
        public int MorningAbsentStudentCount { get; set; }
        public int LunchPresentStudentCount { get; set; }
        public int LunchAbsentStudentCount { get; set; }
    }
}
