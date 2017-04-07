using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class SearchStudentByAdvanceSearchController : MyBaseController
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();
        // GET: /SearchStudentByAdvanceSearch/

        public ActionResult Index()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE) || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
            {
                DTO.LABURNUM.COM.StudentModel model = new DTO.LABURNUM.COM.StudentModel();
                model.Classes = new LABURNUM.COM.Component.Class().GetActiveClasses();
                return View(model);
            }
            else
            {

                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SearchStudentByAdvanceSearch(DTO.LABURNUM.COM.StudentModel model)
        {
            try
            {
                List<DTO.LABURNUM.COM.StudentModel> dbStudentList = new LABURNUM.COM.Component.Student().GetStudentByAdvanceSearch(model);
                string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/SearchStudentByAdvanceSearch/Search.cshtml", dbStudentList);
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
