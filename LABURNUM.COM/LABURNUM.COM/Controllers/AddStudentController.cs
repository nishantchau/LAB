using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace LABURNUM.COM.Controllers
{
    public class AddStudentController : MyBaseController
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();
        // GET: /AddStudent/

        public ActionResult Index()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
            {
                DTO.LABURNUM.COM.StudentModel model = new DTO.LABURNUM.COM.StudentModel();
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

        public ActionResult Add(DTO.LABURNUM.COM.StudentModel model)
        {
            try
            {
                model.ApiClientModel.UserName = LABURNUM.COM.Component.Constants.APIACCESS.APIUSERNAME;
                model.ApiClientModel.Password = LABURNUM.COM.Component.Constants.APIACCESS.APIPASSWORD;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(LABURNUM.COM.Component.Constants.URL.WEBAPIURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Student/Add", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    DTO.LABURNUM.COM.StudentModel dbStudent = JsonConvert.DeserializeObject<DTO.LABURNUM.COM.StudentModel>(data);
                    dbStudent.IsRedirecting = model.IsRedirecting;
                    return Json(new { code = 0, message = "success", studentModel = dbStudent });
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
