using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class ClassSubjectWiseFacultyController : Controller
    {
        LABURNUM.COM.Component.SessionManagement sessionManagement = new Component.SessionManagement();
        // GET: /ClassWiseFaculty/

        public ActionResult AddClassSubjectWiseFacultyIndex()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
                DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model = new DTO.LABURNUM.COM.ClassSubjectFacultyTableModel();
                model.Classes = new Component.Class().GetActiveClasses();
                model.Subjects = new Component.Subject().GetActiveSubjectes();
                model.Faculties = new Component.Faculty().GetActiveFaculties().Where(x => x.UserTypeId == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.FACULTY)).ToList();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult Add(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            try
            {
                if (model.ClassId != DTO.LABURNUM.COM.Utility.Class.GetValue(DTO.LABURNUM.COM.Utility.EnumClass.PRENURSERY) &&
                    model.ClassId != DTO.LABURNUM.COM.Utility.Class.GetValue(DTO.LABURNUM.COM.Utility.EnumClass.LKG) &&
                    model.ClassId != DTO.LABURNUM.COM.Utility.Class.GetValue(DTO.LABURNUM.COM.Utility.EnumClass.UKG))
                {
                    if (new Component.ClassSubjectFacultyTable().IsSubjectTeacherAssigned(model.ClassId, model.SectionId, model.SubjectId.GetValueOrDefault()))
                    { return Json(new { code = -3, message = "failed" }); }
                    else
                    {
                        model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                        HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                        HttpResponseMessage response = client.PostAsJsonAsync("ClassSubjectFacultyTable/Add", model).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            return Json(new { code = 0, message = "success" });
                        }
                        else
                        {
                            return Json(new { code = -1, message = "failed" });
                        }
                    }
                }
                else
                {
                    model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                    HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                    HttpResponseMessage response = client.PostAsJsonAsync("ClassSubjectFacultyTable/Add", model).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return Json(new { code = 0, message = "success" });
                    }
                    else
                    {
                        return Json(new { code = -1, message = "failed" });
                    }
                }
            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }

        public ActionResult SearchClassSubjectWiseFacultyIndex()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN)
               || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
                DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model = new DTO.LABURNUM.COM.ClassSubjectFacultyTableModel();
                model.Classes = new Component.Class().GetActiveClasses();
                model.Subjects = new Component.Subject().GetActiveSubjectes();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SearchClassSubjectWiseFaculty(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            try
            {
                List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel> dbHomeWork = new Component.ClassSubjectFacultyTable().GetClassSubjectFacultyByAdvanceSearch(model);
                string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/ClassSubjectWiseFaculty/SearchedResult.cshtml", dbHomeWork);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception ex)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }

        public ActionResult UpdateClassSubjectWiseFacultyStatus(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            try
            {
                if (new Component.ClassSubjectFacultyTable().UpdateClassSubjectFacultyStatus(model)) { return Json(new { code = 0, message = "success" }); }
                else { return Json(new { code = -1, message = "failed" }); }
            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }


        public ActionResult SearchAssignedClassToFaculty()
        {
            DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model = new DTO.LABURNUM.COM.ClassSubjectFacultyTableModel() { FacultyId = sessionManagement.GetFacultyId() };
            List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel> dblist = new Component.ClassSubjectFacultyTable().GetClassSubjectFacultyByAdvanceSearch(model);
            return View(dblist);
        }
    }
}
