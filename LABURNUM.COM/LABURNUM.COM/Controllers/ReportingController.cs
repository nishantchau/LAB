using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                DTO.LABURNUM.COM.StudentFeeModel model = new DTO.LABURNUM.COM.StudentFeeModel() { StartDate = System.DateTime.Now, EndDate = System.DateTime.Now };
                List<DTO.LABURNUM.COM.StudentFeeModel> dbStudentFees = new Component.StudentFee().GetStudentFeeByAdvanceSearch(model);
                double x = 0, y = 0, totalamount = 0;
                foreach (DTO.LABURNUM.COM.StudentFeeModel item in dbStudentFees)
                {
                    x = x + item.TotalPayableAmount;
                    foreach (DTO.LABURNUM.COM.StudentFeeDetailModel item1 in item.StudentFeeDetails)
                    {
                        y = y + item1.TotalPayableAmount;
                        item.PaidMonthlyFee = item1.TotalPayableAmount;
                    }

                    totalamount = x + y;
                }
                if (dbStudentFees.Count > 0)
                {
                    dbStudentFees[0].TotalEarningFromAdmission = x;
                    dbStudentFees[0].TotalEarningFromMonthlyFee = y;
                    dbStudentFees[0].TotalEarning = totalamount;
                }
                return View(dbStudentFees);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
