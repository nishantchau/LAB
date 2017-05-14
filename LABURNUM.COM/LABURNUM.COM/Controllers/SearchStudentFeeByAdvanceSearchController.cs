using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class SearchStudentFeeByAdvanceSearchController : MyBaseController
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();
        // GET: /SearchStudentFeeByAdvanceSearch/

        public ActionResult Index()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
            {
                DTO.LABURNUM.COM.StudentFeeModel model = new DTO.LABURNUM.COM.StudentFeeModel();
                model.Classes = new LABURNUM.COM.Component.Class().GetActiveClasses();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SearchStudentFeeByAdvanceSearch(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            try
            {
                List<DTO.LABURNUM.COM.StudentFeeModel> dbStudentFeeList = new LABURNUM.COM.Component.StudentFee().GetStudentFeeByAdvanceSearch(model);
                double x = 0, y = 0, totalamount = 0;
                foreach (DTO.LABURNUM.COM.StudentFeeModel item in dbStudentFeeList)
                {
                    x = x + item.TotalPayableAmount;
                    foreach (DTO.LABURNUM.COM.StudentFeeDetailModel item1 in item.StudentFeeDetails)
                    {
                        y = y + item1.MonthlyFee + item1.LateFee + item1.PendingFee.GetValueOrDefault();
                    }
                    totalamount = x + y;
                }
                if (dbStudentFeeList.Count > 0) { dbStudentFeeList[0].TotalEarning = totalamount; }
                string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/SearchStudentFeeByAdvanceSearch/Search.cshtml", dbStudentFeeList);
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
