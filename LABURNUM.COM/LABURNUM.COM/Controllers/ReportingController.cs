using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN)
             || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
            {
                try
                {
                    DTO.LABURNUM.COM.StudentFeeDetailModel model = new DTO.LABURNUM.COM.StudentFeeDetailModel() { StartDate = new Component.Utility().GetISTDateTime() };
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
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
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

        public ActionResult SearchPendingFeeReportIndex()
        {
            DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel model = new DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel();
            model.Classes = new Component.Class().GetActiveClasses();
            //model.Sections = new Component.Section().GetActiveSections();
            return View(model);
        }

        public ActionResult SearchPendingFeeReport(DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel model)
        {
            try
            {
                model.ApiClientModel = new Component.Common().GetApiClientModel();
                HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("FeeReports", "SearchPendingFee", model);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    DTO.LABURNUM.COM.FeeRepoting.FeeReportResponseModel dbFeeReportingResult = JsonConvert.DeserializeObject<DTO.LABURNUM.COM.FeeRepoting.FeeReportResponseModel>(data);
                    string html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Reporting/SearchPendingFeeReport.cshtml", dbFeeReportingResult);
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

        public ActionResult SearchCollectionSummaryIndex()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN)
            || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
            {
                DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel model = new DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel();
                model.Year = new Component.Utility().GetISTDateTime().Year;
                model.MonthId = new Component.Utility().GetISTDateTime().Month;
                model.MonthList = new Component.Month().GetActiveMonths();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SearchCollectionSummary(DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel model)
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
            {
                try
                {
                    model.AcademicYearId = sessionManagement.GetAcademicYearTableId();
                    model.ApiClientModel = new Component.Common().GetApiClientModel();
                    HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("FeeReports", "SearchCollectionSummary", model);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        DTO.LABURNUM.COM.FeeRepoting.CollectionSummary dbFeeReportingResult = JsonConvert.DeserializeObject<DTO.LABURNUM.COM.FeeRepoting.CollectionSummary>(data);
                        string html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Reporting/SearchCollectionSummary.cshtml", dbFeeReportingResult);
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
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult TodayCollectionSummary()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN)
          || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
            {
                DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel model = new DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel() { StartDate = new Component.Utility().GetISTDateTime() };
                DTO.LABURNUM.COM.FeeRepoting.CollectionSummary dbFeeReportingResult = new Component.Reporting().SearchCollectionSummary(model);
                return View(dbFeeReportingResult);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SearchMonthlyDueFeeIndex()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
            {
                DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel model = new DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel();
                model.Classes = new Component.Class().GetActiveClasses();
                model.MonthId = new Component.Utility().GetISTDateTime().Month;
                model.MonthList = new Component.Month().GetActiveMonths();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SearchDueMonthlyFee(DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel model)
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
            {
                try
                {
                    model.AcademicYearId = sessionManagement.GetAcademicYearTableId();
                    model.ApiClientModel = new Component.Common().GetApiClientModel();
                    HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("FeeReports", "SearchDueMonthlyFee", model);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        DTO.LABURNUM.COM.FeeRepoting.FeeReportResponseModel dbFeeReportingResult = JsonConvert.DeserializeObject<DTO.LABURNUM.COM.FeeRepoting.FeeReportResponseModel>(data);
                        string html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Reporting/SearchDueMonthlyFee.cshtml", dbFeeReportingResult);
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
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SearchCollectionByDateIndex()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN)
               || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
            {
                DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel model = new DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        //SearchCollectionSummaryReport

        public ActionResult SearchCollectionReport(DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel model)
        {
            try
            {
                List<DTO.LABURNUM.COM.StudentFeeDetailModel> dblist = new Component.StudentFeeDetails().GetCollectionReport(model);
                string html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Reporting/SearchCollectionReport.cshtml", dblist);

                var serializer = new JavaScriptSerializer();

                // For simplicity just use Int32's max value.
                // You could always read the value from the config section mentioned above.
                serializer.MaxJsonLength = Int32.MaxValue;

                var resultData = new { code = 0, message = "success", result = html };
                var result = new ContentResult
                {
                    Content = serializer.Serialize(resultData),
                    ContentType = "application/json"
                };
                return result;

                //return Json(new { code = 0, message = "success", result = result });
            }
            catch (Exception)
            {
                return Json(new { code = -1, message = "failed", result = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Error404.cshtml", null) });
            }
        }

        public ActionResult SearchCollectionByMonthIndex()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN)
              || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
            {
                DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel model = new DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel();
                model.Year = new Component.Utility().GetISTDateTime().Year;
                model.MonthId = new Component.Utility().GetISTDateTime().Month;
                model.MonthList = new Component.Month().GetActiveMonths();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SearchCollectionSummaryByDateIndex()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN)
               || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
            {
                DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel model = new DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SearchCollectionSummaryReport(DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel model)
        {
            try
            {
                DTO.LABURNUM.COM.FeeRepoting.CollectionSummary dbFeeReportingResult = new Component.Reporting().SearchCollectionSummary(model);
                string html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Reporting/SearchCollectionSummaryReport.cshtml", dbFeeReportingResult);

                var serializer = new JavaScriptSerializer();

                // For simplicity just use Int32's max value.
                // You could always read the value from the config section mentioned above.
                serializer.MaxJsonLength = Int32.MaxValue;

                var resultData = new { code = 0, message = "success", result = html };
                var result = new ContentResult
                {
                    Content = serializer.Serialize(resultData),
                    ContentType = "application/json"
                };
                return result;

                //return Json(new { code = 0, message = "success", result = result });
            }
            catch (Exception)
            {
                return Json(new { code = -1, message = "failed", result = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Error404.cshtml", null) });
            }
        }

        public ActionResult TodayAttendanceSummary()
        {

            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN)
          || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
                DTO.LABURNUM.COM.AttendanceReporting.AttendanceSummaryReportModel model = new Component.Reporting().SearchAttendanceSummaryReport(new DTO.LABURNUM.COM.AttendanceReporting.AttendanceSummaryRequestModel() { StartDate = new Component.Utility().GetISTDateTime() });
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SearchAttendanceSummaryByDateIndex()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN)
               || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
                DTO.LABURNUM.COM.AttendanceReporting.AttendanceSummaryRequestModel model = new DTO.LABURNUM.COM.AttendanceReporting.AttendanceSummaryRequestModel();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SearchAttendanceSummary(DTO.LABURNUM.COM.AttendanceReporting.AttendanceSummaryRequestModel model)
        {
            try
            {
                DTO.LABURNUM.COM.AttendanceReporting.AttendanceSummaryReportModel dblist = new Component.Reporting().SearchAttendanceSummaryReport(model);
                string html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Reporting/SearchAttendanceSummary.cshtml", dblist);

                var serializer = new JavaScriptSerializer();

                // For simplicity just use Int32's max value.
                // You could always read the value from the config section mentioned above.
                serializer.MaxJsonLength = Int32.MaxValue;

                var resultData = new { code = 0, message = "success", result = html };
                var result = new ContentResult
                {
                    Content = serializer.Serialize(resultData),
                    ContentType = "application/json"
                };
                return result;

                //return Json(new { code = 0, message = "success", result = result });
            }
            catch (Exception)
            {
                return Json(new { code = -1, message = "failed", result = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Error404.cshtml", null) });
            }
        }
    }
}
