using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class DeleteStudentController : MyBaseController
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();
        // GET: /DeleteStudent/

        public ActionResult Index(string id)
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
                LABURNUM.COM.Component.Crypto crypto = new Component.Crypto();
                string text = crypto.DecryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
                DTO.LABURNUM.COM.StudentModel model = new DTO.LABURNUM.COM.StudentModel();
                model.StudentId = Convert.ToInt64(text); ;
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult Delete(DTO.LABURNUM.COM.StudentModel model)
        {
            try
            {
                model.ApiClientModel.UserName = LABURNUM.COM.Component.Constants.APIACCESS.APIUSERNAME;
                model.ApiClientModel.Password = LABURNUM.COM.Component.Constants.APIACCESS.APIPASSWORD;
                model.IsActive = false;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(LABURNUM.COM.Component.Constants.URL.WEBAPIURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Student/UpdateStatus", model).Result;
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
    }
}
