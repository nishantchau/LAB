using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class ListAllCircularsController : Controller
    {
        //
        // GET: /ListAllCirculars/

        public ActionResult Index()
        {
            List<DTO.LABURNUM.COM.CircularModel> dbCirculars = new Component.Circular().GetActiveCirculars();
            return View(dbCirculars);
        }

    }
}
