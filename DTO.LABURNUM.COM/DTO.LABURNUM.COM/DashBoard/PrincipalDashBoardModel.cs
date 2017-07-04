using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM.DashBoard
{
    public class PrincipalDashBoardModel
    {
        public PrincipalDashBoardModel()
        {
            this.StudentSummary = new StudentSummary();
            this.StaffSummary = new StaffSummary();
            this.AttendanceSummaryReportModel = new AttendanceReporting.AttendanceSummaryReportModel();
        }
        public string SMSBalance { get; set; }

        public DashBoard.StudentSummary StudentSummary { get; set; }
        public DashBoard.StaffSummary StaffSummary { get; set; }
        public AttendanceReporting.AttendanceSummaryReportModel AttendanceSummaryReportModel { get; set; }
    }
}
