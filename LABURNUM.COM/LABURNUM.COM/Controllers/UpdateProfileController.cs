using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class UpdateProfileController : MyBaseController
    {
        //
        // GET: /UpdateProfile/
        Component.SessionManagement sessionManagement = new Component.SessionManagement();

        public ActionResult Index(string id)
        {
            string text = new Component.Crypto().DecryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
            long userid = Convert.ToInt64(text);
            long loginby = sessionManagement.GetLoginBy();
            DTO.LABURNUM.COM.SessionModel model = new DTO.LABURNUM.COM.SessionModel();
            if (loginby == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.STUDENT) || loginby == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PARENT))
            {
                model.StudentModel = new Component.Student().GetStudentByStudentId(userid);
            }
            else
            {
                model.FacultyModel = new Component.Faculty().GetFacultyById(userid);
            }
            return View(model);
        }

        private string EncryptPassword(string password)
        {
            return new LABURNUM.COM.Component.PasswordConvertor().Password(password);
        }

        public ActionResult UpdateProfile(DTO.LABURNUM.COM.SessionModel model)
        {
            try
            {
                HttpClient client = new Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = new HttpResponseMessage();

                if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.STUDENT) || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.STUDENT))
                {
                    model.StudentModel.ApiClientModel = new Component.Common().GetApiClientModel();
                    if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.STUDENT))
                    {
                        if (EncryptPassword(model.StudentModel.CurrentPassword) == sessionManagement.GetStudentPassword())
                        {
                            response = client.PostAsJsonAsync("Student/UpdateStudentProfile", model.StudentModel).Result;
                        }
                        else
                        {
                            return Json(new { code = -1, message = "Current Password Not Match." });
                        }
                    }
                    if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PARENT))
                    {
                        if (EncryptPassword(model.StudentModel.CurrentPassword) == sessionManagement.GetParentPassword())
                        {
                            response = client.PostAsJsonAsync("Student/UpdateParentProfile", model.StudentModel).Result;
                        }
                        else
                        {
                            return Json(new { code = -1, message = "Current Password Not Match." });
                        }
                    }
                }
                else
                {
                    model.FacultyModel.ApiClientModel = new Component.Common().GetApiClientModel();
                    if (EncryptPassword(model.FacultyModel.CurrentPassword) == sessionManagement.GetFacultyPassword())
                    {
                        response = client.PostAsJsonAsync("Faculty/UpdateProfile", model.FacultyModel).Result;
                    }
                    else
                    {
                        return Json(new { code = -1, message = "Current Password Not Match." });
                    }
                }
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { code = 0, message = "Success" });
                }
                else
                {
                    return Json(new { code = -2, message = "failed" });
                }
            }
            catch (Exception)
            {

                return Json(new { code = -3, message = "failed" });
            }
        }

    }
}
