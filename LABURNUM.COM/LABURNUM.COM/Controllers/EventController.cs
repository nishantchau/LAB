using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class EventController : MyBaseController
    {
        LABURNUM.COM.Component.SessionManagement sessionManagement = new Component.SessionManagement();

        public ActionResult Index()
        {
            DTO.LABURNUM.COM.EventModel model = new DTO.LABURNUM.COM.EventModel();
            return View(model);
        }

        public ActionResult SeeAllEvents()
        {
            try
            {
                List<DTO.LABURNUM.COM.EventModel> dbEvents = new Component.Event().GetEventByAdvanceSearch(new DTO.LABURNUM.COM.EventModel() { AcademicYearId = sessionManagement.GetAcademicYearTableId() });
                return View(dbEvents);
            }
            catch (Exception)
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Error404/Index");
            }
        }

        public ActionResult AddEvent(DTO.LABURNUM.COM.EventModel model)
        {
            try
            {
                model.ApiClientModel = new Component.Common().GetApiClientModel();
                HttpResponseMessage response = new Component.Common().GetHTTPResponse("Event", "Add", model);
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

        public ActionResult UpdateEvent(DTO.LABURNUM.COM.EventModel model)
        {
            try
            {
                model.ApiClientModel = new Component.Common().GetApiClientModel();
                HttpResponseMessage response = new Component.Common().GetHTTPResponse("Event", "Update", model);
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
