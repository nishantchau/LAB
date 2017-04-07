using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class MyBaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                //is session still alive?
                bool isSessionTimedOut = true;
                if (filterContext.HttpContext.Session.Count > 0)
                {
                    if (filterContext.HttpContext.Session[LABURNUM.COM.Component.Constants.SessionName] != null) { isSessionTimedOut = false; }
                }
                if (isSessionTimedOut)
                {
                    //logout opertaion 
                    Session.RemoveAll();
                    filterContext.Result = Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Logout/Index");
                }
            }
            catch (Exception ex)
            {
                Session.RemoveAll();
                filterContext.Result = Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Logout/Index"); ;
            }
        }

    }
}
