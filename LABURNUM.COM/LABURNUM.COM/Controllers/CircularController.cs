using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class CircularController : MyBaseController
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();
        // GET: /Circular/

        public ActionResult AddCircularIndex()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
                DTO.LABURNUM.COM.CircularModel model = new DTO.LABURNUM.COM.CircularModel();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult AddCircular(DTO.LABURNUM.COM.CircularModel model)
        {
            try
            {
                model.ApiClientModel = new Component.Common().GetApiClientModel();
                HttpResponseMessage response = new Component.Common().GetHTTPResponse("Circular", "Add", model);
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { code = 0, message = "success" });
                }
                else
                {
                    return Json(new { code = -1, message = "Failed" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { code = -2, message = "Failed" });
            }
        }

        public ActionResult SearchCircularIndex()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
                DTO.LABURNUM.COM.CircularModel model = new DTO.LABURNUM.COM.CircularModel();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SearchCircular(DTO.LABURNUM.COM.CircularModel model)
        {
            try
            {
                if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
                {
                    List<DTO.LABURNUM.COM.CircularModel> dbCirculars = new Component.Circular().GetCircularByAdvanceSearch(model);
                    string html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Circular/SearchResultTable.cshtml", dbCirculars);
                    return Json(new { code = 0, message = "success", result = html });
                }
                else
                {
                    return Json(new { code = -1, message = "failed", result = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "", "Model") });
                }
            }
            catch (Exception ex)
            {
                return Json(new { code = -2, message = "failed", result = string.Empty });
            }
        }

        public ActionResult EditCircularIndex(string id)
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
                string text = new Component.Crypto().DecryptStringAES(id, Component.Constants.KEYS.SHAREDKEY);
                long circularId = Convert.ToInt64(text);
                DTO.LABURNUM.COM.CircularModel model = new Component.Circular().GetCircularByCircularId(circularId);
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult ListOfAllCirculars()
        {
            List<DTO.LABURNUM.COM.CircularModel> dbCirculars = new Component.Circular().GetActiveCirculars();
            return View(dbCirculars);
        }

    }
}
