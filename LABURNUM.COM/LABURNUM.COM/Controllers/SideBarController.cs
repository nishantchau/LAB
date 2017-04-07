using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class SideBarController : Controller
    {
        //
        // GET: /SideBar/

        public ActionResult Index()
        {
            LABURNUM.COM.Component.SessionManagement model = new Component.SessionManagement();
            return View(model);
        }

    }
}
