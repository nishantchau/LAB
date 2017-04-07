using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class ReportsController : ApiController
    {
        public List<DTO.LABURNUM.COM.StudentFeeModel> SearchStudentFeeReports(DTO.LABURNUM.COM.FeeReportingModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new StudentFeeHelper(new FrontEndApi.StudentFeeApi().GetStudentFeeByAdvanceSearch(GetStudentFeeModel(model))).Map();
            }
            else
            {
                return null;
            }
        }

        public DTO.LABURNUM.COM.StudentFeeModel GetStudentFeeModel(DTO.LABURNUM.COM.FeeReportingModel model)
        {
            DTO.LABURNUM.COM.StudentFeeModel studentFeeModel = new DTO.LABURNUM.COM.StudentFeeModel()
            {
                ClassId = model.ClassId,
                StudentId = model.StudentId,
                SectionId = model.SectionId,
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };
            return studentFeeModel;
        }
    }
}