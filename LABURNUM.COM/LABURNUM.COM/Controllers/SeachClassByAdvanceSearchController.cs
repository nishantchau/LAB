using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace LABURNUM.COM.Controllers
{
    public class SeachClassByAdvanceSearchController : MyBaseController
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();
        // GET: /SeachClassByAdvanceSearch/

        public ActionResult Index()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
            DTO.LABURNUM.COM.ClassModel model = new DTO.LABURNUM.COM.ClassModel();
            return View(model);
            }
            else
            {
                
				return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SeachClassByAdvanceSearch(DTO.LABURNUM.COM.ClassModel model)
        {
            try
            {
                List<DTO.LABURNUM.COM.ClassModel> dbClassList = new LABURNUM.COM.Component.Class().GetClassesByAdvanceSearch(model);
                string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/SeachClassByAdvanceSearch/Search.cshtml", dbClassList);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                //string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/SeachClassByAdvanceSearch/Search.cshtml", dbClassList);
                return Json(new { code = -1, message = "failed" });
            }
        }
    }
}
