using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

namespace LABURNUM.COM.Controllers
{
    public class StudentFeeController : MyBaseController
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();
        // GET: /StudentFee/

        public ActionResult Index(long studentId, long classId, long sectionId, bool isNewAdmission)
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
            {
                DTO.LABURNUM.COM.FeeModel feemodel = new LABURNUM.COM.Component.Fee().GetFeeByClassIdandAdmissionType(classId, isNewAdmission);

                DTO.LABURNUM.COM.StudentFeeModel model = new DTO.LABURNUM.COM.StudentFeeModel()
                {
                    StudentId = studentId,
                    ClassId = classId,
                    IsNewAdmission = isNewAdmission,
                    SectionId = sectionId
                };

                if (isNewAdmission) { model.AdmissionTypeId = DTO.LABURNUM.COM.Utility.AdmissionType.GetValue(DTO.LABURNUM.COM.Utility.EnumAdmissionType.NEWADMISSION); }
                else { model.AdmissionTypeId = DTO.LABURNUM.COM.Utility.AdmissionType.GetValue(DTO.LABURNUM.COM.Utility.EnumAdmissionType.READMISSION); }

                model.AdmissionFee = feemodel.AdmissionFee;
                model.AnnualCharges = feemodel.AnnualCharges.GetValueOrDefault();
                model.DevelopementFee = feemodel.DevelopementCharges.GetValueOrDefault();
                model.ExamFee = feemodel.ExamFee.GetValueOrDefault();
                model.SportsFee = feemodel.SportsFee.GetValueOrDefault();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult AddStudentFee(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            try
            {
                model.CollectedById = sessionManagement.GetFacultyId();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("StudentFee", "Add", model);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    var id = Convert.ToInt16(data);
                    return Json(new { code = 0, message = "success", id = id });
                }
                else
                {
                    return Json(new { code = -1, message = "failed" });
                }
            }
            catch (Exception)
            {

                return Json(new { code = -2, message = "failed" });
            }
        }

        public ActionResult PayMonthlyFee(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            try
            {
                if (new Component.StudentFeeDetails().IsAlreadyPaidForThisMonth(model.PayForTheMonth, model.StudentId, model.ClassId, model.SectionId))
                {
                    return Json(new { code = -3, message = "failed" });
                }
                else
                {
                    model.CollectedById = sessionManagement.GetFacultyId();
                    model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                    HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("StudentFeeDetail", "Add", model);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        int id = Convert.ToInt16(data);
                        return Json(new { code = 0, message = "success", id = id });
                    }
                    else
                    {
                        return Json(new { code = -1, message = "failed" });
                    }
                }
            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }
    }
}
