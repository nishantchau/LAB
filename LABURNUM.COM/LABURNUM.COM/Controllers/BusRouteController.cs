using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class BusRouteController : Controller
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();

        public ActionResult SeeAllBusRoutesIndex()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
                List<DTO.LABURNUM.COM.BusRouteModel> dbBusRoutes = new Component.BusRoute().GetActiveBusRoutes();
                return View(dbBusRoutes);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult AddBusRoute(DTO.LABURNUM.COM.BusRouteModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("BusRoute/Add", model).Result;
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

        public ActionResult EditBusRoute(DTO.LABURNUM.COM.BusRouteModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("BusRoute/Update", model).Result;
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
