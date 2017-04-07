using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class LogoutController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                new Component.LoginActivity().UpdateLoginActivity(new Component.SessionManagement().GetLoginActivityId());
                Session.RemoveAll();
                Session.Abandon();
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Login/Index");
            }
            catch (Exception ex)
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Login/Index");
            }
        }
    }
}
