using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class FeeReportingController : ApiController
    {
        public List<DTO.LABURNUM.COM.FeeReportingResultModel> SearchStudentReporting(DTO.LABURNUM.COM.FeeReportingModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
               List<DTO.LABURNUM.COM.FeeReportingResultModel>  report = new List<DTO.LABURNUM.COM.FeeReportingResultModel> ();
                List<API.LABURNUM.COM.StudentFee> dbStudentFee = new FrontEndApi.StudentFeeApi().GetStudentFeeByAdvanceSearch(new DTO.LABURNUM.COM.StudentFeeModel() { AcademicYearId = model.AcademicYearId, StudentId = model.StudentId });
                List<API.LABURNUM.COM.StudentFeeDetail> dbstudentFeeDetails = new FrontEndApi.StudentFeeDetailApi().GetStudentFeeDetailByAdvanceSearch(new DTO.LABURNUM.COM.StudentFeeDetailModel() { AcademicYearId = model.AcademicYearId, StudentId = model.StudentId });
                if (dbStudentFee.Count > 0)
                {
                    report = new Component.FeeReportingResultModelHelper().GetFeeReportingResultModel(dbStudentFee[0],dbstudentFeeDetails);

                }
                //report.MonthlyFeeDetails = new StudentFeeDetailHelper(new FrontEndApi.StudentFeeDetailApi().GetStudentFeeDetailByAdvanceSearch(new DTO.LABURNUM.COM.StudentFeeDetailModel() { AcademicYearId = model.AcademicYearId, StudentId = model.StudentId })).Map();
                //double y = 0;
                //foreach (DTO.LABURNUM.COM.StudentFeeDetailModel item in report.MonthlyFeeDetails)
                //{
                //    y = y + item.TotalPayableAmount;
                //}
                //report.TotalPaidOnMonthly = y;
                return report;
            }
            else
            {
                return null;
            }
        }
    }
}