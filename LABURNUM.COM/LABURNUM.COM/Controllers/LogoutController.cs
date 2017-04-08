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
                long id = Convert.ToInt64(new LABURNUM.COM.Component.CookieManager(LABURNUM.COM.Component.Constants.Cookies.UserCookie.NAME).GetLoginActivityId(LABURNUM.COM.Component.Constants.Cookies.UserCookie.NAME));

                //new Component.LoginActivity().UpdateLoginActivity(new Component.SessionManagement().GetLoginActivityId());
                new Component.LoginActivity().UpdateLoginActivity(id);
                Session.RemoveAll();
                Session.Abandon();
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddDays(-30);
                Response.Cookies[LABURNUM.COM.Component.Constants.Cookies.UserCookie.NAME].Expires = DateTime.Now.AddDays(-30);
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Login/Index");
            }
            catch (Exception ex)
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Login/Index");
            }
        }
    }
}
