using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class ListAllEventsController : Controller
    {
        LABURNUM.COM.Component.SessionManagement sessionManagement = new Component.SessionManagement();

        // GET: /ListAllEvents/

        public ActionResult Index()
        {
            List<DTO.LABURNUM.COM.EventModel> dbEvents = new Component.Event().GetEventsForSite();
            if (dbEvents.Count > 0)
            {
                dbEvents[0].EventTypes = new Component.EventType().GetActiveEventTypes();
            }
            return View(dbEvents);
        }

    }
}
