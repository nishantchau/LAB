using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LABURNUM.COM.Controllers
{
    public class FacultyController : MyBaseController
    {

        Component.SessionManagement sessionManagement = new Component.SessionManagement();

        public ActionResult AddIndex()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
                DTO.LABURNUM.COM.FacultyModel model = new DTO.LABURNUM.COM.FacultyModel();
                model.Classes = new Component.Class().GetActiveClasses();
                model.Subjects = new Component.Subject().GetActiveSubjectes();
                if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN))
                {
                    model.UserTypes = new Component.UserTypes().GetActiveUserTypes();
                }
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult Add(DTO.LABURNUM.COM.FacultyModel model)
        {
            try
            {
                if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
                {
                    model.UserTypeId = DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.FACULTY);
                    //if (!model.IsClassTeacher)
                    //{
                    //    model.ClassId = DTO.LABURNUM.COM.Utility.Class.GetValue(DTO.LABURNUM.COM.Utility.EnumClass.FIRST);
                    //    model.SectionId = 1;
                    //}
                    //if (!model.IsSubjectTeacher)
                    //{
                    //    model.SubjectId = 1;
                    //}
                }
                //if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN))
                //{
                //    if (model.UserTypeId == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.FACULTY))
                //    {
                //        if (!model.IsClassTeacher)
                //        {
                //            model.ClassId = 1;
                //            model.SectionId = 1;
                //        }
                //        if (!model.IsSubjectTeacher)
                //        {
                //            model.SubjectId = 1;
                //        }
                //    }
                //}

                model.ApiClientModel = new Component.Common().GetApiClientModel();
                HttpClient client = new Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Faculty/Add", model).Result;
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

        public ActionResult EditFacultyIndex(string id)
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
                LABURNUM.COM.Component.Crypto crypto = new Component.Crypto();
                string text = crypto.DecryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
                long userId = Convert.ToInt64(text);
                DTO.LABURNUM.COM.FacultyModel model = new LABURNUM.COM.Component.Faculty().GetFacultyById(userId);
                if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN))
                {
                    model.UserTypes = new Component.UserTypes().GetActiveUserTypes();

                }
                model.Classes = new Component.Class().GetActiveClasses();
                model.Subjects = new Component.Subject().GetActiveSubjectes();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult EditFaculty(DTO.LABURNUM.COM.FacultyModel model)
        {
            try
            {
                if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
                {
                    model.UserTypeId = DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.FACULTY);
                    if (!model.IsClassTeacher)
                    {
                        model.ClassId = 1;
                        model.SectionId = 1;
                    }
                    if (!model.IsSubjectTeacher)
                    {
                        model.SubjectId = 1;
                    }
                }
                if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN))
                {
                    if (model.UserTypeId == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.FACULTY))
                    {
                        if (!model.IsClassTeacher)
                        {
                            model.ClassId = 1;
                            model.SectionId = 1;
                        }
                        if (!model.IsSubjectTeacher)
                        {
                            model.SubjectId = 1;
                        }
                    }
                }

                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Faculty/Update", model).Result;
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

        public ActionResult SeeAllFaculties()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
                try
                {
                    List<DTO.LABURNUM.COM.FacultyModel> dbFees = new LABURNUM.COM.Component.Faculty().GetAllFaculties();
                    if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
                    {
                        dbFees = dbFees.Where(x => x.UserTypeId == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.FACULTY)).ToList();
                    }
                    return View(dbFees);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }
    }
}
