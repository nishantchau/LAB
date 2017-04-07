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
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            DTO.LABURNUM.COM.LoginModel model = new DTO.LABURNUM.COM.LoginModel();
            return View(model);
        }

        public ActionResult DoLogin(DTO.LABURNUM.COM.LoginModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(LABURNUM.COM.Component.Constants.URL.WEBAPIURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Login/DoLogin", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    DTO.LABURNUM.COM.SessionModel dbuser = JsonConvert.DeserializeObject<DTO.LABURNUM.COM.SessionModel>(data);

                    //Set User Session
                    HttpContext.Session.Add(LABURNUM.COM.Component.Constants.SessionName, dbuser);

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
