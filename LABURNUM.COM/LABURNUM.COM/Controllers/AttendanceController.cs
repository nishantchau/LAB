using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class AttendanceController : MyBaseController
    {
        LABURNUM.COM.Component.SessionManagement sessionManagement = new Component.SessionManagement();

        public ActionResult SubmitAttendanceIndex()
        {
            DTO.LABURNUM.COM.CommonAttendanceModel model = new DTO.LABURNUM.COM.CommonAttendanceModel()
            {
                ClassId = sessionManagement.GetFacultyClassId(),
                SectionId = sessionManagement.GetFacultySectionId(),
            };
            if (new Component.CommonAttendance().IsAttendanceSubmittedForToday(model))
            { return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Attendance/IsAttendanceSubmitted"); }
            else
            {
                List<DTO.LABURNUM.COM.CommonAttendanceModel> dblist = new Component.CommonAttendance().GetStudentListForAttendance(model);
                return View(dblist);
            }
        }

        public ActionResult IsAttendanceSubmitted()
        {
            DTO.LABURNUM.COM.CommonAttendanceModel model = new DTO.LABURNUM.COM.CommonAttendanceModel()
             {
                 ClassId = sessionManagement.GetFacultyClassId(),
                 SectionId = sessionManagement.GetFacultySectionId(),
             };
            if (new Component.CommonAttendance().IsAttendanceSubmittedForToday(model))
            {
                List<DTO.LABURNUM.COM.CommonAttendanceModel> dblist = new Component.CommonAttendance().GetAttendanceByAdvanceSearch(model);
                return View(dblist);
            }
            else { return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Attendance/SubmitAttendanceIndex"); }
        }

        public ActionResult SubmitAttendance(List<DTO.LABURNUM.COM.CommonAttendanceModel> dbList)
        {
            try
            {
                foreach (DTO.LABURNUM.COM.CommonAttendanceModel item in dbList)
                {
                    item.FacultyId = sessionManagement.GetFacultyId();
                    item.MorningAttendanceDate = System.DateTime.Now;
                    item.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                }
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("CommonAttendance/AddAttendanceList", dbList).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return Json(new { code = 0, message = "success" });
                }
                else { return Json(new { code = -1, message = "failed" }); }
            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }

        public ActionResult SearchAttendanceIndex()
        {
            DTO.LABURNUM.COM.CommonAttendanceModel model = new DTO.LABURNUM.COM.CommonAttendanceModel();
            return View(model);
        }

        public ActionResult SearchAttendance(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            try
            {
                string html = null;
                if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.FACULTY))
                {
                    model.ClassId = sessionManagement.GetFacultyClassId();
                    model.SectionId = sessionManagement.GetFacultySectionId();
                }
                if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.STUDENT) || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PARENT))
                {
                    model.ClassId = sessionManagement.GetClassId();
                    model.SectionId = sessionManagement.GetSectionId();
                    model.StudentId = sessionManagement.GetSudentId();
                }
                //List<DTO.LABURNUM.COM.CommonAttendanceModel> dblist = new Component.CommonAttendance().GetAttendanceByAdvanceSearch(model);
                //html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Attendance/SearchResult.cshtml", dblist);

                DTO.LABURNUM.COM.AttendanceReporting.AttendanceReportResponseModel dblist = new Component.CommonAttendance().GetAttendanceReport(model);
                html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Attendance/AttendanceReport.cshtml", dblist);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                string html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Error404.cshtml", null);
                return Json(new { code = 0, message = "success", result = html });
            }
        }


        public ActionResult SubmitAfterLuchAttendanceIndex()
        {
            DTO.LABURNUM.COM.CommonAttendanceModel model = new DTO.LABURNUM.COM.CommonAttendanceModel()
            {
                ClassId = sessionManagement.GetFacultyClassId(),
                SectionId = sessionManagement.GetFacultySectionId(),
            };

            List<DTO.LABURNUM.COM.CommonAttendanceModel> dbList = new Component.CommonAttendance().GetAttendanceByAdvanceSearch(model);

            if (dbList.Where(x => x.LunchAttendanceDate.GetValueOrDefault().Year != 0001).ToList().Count > 1)
            { return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Attendance/IsAttendanceSubmitted"); }
            else
            {
                //List<DTO.LABURNUM.COM.CommonAttendanceModel> dblist = new Component.CommonAttendance().GetStudentListForAttendance(model);
                return View(dbList);
            }
        }


        public ActionResult SubmitAfterLunchAttendance(List<DTO.LABURNUM.COM.CommonAttendanceModel> dbList)
        {
            try
            {
                foreach (DTO.LABURNUM.COM.CommonAttendanceModel item in dbList)
                {
                    //item.FacultyId = sessionManagement.GetFacultyId();
                    item.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                }
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("CommonAttendance/SubmitAfterLunchAttendanceList", dbList).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return Json(new { code = 0, message = "success" });
                }
                else { return Json(new { code = -1, message = "failed" }); }
            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }

    }
}
