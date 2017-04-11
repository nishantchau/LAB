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
        public DTO.LABURNUM.COM.FeeReportingResultModel SearchStudentReporting(DTO.LABURNUM.COM.FeeReportingModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                DTO.LABURNUM.COM.FeeReportingResultModel report = new DTO.LABURNUM.COM.FeeReportingResultModel();
                List<API.LABURNUM.COM.StudentFee> dbStudentFee = new FrontEndApi.StudentFeeApi().GetStudentFeeByAdvanceSearch(new DTO.LABURNUM.COM.StudentFeeModel() { AcademicYearId = model.AcademicYearId, StudentId = model.StudentId });
                if (dbStudentFee.Count > 0)
                {
                    report = new Component.FeeReportingResultModelHelper().GetFeeReportingResultModel(dbStudentFee[0]);
                }
                report.MonthlyFeeDetails = new StudentFeeDetailHelper(new FrontEndApi.StudentFeeDetailApi().GetStudentFeeDetailByAdvanceSearch(new DTO.LABURNUM.COM.StudentFeeDetailModel() { AcademicYearId = model.AcademicYearId, StudentId = model.StudentId })).Map();
                return report;
            }
            else
            {
                return null;
            }
        }
    }
}