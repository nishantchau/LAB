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

        //For Account Dashboard
        public int ChequeDetaildays { get; set; }

        public DashBoard.StudentDashBoardModel StudentDashBoardModel { get; set; }
        public DashBoard.AccountDashBoardModel AccountDashBoardModel { get; set; }
        public DashBoard.AdminDashBoardModel AdminDashBoardModel { get; set; }
        public ApiClientModel ApiClientModel { get; set; }
    }
}
