using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class UpdateStudentController : MyBaseController
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();
        //
        // GET: /UpdateStudent/

        public ActionResult Index(string id)
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
            {
                LABURNUM.COM.Component.Crypto crypto = new Component.Crypto();
                string text = crypto.DecryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
                long sId = Convert.ToInt64(text);
                DTO.LABURNUM.COM.StudentModel model = new LABURNUM.COM.Component.Student().GetStudentByStudentId(sId);
                model.Classes = new LABURNUM.COM.Component.Class().GetActiveClasses();
                model.Salutations = new LABURNUM.COM.Component.Salutation().GetActiveSalutations();
                model.BusRoutes = new LABURNUM.COM.Component.BusRoute().GetActiveBusRoutes();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult Update(DTO.LABURNUM.COM.StudentModel model)
        {
            try
            {
                model.ApiClientModel.UserName = LABURNUM.COM.Component.Constants.APIACCESS.APIUSERNAME;
                model.ApiClientModel.Password = LABURNUM.COM.Component.Constants.APIACCESS.APIPASSWORD;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(LABURNUM.COM.Component.Constants.URL.WEBAPIURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Student/Update", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    DTO.LABURNUM.COM.StudentModel dbStudent = JsonConvert.DeserializeObject<DTO.LABURNUM.COM.StudentModel>(data);
                    dbStudent.IsRedirecting = model.IsRedirecting;
                    return Json(new { code = 0, message = "success", studentModel = dbStudent });
                }
                else
                {
                    return Json(new { code = -1, message = "failed", studentModel = string.Empty });
                }
            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed", studentModel = string.Empty });
            }
        }
    }
}
