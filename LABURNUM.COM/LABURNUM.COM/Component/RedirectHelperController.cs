using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Component
{
    public class RedirectHelperController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionMethod">Name of action method</param>
        /// <param name="controller">Name of controller</param>
        /// <returns></returns>
        public ActionResult RedirectTo(string actionMethod, string controller)
        {
            return RedirectToAction(actionMethod, controller);
        }
    }
}
