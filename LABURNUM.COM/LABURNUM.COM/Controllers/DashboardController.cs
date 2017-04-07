using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class DashboardController : MyBaseController
    {
        //
        // GET: /Dashboard/

        public ActionResult Index()
        {
            return View();
        }

    }
}
