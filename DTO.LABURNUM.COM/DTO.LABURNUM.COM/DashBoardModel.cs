using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class DashBoardModel
    {
        public DashBoardModel()
        {
            this.ApiClientModel = new ApiClientModel();
            this.StudentDashBoardModel = new DashBoard.StudentDashBoardModel();
            this.AccountDashBoardModel = new DashBoard.AccountDashBoardModel();
            this.AdminDashBoardModel = new DashBoard.AdminDashBoardModel();
            this.FacultyDashBoardModel = new DashBoard.FacultyDashBoardModel();
            this.PrincipalDashBoardModel = new DashBoard.PrincipalDashBoardModel();
            this.EventList = new List<EventModel>();
        }

        public string SMSBalance { get; set; }
        public int PresentStudent { get; set; }
        public int AbsentStudent { get; set; }
        public bool Status { get; set; }
        public bool IsPresentInMorning { get; set; }
        public bool IsPresentAfterLunch { get; set; }

        public long UserType { get; set; }
        public long StudentId { get; set; }
        public long ClassId { get; set; }
        public long SectionId { get; set; }
        public DateTime ForDate { get; set; }
        public int UpcomingEventDays { get; set; }
        public long AcademicYearId { get; set; }


        //For Account Dashboard
        public int ChequeDetaildays { get; set; }

        //For Faculty DashBoard

        public bool IsClassTeacher { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DashBoard.StudentDashBoardModel StudentDashBoardModel { get; set; }
        public DashBoard.AccountDashBoardModel AccountDashBoardModel { get; set; }
        public DashBoard.AdminDashBoardModel AdminDashBoardModel { get; set; }
        public DashBoard.FacultyDashBoardModel FacultyDashBoardModel { get; set; }
        public DashBoard.PrincipalDashBoardModel PrincipalDashBoardModel { get; set; }
        public List<DTO.LABURNUM.COM.EventModel> EventList { get; set; }
        public ApiClientModel ApiClientModel { get; set; }

    }

    public class ChequeDetails
    {
        public long TotalChequeCount { get; set; }
        public long TotalClearedCheque { get; set; }
        public long TotalBounceCheque { get; set; }
        public long TotalPendingCheque { get; set; }
    }
}
