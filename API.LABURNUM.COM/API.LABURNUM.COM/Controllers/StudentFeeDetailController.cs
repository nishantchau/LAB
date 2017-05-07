using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class StudentFeeDetailController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                long admissionTypeId = 0;
                if (model.IsNewAdmission) { admissionTypeId = DTO.LABURNUM.COM.Utility.AdmissionType.GetValue(DTO.LABURNUM.COM.Utility.EnumAdmissionType.NEWADMISSION); }
                else { admissionTypeId = DTO.LABURNUM.COM.Utility.AdmissionType.GetValue(DTO.LABURNUM.COM.Utility.EnumAdmissionType.READMISSION); }
                //model.StudentFeeId = new FrontEndApi.StudentFeeApi().GetStudentFeeId(model.ClassId, model.SectionId, model.StudentId, admissionTypeId);
                long studentfeeDetailsId = new FrontEndApi.StudentFeeDetailApi().Add(model);
                //sendmail(studentfeeDetailsId);
                return studentfeeDetailsId;
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.StudentFeeDetailApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.StudentFeeDetailApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.StudentFeeDetailModel> SearchStudentFeeDetailByAdvanceSearch(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new StudentFeeDetailHelper(new FrontEndApi.StudentFeeDetailApi().GetStudentFeeDetailByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }

        private void sendmail(long studentfeeDetailId)
        {
            DTO.LABURNUM.COM.StudentFeeDetailModel studentfeeDetail = new StudentFeeDetailHelper(new FrontEndApi.StudentFeeDetailApi().GetStudentFeeDetailByID(studentfeeDetailId)).MapSingle();
            DTO.LABURNUM.COM.StudentModel studentmodel = new StudentHelper(new FrontEndApi.StudentApi().GetStudentByStudentId(studentfeeDetail.StudentId)).MapSingle();

            string from = Component.Constants.MAIL.MAILSENTFROM;
            string subject = "Thank you For Paying Fee For the Month Of " + studentfeeDetail.MonthName + " At Laburnum Public School.";
            string body = new API.LABURNUM.COM.Component.HtmlHelper().RenderViewToString("User", "~/Views/Partial/ThankYouMailOnPaymentOfMonthlyFee.cshtml", studentfeeDetail);
            if (new Component.Mailer().MailSend(studentmodel.EmailId, "", body, from, subject))
            {
            }
            else
            {
            }
        }
    }
}