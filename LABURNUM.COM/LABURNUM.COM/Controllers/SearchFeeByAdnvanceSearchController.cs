using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class SearchFeeByAdnvanceSearchController : MyBaseController
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();
        // GET: /SearchFeeByAdnvanceSearch/

        public ActionResult Index()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
                DTO.LABURNUM.COM.FeeModel model = new DTO.LABURNUM.COM.FeeModel();
                model.Classes = new LABURNUM.COM.Component.Class().GetActiveClasses();
                model.AdmissionTypes = new LABURNUM.COM.Component.AdmissionType().GetActiveAdmissionTypes();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SearchFeeByAdvanceSearch(DTO.LABURNUM.COM.FeeModel model)
        {
            try
            {
                List<DTO.LABURNUM.COM.FeeModel> dbFeeList = new LABURNUM.COM.Component.Fee().GetFeeByAdvanceSearch(model);
                string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/SearchFeeByAdnvanceSearch/Search.cshtml", dbFeeList);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                //string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/SeachClassByAdvanceSearch/Search.cshtml", dbClassList);
                return Json(new { code = -2, message = "failed" });
            }
        }
    }
}
