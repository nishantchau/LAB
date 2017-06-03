using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class ReportingController : MyBaseController
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();
        // GET: /Reporting/

        public ActionResult Index()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
                DTO.LABURNUM.COM.FeeReportingModel model = new DTO.LABURNUM.COM.FeeReportingModel();
                model.Classes = new LABURNUM.COM.Component.Class().GetActiveClasses();
                return View();
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult TodayCollectionReport()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
            {
                try
                {
                    DTO.LABURNUM.COM.StudentFeeDetailModel model = new DTO.LABURNUM.COM.StudentFeeDetailModel() { StartDate = System.DateTime.Now };
                    //List<DTO.LABURNUM.COM.StudentFeeModel> dbStudentFees = new Component.StudentFee().GetStudentFeeByAdvanceSearch(model);
                    List<DTO.LABURNUM.COM.StudentFeeDetailModel> dbStudentFees = new Component.StudentFeeDetails().GetStudentFeeDetailByAdvanceSearch(model);
                    double x = 0, y = 0, d = 0;

                    foreach (DTO.LABURNUM.COM.StudentFeeDetailModel item in dbStudentFees)
                    {
                        x = x + item.CashPaidAmount;
                        y = y + item.ChequePaidAmount;
                        d = d + item.DiscountAmount;
                    }
                    if (dbStudentFees.Count > 0)
                    {
                        dbStudentFees[0].TotalCashPaidAmount = x;
                        dbStudentFees[0].TotalChequePaidAmount = y;
                        dbStudentFees[0].TotalEarning = x + y;
                        dbStudentFees[0].TotalDiscountAmount = d;
                    }
                    return View(dbStudentFees);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult StudentReportingIndex()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
            {
                DTO.LABURNUM.COM.FeeReportingModel model = new DTO.LABURNUM.COM.FeeReportingModel();
                model.Classes = new Component.Class().GetActiveClasses();
                model.AcademicYears = new Component.AcademicYear().GetActiveAcademicYears();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SearchStudentReporting(DTO.LABURNUM.COM.FeeReportingModel model)
        {
            try
            {
                model.ApiClientModel = new Component.Common().GetApiClientModel();
                HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("FeeReporting", "SearchStudentReporting", model);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    List<DTO.LABURNUM.COM.FeeReportingResultModel> dbFeeReportingResult = JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.FeeReportingResultModel>>(data);
                    string html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Reporting/StudentFeeReporting.cshtml", dbFeeReportingResult);
                    return Json(new { code = 0, message = "success", result = html });
                }
                else
                {
                    return Json(new { code = -1, message = "failed" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }

    }
}
