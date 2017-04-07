using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class StudentController : ApiController
    {
        public DTO.LABURNUM.COM.StudentModel Add(DTO.LABURNUM.COM.StudentModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                DTO.LABURNUM.COM.StudentModel smodel = new StudentHelper(new FrontEndApi.StudentApi().Add(model)).MapSingle();
                //sendmail(smodel);
                return smodel;
            }
            else
            {
                return null;
            }
        }

        public DTO.LABURNUM.COM.StudentModel Update(DTO.LABURNUM.COM.StudentModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new StudentHelper(new FrontEndApi.StudentApi().Update(model)).MapSingle();
            }
            else { return null; }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.StudentModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.StudentApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.StudentModel> SearchStudentByAdvanceSearch(DTO.LABURNUM.COM.StudentModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new StudentHelper(new FrontEndApi.StudentApi().GetStudentByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }

        public DTO.LABURNUM.COM.StudentModel ParentStudentLogin(DTO.LABURNUM.COM.StudentModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                DTO.LABURNUM.COM.StudentModel studentmodel = new DTO.LABURNUM.COM.StudentModel();
                if (model.IsStudentLogin)
                {
                    studentmodel = new StudentHelper(new FrontEndApi.StudentApi().StudentLogin(model.StudentUserName, model.StudentPassword)).MapSingle();
                }
                else
                {
                    studentmodel = new StudentHelper(new FrontEndApi.StudentApi().ParentLogin(model.ParentUserName, model.ParentPassword)).MapSingle();
                }
                return studentmodel;
            }
            else
            {
                return null;
            }
        }

        public void UpdateStudentProfile(DTO.LABURNUM.COM.StudentModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.StudentApi().UpdateStudentProfile(model);
            }
        }

        public void UpdateParentProfile(DTO.LABURNUM.COM.StudentModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.StudentApi().UpdateParentProfile(model);
            }
        }

        private void sendmail(DTO.LABURNUM.COM.StudentModel user)
        {
            string from = "admin@laburnumpublicschool.com";
            string subject = "Thank For Admission at Laburnum Public School";
            string body = new API.LABURNUM.COM.Component.HtmlHelper().RenderViewToString("User", "~/Views/Partial/NewAdmissionThankyouEmail.cshtml", user);
            if (new Component.Mailer().MailSend(user.EmailId, "", body, from, subject))
            {
            }
            else
            {
            }
        }
    }
}