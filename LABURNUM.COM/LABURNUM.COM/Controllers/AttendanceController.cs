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
            List<DTO.LABURNUM.COM.CommonAttendanceModel> dblist = new Component.CommonAttendance().GetStudentListForAttendance(model);
            return View(dblist);
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
                return View(model);
            }
            else { return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Attendance/SubmitAttendanceIndex"); }
        }

        public ActionResult SubmitAttendance(List<DTO.LABURNUM.COM.CommonAttendanceModel> dbList)
        {
            try
            {
                dbList[0].ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
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
    }
}
