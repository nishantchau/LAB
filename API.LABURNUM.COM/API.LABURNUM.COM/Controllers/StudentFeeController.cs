using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class StudentFeeController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                long studentfeeId= new FrontEndApi.StudentFeeApi().Add(model);
                //sendmail(studentfeeId);
                return studentfeeId;
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.StudentFeeApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.StudentFeeApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.StudentFeeModel> SearchStudentFeeByAdvanceSearch(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new StudentFeeHelper(new FrontEndApi.StudentFeeApi().GetStudentFeeByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }

        private void sendmail(long studentId)
        {
            DTO.LABURNUM.COM.StudentModel studentmodel = new StudentHelper(new FrontEndApi.StudentApi().GetStudentByStudentId(studentId)).MapSingle();

            string from = Component.Constants.MAIL.MAILSENTFROM;
            string subject = Component.Constants.MAILSUBJECT.ADMISSIONSUBJECT;
            string body = new API.LABURNUM.COM.Component.HtmlHelper().RenderViewToString("User", "~/Views/Partial/NewAdmissionThankyouEmail.cshtml", studentmodel);
            if (new Component.Mailer().MailSend(studentmodel.EmailId, "", body, from, subject))
            {
            }
            else
            {
            }
        }
    }
}