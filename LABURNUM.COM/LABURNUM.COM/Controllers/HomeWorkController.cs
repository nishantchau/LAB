using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class HomeWorkController : MyBaseController
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();
        // GET: /HomeWork/

        public ActionResult AddHomeWorkIndex()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.FACULTY))
            {
                DTO.LABURNUM.COM.HomeWorkModel model = new DTO.LABURNUM.COM.HomeWorkModel();
                model.Classes = new Component.Class().GetActiveClasses();
                model.Subjects = new Component.Subject().GetActiveSubjectes();
                if (sessionManagement.GetIsSubjectTeacher()) { model.SubjectId = sessionManagement.GetSubjectId(); }
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult AddHomeWork(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            try
            {
                if (sessionManagement.GetIsSubjectTeacher()) { model.SubjectId = sessionManagement.GetSubjectId(); }
                model.FacultyId = sessionManagement.GetFacultyId();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("HomeWork/Add", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { code = 0, message = "success" });
                }
                else
                {
                    return Json(new { code = -1, message = "failed" });
                }
            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }

        public ActionResult SearchHomeWorkIndex()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN)
               || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE)
               || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.FACULTY))
            {
                DTO.LABURNUM.COM.HomeWorkModel model = new DTO.LABURNUM.COM.HomeWorkModel();
                model.Classes = new Component.Class().GetActiveClasses();
                model.Subjects = new Component.Subject().GetActiveSubjectes();
                if (sessionManagement.GetIsSubjectTeacher()) { model.SubjectId = sessionManagement.GetSubjectId(); }
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SearchHomeWork(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            try
            {
                List<DTO.LABURNUM.COM.HomeWorkModel> dbHomeWork = new Component.HomeWork().GetHomeWorkByAdvanceSearch(model);
                string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/HomeWork/SearchHomeWorkResult.cshtml", dbHomeWork);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception ex)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }
    }
}
