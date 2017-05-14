using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class AjaxRequestController : MyBaseController
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();

        public ActionResult EditClassPopup(string id)
        {
            if (sessionManagement.isSessionAlive())
            {
                DTO.LABURNUM.COM.ClassModel model = new DTO.LABURNUM.COM.ClassModel();
                string html;
                try
                {
                    LABURNUM.COM.Component.Crypto crypto = new Component.Crypto();
                    string text = crypto.DecryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
                    long cId = Convert.ToInt64(text);
                    model = new LABURNUM.COM.Component.Class().GetClassByClassId(cId);
                    html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/EditClassPopup.cshtml", model);
                    return Json(new { code = 0, message = "success", result = html });
                }
                catch (Exception)
                {
                    html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Error404.cshtml", model);
                    return Json(new { code = -1, message = "failed", result = html });
                }
            }
            else
            {
                return Json(new { code = 99, result = "SessionTimedOut" });
            }
        }

        public ActionResult StatusUpdateAlert(long id, bool cIsActive)
        {
            if (sessionManagement.isSessionAlive())
            {
                try
                {

                    DTO.LABURNUM.COM.ClassModel model = new DTO.LABURNUM.COM.ClassModel() { ClassId = id, IsActive = cIsActive };
                    string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/StatusUpdateAlert.cshtml", model);
                    return Json(new { code = 0, message = "success", result = html });
                }
                catch (Exception)
                {
                    return Json(new { code = -1, message = "failed", result = new LABURNUM.COM.Component.Common().GetErrorView() });
                }
            }
            else
            {
                return Json(new { code = 99, result = "SessionTimedOut" });
            }
        }

        public ActionResult EditAdmissionTypePopup(string id)
        {
            if (sessionManagement.isSessionAlive())
            {
                try
                {
                    LABURNUM.COM.Component.Crypto crypto = new Component.Crypto();
                    string text = crypto.DecryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
                    long cId = Convert.ToInt64(text);
                    DTO.LABURNUM.COM.AdmissionTypeModel model = new DTO.LABURNUM.COM.AdmissionTypeModel();
                    model = new LABURNUM.COM.Component.AdmissionType().GetAdmissionTypeByAdmissionTypeId(cId);
                    string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/EditAdmissionTypePopup.cshtml", model);
                    return Json(new { code = 0, message = "success", result = html });
                }
                catch (Exception)
                {
                    return Json(new { code = -1, message = "failed", result = new LABURNUM.COM.Component.Common().GetErrorView() });
                }
            }
            else
            {
                return Json(new { code = 99, result = "SessionTimedOut" });
            }
        }

        public ActionResult AdmissionTypeStatusUpdateAlert(long id, bool cIsActive)
        {
            if (sessionManagement.isSessionAlive())
            {
                try
                {
                    DTO.LABURNUM.COM.AdmissionTypeModel model = new DTO.LABURNUM.COM.AdmissionTypeModel() { AdmissionTypeId = id, IsActive = cIsActive };
                    string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/AdmissionTypeStatusUpdateAlert.cshtml", model);
                    return Json(new { code = 0, message = "success", result = html });
                }
                catch (Exception)
                {
                    return Json(new { code = -1, message = "failed", result = new LABURNUM.COM.Component.Common().GetErrorView() });
                }
            }
            else
            {
                return Json(new { code = 99, result = "SessionTimedOut" });
            }
        }

        public ActionResult SearchFee(long classId, bool admissionType, bool callbymaster)
        {
            if (sessionManagement.isSessionAlive())
            {
                try
                {
                    string html = null;
                    DTO.LABURNUM.COM.FeeModel model = new LABURNUM.COM.Component.Fee().GetFeeByClassIdandAdmissionType(classId, admissionType);
                    if (callbymaster)
                    {
                        if (model != null)
                        {
                            html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/DuplicateFeeAlert.cshtml", model);
                        }
                        else
                        {
                            html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/SearchFee.cshtml", model);
                        }
                    }
                    else
                    {
                        html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/SearchFee.cshtml", model);
                    }
                    return Json(new { code = 0, message = "success", result = html });
                }
                catch (Exception)
                {
                    return Json(new { code = -1, message = "failed", result = new LABURNUM.COM.Component.Common().GetErrorView() });
                }
            }
            else
            {
                return Json(new { code = 99, result = "SessionTimedOut" });
            }
        }

        public ActionResult SearchStudent(string id)
        {
            if (sessionManagement.isSessionAlive())
            {
                try
                {
                    LABURNUM.COM.Component.Crypto crypto = new Component.Crypto();
                    string text = crypto.DecryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
                    long sid = Convert.ToInt64(text);
                    DTO.LABURNUM.COM.StudentModel model = new LABURNUM.COM.Component.Student().GetStudentByStudentId(sid);
                    string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/SearchStudent.cshtml", model);
                    return Json(new { code = 0, message = "success", result = html });
                }
                catch (Exception)
                {
                    return Json(new { code = -1, message = "failed", result = new LABURNUM.COM.Component.Common().GetErrorView() });
                }
            }
            else
            {
                return Json(new { code = 99, result = "SessionTimedOut" });
            }
        }

        public ActionResult SearchSectionPopup(string id)
        {
            if (sessionManagement.isSessionAlive())
            {
                List<DTO.LABURNUM.COM.SectionModel> model = new List<DTO.LABURNUM.COM.SectionModel>();
                string html;
                try
                {
                    LABURNUM.COM.Component.Crypto crypto = new Component.Crypto();
                    string text = crypto.DecryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
                    long cId = Convert.ToInt64(text);
                    model = new LABURNUM.COM.Component.Section().GetSectionByClassId(cId);
                    html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/SearchSectionPopup.cshtml", model);
                    return Json(new { code = 0, message = "success", result = html });
                }
                catch (Exception)
                {
                    html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Error404.cshtml", model);
                    return Json(new { code = -1, message = "failed", result = html });
                }
            }
            else
            {
                return Json(new { code = 99, result = "SessionTimedOut" });
            }
        }

        public ActionResult EditSectionPopup(string id)
        {
            if (sessionManagement.isSessionAlive())
            {
                DTO.LABURNUM.COM.SectionModel model = new DTO.LABURNUM.COM.SectionModel();
                string html;
                try
                {
                    LABURNUM.COM.Component.Crypto crypto = new Component.Crypto();
                    string text = crypto.DecryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
                    long cId = Convert.ToInt64(text);
                    model = new LABURNUM.COM.Component.Section().GetSectionBySectionId(cId);
                    html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/EditSectionPopup.cshtml", model);
                    return Json(new { code = 0, message = "success", result = html });
                }
                catch (Exception)
                {
                    html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Error404.cshtml", model);
                    return Json(new { code = -1, message = "failed", result = html });
                }
            }
            else
            {
                return Json(new { code = 99, result = "SessionTimedOut" });
            }
        }

        public ActionResult EditSection(DTO.LABURNUM.COM.SectionModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Section/Update", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { code = 0, message = "success" });
                }
                else { return Json(new { code = -1, message = "failed" }); }

            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }

        public ActionResult AddNewSection()
        {
            try
            {
                DTO.LABURNUM.COM.SectionModel model = new DTO.LABURNUM.COM.SectionModel();
                model.Classes = new Component.Class().GetActiveClasses();
                string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/AddNewSection.cshtml", model);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }

        public ActionResult AddSection(DTO.LABURNUM.COM.SectionModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Section/Add", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { code = 0, message = "success" });
                }
                else { return Json(new { code = -1, message = "failed" }); }

            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }

        public ActionResult PayMonthlyFee(long cid, long sid, long sectionId, bool isNewAdmission, long adfId, long routeId)
        {
            try
            {
                if (sessionManagement.isSessionAlive())
                {
                    DTO.LABURNUM.COM.StudentFeeDetailModel model = new DTO.LABURNUM.COM.StudentFeeDetailModel() { ClassId = cid, SectionId = sectionId, StudentId = sid, IsNewAdmission = isNewAdmission };
                    model.MonthlyFee = new Component.Fee().GetFeeByClassIdandAdmissionType(cid, isNewAdmission).MonthlyFee.GetValueOrDefault();
                    model.Months = new Component.Month().GetActiveMonths();
                    if (routeId > 0)
                    {
                        model.TransportFee = new Component.BusRoute().GetTransportChargeByRouteId(routeId);
                    }
                    model.AnnualFunctionFeePayableMonth = Component.Constants.DEFAULTVALUE.ANNUALFUNCTIONFEEPAYABLEMONTH;
                    model.PayForTheMonth = System.DateTime.Now.Month;
                    int currentday = System.DateTime.Now.Day;
                    model.LateFee = new Component.LateFeePaneltyMaster().GetFineAmount(currentday);
                    DTO.LABURNUM.COM.StudentFeeDetailModel model1 = new Component.StudentFeeDetails().GetPendingFee(sid, cid, sectionId, sessionManagement.GetAcademicYearTableId());
                    if (model1 != null)
                    {
                        if (model1.ChequeStatus == DTO.LABURNUM.COM.Utility.ChequeStatusMaster.GetChequeStatusMasterId(DTO.LABURNUM.COM.Utility.EnumChequeStatusMaster.BOUNCE))
                        {
                            model.LastPendingFee = model1.PendingFee.GetValueOrDefault() + model1.ChequePaidAmount + Component.Constants.DEFAULTVALUE.CHEQUEBOUNCEPANELTY;
                            model.BounceChequeAmount = model1.ChequePaidAmount;
                            model.BounceChequeNumber = model1.ChequeNumber;
                            model.BounceChequeBankName = model1.ChequeBankName;
                            model.ChequeStatusName = model1.ChequeStatusName;
                            model.BounceChequeDate = model1.ChequeDate.GetValueOrDefault();
                            model.BounceChequePanelty = Component.Constants.DEFAULTVALUE.CHEQUEBOUNCEPANELTY;
                        }
                        else
                        {
                            model.LastPendingFee = model1.PendingFee.GetValueOrDefault();
                        }

                    }
                    model.TotalPayableAmount = model.MonthlyFee + model.TransportFee.GetValueOrDefault() + model.LateFee + model.LastPendingFee;
                    model.Banks = new Component.Bank().GetAllActiveBank();
                    string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/PayMonthlyFee.cshtml", model);
                    return Json(new { code = 0, message = "success", result = html });
                }
                else
                {
                    return Json(new { code = 99, result = "SessionTimedOut" });
                }

            }
            catch (Exception)
            {
                return Json(new { code = -1, message = "failed", result = new LABURNUM.COM.Component.Common().GetErrorView() });
            }
        }

        public ActionResult AddNewSubject()
        {
            try
            {
                DTO.LABURNUM.COM.SubjectModel model = new DTO.LABURNUM.COM.SubjectModel();
                string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/AddNewSubject.cshtml", model);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                return Json(new { code = -1, message = "failed" });
            }
        }

        public ActionResult EditSubjectPopup(string id)
        {
            if (sessionManagement.isSessionAlive())
            {
                DTO.LABURNUM.COM.SubjectModel model = new DTO.LABURNUM.COM.SubjectModel();
                string html;
                try
                {
                    LABURNUM.COM.Component.Crypto crypto = new Component.Crypto();
                    string text = crypto.DecryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
                    long cId = Convert.ToInt64(text);
                    model = new LABURNUM.COM.Component.Subject().GetSubjectBySubjectId(cId);
                    html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/EditSubjectPopup.cshtml", model);
                    return Json(new { code = 0, message = "success", result = html });
                }
                catch (Exception)
                {
                    html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Error404.cshtml", model);
                    return Json(new { code = -1, message = "failed", result = html });
                }
            }
            else
            {
                return Json(new { code = 99, result = "SessionTimedOut" });
            }
        }

        public ActionResult AddNewBusRoutePopup()
        {
            try
            {
                DTO.LABURNUM.COM.BusRouteModel model = new DTO.LABURNUM.COM.BusRouteModel();
                string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/AddNewBusRoutePopup.cshtml", model);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                return Json(new { code = -1, message = "failed" });
            }
        }

        public ActionResult EditBusRoutePopup(string id)
        {
            if (sessionManagement.isSessionAlive())
            {
                DTO.LABURNUM.COM.BusRouteModel model = new DTO.LABURNUM.COM.BusRouteModel();
                string html;
                try
                {
                    LABURNUM.COM.Component.Crypto crypto = new Component.Crypto();
                    string text = crypto.DecryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
                    long cId = Convert.ToInt64(text);
                    model = new LABURNUM.COM.Component.BusRoute().GetBusRouteByRouteId(cId);
                    html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/EditBusRoutePopup.cshtml", model);
                    return Json(new { code = 0, message = "success", result = html });
                }
                catch (Exception)
                {
                    html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Error404.cshtml", model);
                    return Json(new { code = -1, message = "failed", result = html });
                }
            }
            else
            {
                return Json(new { code = 99, result = "SessionTimedOut" });
            }
        }

        public ActionResult AddNewLateFeePanelty()
        {
            try
            {
                DTO.LABURNUM.COM.LateFeePaneltyMasterModel model = new DTO.LABURNUM.COM.LateFeePaneltyMasterModel();
                string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/AddNewLateFeePanelty.cshtml", model);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                return Json(new { code = -1, message = "failed" });
            }
        }

        public ActionResult EditLateFeePaneltyPopup(string id)
        {
            if (sessionManagement.isSessionAlive())
            {
                DTO.LABURNUM.COM.LateFeePaneltyMasterModel model = new DTO.LABURNUM.COM.LateFeePaneltyMasterModel();
                string html;
                try
                {
                    LABURNUM.COM.Component.Crypto crypto = new Component.Crypto();
                    string text = crypto.DecryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
                    long cId = Convert.ToInt64(text);
                    model = new LABURNUM.COM.Component.LateFeePaneltyMaster().GetLateFeePaneltyMasterById(cId);
                    html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/EditLateFeePaneltyPopup.cshtml", model);
                    return Json(new { code = 0, message = "success", result = html });
                }
                catch (Exception)
                {
                    html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Error404.cshtml", model);
                    return Json(new { code = -1, message = "failed", result = html });
                }
            }
            else
            {
                return Json(new { code = 99, message = "SessionTimedOut" });
            }
        }

        //public ActionResult GenerateReceipt(long id, bool isAdmissionPaymentReceipt)
        //{
        //    if (sessionManagement.isSessionAlive())
        //    {
        //        DTO.LABURNUM.COM.StudentFeeDetailModel model = new DTO.LABURNUM.COM.StudentFeeDetailModel();
        //        string html;
        //        try
        //        {
        //            if (isAdmissionPaymentReceipt)
        //            {
        //                //DTO.LABURNUM.COM.StudentFeeModel model1 = new Component.StudentFee().GetStudentFeeByStudentFeeId(id);
        //                //model = new Component.StudentFeeDetails().GetFeePaidDetailDuringAdmission(model1.StudentId, model1.ClassId, model1.SectionId, model1.AcademicYearId);
        //                //model1.PendingFee = model.PendingFee.GetValueOrDefault();
        //                //model1.CashPaidAmount = model.CashPaidAmount;
        //                //model1.ChequePaidAmount = model.ChequePaidAmount;
        //                //model1.ChequeNumber = model.ChequeNumber;
        //                //model1.ChequeDate = model.ChequeDate;
        //                DTO.LABURNUM.COM.StudentFeeModel model1 = new Component.StudentFee().GetAdmissionFeeReceiptData(id);

        //                html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/GenerateAdmissionReceipt.cshtml", model1);
        //            }
        //            else
        //            {
        //                //model = new Component.StudentFeeDetails().GetStudentFeeDetailsById(id);
        //                //DTO.LABURNUM.COM.StudentFeeDetailModel smodel = new Component.StudentFeeDetails().GetFeePaidDetailDuringMonthlyFeePayment(model.StudentId, model.ClassId, model.SectionId, model.AcademicYearId);

        //                //if (smodel.ChequeStatus == DTO.LABURNUM.COM.Utility.ChequeStatusMaster.GetChequeStatusMasterId(DTO.LABURNUM.COM.Utility.EnumChequeStatusMaster.BOUNCE))
        //                //{
        //                //    model.LastPendingFee = smodel.PendingFee.GetValueOrDefault();
        //                //    model.BounceChequePanelty = Component.Constants.DEFAULTVALUE.CHEQUEBOUNCEPANELTY;
        //                //    model.BounceChequeAmount = smodel.ChequePaidAmount;
        //                //}
        //                //else 
        //                //{
        //                //    model.LastPendingFee = smodel.PendingFee.GetValueOrDefault();
        //                //}
        //                model = new Component.StudentFeeDetails().GetMonthlyFeeReceiptData(id);
        //                html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/GenerateReceipt.cshtml", model);
        //            }
        //            return Json(new { code = 0, message = "success", result = html });
        //        }
        //        catch (Exception)
        //        {
        //            html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Error404.cshtml", model);
        //            return Json(new { code = -1, message = "failed", result = html });
        //        }
        //    }
        //    else
        //    {
        //        return Json(new { code = 99, message = "SessionTimedOut" });
        //    }
        //}

        public ActionResult DeleteClassSubjectFacultyPopup(string id)
        {
            if (sessionManagement.isSessionAlive())
            {
                try
                {
                    LABURNUM.COM.Component.Crypto crypto = new Component.Crypto();
                    string text = crypto.DecryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
                    long cId = Convert.ToInt64(text);
                    DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model = new DTO.LABURNUM.COM.ClassSubjectFacultyTableModel();
                    model = new LABURNUM.COM.Component.ClassSubjectFacultyTable().GetClassSubjectFacultyById(cId);
                    string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/DeleteClassSubjectFacultyPopup.cshtml", model);
                    return Json(new { code = 0, message = "success", result = html });
                }
                catch (Exception)
                {
                    return Json(new { code = -1, message = "failed", result = new LABURNUM.COM.Component.Common().GetErrorView() });
                }
            }
            else
            {
                return Json(new { code = 99, result = "SessionTimedOut" });
            }
        }

        public ActionResult UpdateChequeStatusPopup(long id)
        {
            if (sessionManagement.isSessionAlive())
            {
                string html = string.Empty;
                try
                {
                    DTO.LABURNUM.COM.StudentFeeDetailModel model = new DTO.LABURNUM.COM.StudentFeeDetailModel() { StudentFeeDetailId = id };
                    model.ChequeStatusMasters = new Component.ChequeStatusMaster().GetActiveChequeStatusMasters();
                    html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/UpdateChequeStatusPopup.cshtml", model);
                    return Json(new { code = 0, message = "success", result = html });
                }
                catch (Exception)
                {
                    html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Error404.cshtml", null);
                    return Json(new { code = -2, message = "failed", result = html });
                }
            }
            else
            {
                return Json(new { code = 99, message = "SessionTimedOut" });
            }
        }
        //GenerateReceiptForRePrint
        public ActionResult GenerateReceipt(long id, bool isAdmissionPaymentReceipt)
        {
            if (sessionManagement.isSessionAlive())
            {
                DTO.LABURNUM.COM.StudentFeeDetailModel model = new DTO.LABURNUM.COM.StudentFeeDetailModel();
                string html;
                try
                {
                    if (isAdmissionPaymentReceipt)
                    {
                        DTO.LABURNUM.COM.StudentFeeModel model1 = new Component.StudentFee().GetAdmissionFeeReceiptDataByDetailsId(id);
                        html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/GenerateAdmissionReceipt.cshtml", model1);
                    }
                    else
                    {
                        model = new Component.StudentFeeDetails().GetMonthlyFeeReceiptData(id);
                        html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/GenerateReceipt.cshtml", model);
                    }
                    return Json(new { code = 0, message = "success", result = html });
                }
                catch (Exception)
                {
                    html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Error404.cshtml", model);
                    return Json(new { code = -1, message = "failed", result = html });
                }
            }
            else
            {
                return Json(new { code = 99, message = "SessionTimedOut" });
            }
        }

    }
}
