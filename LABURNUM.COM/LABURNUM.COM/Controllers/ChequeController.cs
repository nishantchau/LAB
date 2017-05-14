using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class ChequeController : MyBaseController
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();
        //
        // GET: /Cheque/

        public ActionResult SearchChequeIndex()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ACCOUNT))
            {
                DTO.LABURNUM.COM.StudentFeeDetailModel model = new DTO.LABURNUM.COM.StudentFeeDetailModel();
                model.ChequeStatusMasters = new Component.ChequeStatusMaster().GetActiveChequeStatusMasters();
                return View(model);
            }
            else
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }
        }

        public ActionResult SerchChequeDetails(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            try
            {
                List<DTO.LABURNUM.COM.StudentFeeDetailModel> dblist = new Component.StudentFeeDetails().GetStudentFeeDetailByAdvanceSearch(model);
                string html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Cheque/SearchResult.cshtml", dblist);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed" });
            }

        }

        public ActionResult SeeSubmittedChequeDetails()
        {
            try
            {
                List<DTO.LABURNUM.COM.StudentFeeDetailModel> dblist = new Component.StudentFeeDetails().GetStudentFeeDetailByAdvanceSearch(new DTO.LABURNUM.COM.StudentFeeDetailModel() { ChequeStatus = DTO.LABURNUM.COM.Utility.ChequeStatusMaster.GetChequeStatusMasterId(DTO.LABURNUM.COM.Utility.EnumChequeStatusMaster.SUBMITTED) });
                string html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "", dblist);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }

        public ActionResult UpdateChequeStatus(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            try
            {
                if (new Component.StudentFeeDetails().UpdateChequeStatus(model.StudentFeeDetailId, model.ChequeStatus.GetValueOrDefault(), model.ChequeBounceRemarks)) { return Json(new { code = 0, message = "success" }); }
                else { return Json(new { code = -1, message = "failed" }); }
            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }
    }
}
