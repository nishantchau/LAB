using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class LogInActivityController : MyBaseController
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();
        // GET: /LogInActivity/

        public ActionResult Index()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN))
            {
                DTO.LABURNUM.COM.LoginActivityModel model = new DTO.LABURNUM.COM.LoginActivityModel();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SearchLogInActivity(DTO.LABURNUM.COM.LoginActivityModel model)
        {
            string html = null;
            try
            {
                model.ApiClientModel = new Component.Common().GetApiClientModel();
                List<DTO.LABURNUM.COM.LoginActivityModel> dbLoginActivities = new Component.LoginActivity().GetLoginActivityByAdvSearch(model);
                html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "", dbLoginActivities);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                html = new Component.Common().GetErrorView();
                return Json(new { code = -1, message = "failed", result = html });
            }
        }
    }
}
