using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class ContactUsController : Controller
    {
        //
        // GET: /ContactUs/

        public ActionResult Index()
        {
            DTO.LABURNUM.COM.ContactFormTableModel model = new DTO.LABURNUM.COM.ContactFormTableModel();
            return View(model);
        }

        public ActionResult Add(DTO.LABURNUM.COM.ContactFormTableModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("ContactForm/Add", model).Result;
                if (response.IsSuccessStatusCode)
                {
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
