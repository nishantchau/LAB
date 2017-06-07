using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class DashboardController : MyBaseController
    {
        LABURNUM.COM.Component.SessionManagement SessionManagement = new Component.SessionManagement();
        // GET: /Dashboard/

        public ActionResult Index()
        {
            DTO.LABURNUM.COM.DashBoardModel model = new Component.DashBoard().GetDashBoard();
            //if (SessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN))
            //{
            //    model.SMSBalance = new Component.SMSAPI().GetSMSBalance();
            //}
            //if (SessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.FACULTY))
            //{
            //    List<DTO.LABURNUM.COM.CommonAttendanceModel> dblist = new Component.CommonAttendance().GetAttendanceByAdvanceSearch(new DTO.LABURNUM.COM.CommonAttendanceModel() { ClassId = SessionManagement.GetFacultyClassId(), SectionId = SessionManagement.GetFacultySectionId(), StartDate = new Component.Utility().GetISTDateTime() });
            //    model.PresentStudent = dblist.Where(x => x.IsPresentInMorning == true).ToList().Count();
            //    model.AbsentStudent = dblist.Where(x => x.IsPresentInMorning == false).ToList().Count();
            //}
            //if (SessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PARENT) || SessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.STUDENT))
            //{
            //    List<DTO.LABURNUM.COM.CommonAttendanceModel> dblist = new Component.CommonAttendance().GetAttendanceByAdvanceSearch(new DTO.LABURNUM.COM.CommonAttendanceModel() { ClassId = SessionManagement.GetClassId(), SectionId = SessionManagement.GetSectionId(), StartDate = new Component.Utility().GetISTDateTime(), StudentId = SessionManagement.GetSudentId() });
            //    if (dblist.Count > 0)
            //    {
            //        model.IsPresentInMorning = dblist[0].IsPresentInMorning;
            //        model.IsPresentAfterLunch = dblist[0].IsPresentAfterLuch;
            //    }
            //}

            return View(model);
        }

    }
}
