using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.LABURNUM.COM.Controllers
{
    public class LoginController : ApiController
    {
        private string GetEncryptedPassword(string password)
        {
            return new API.LABURNUM.COM.Component.PasswordConvertor().Password(password);
        }

        public DTO.LABURNUM.COM.SessionModel DoLogin(DTO.LABURNUM.COM.LoginModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                DTO.LABURNUM.COM.SessionModel sessionmodel = new DTO.LABURNUM.COM.SessionModel();
                model.Password = GetEncryptedPassword(model.Password);
                if (model.LoginBy == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.STUDENT))
                {
                    DTO.LABURNUM.COM.StudentModel studentmodel = new DTO.LABURNUM.COM.StudentModel() { StudentUserName = model.UserName, StudentPassword = model.Password, ApiClientModel = model.ApiClientModel, IsStudentLogin = true };
                    sessionmodel.StudentModel = new API.LABURNUM.COM.Controllers.StudentController().ParentStudentLogin(studentmodel);
                    sessionmodel.LoginByUserId = sessionmodel.StudentModel.StudentId;
                    sessionmodel.LoginBy = model.LoginBy;
                }
                if (model.LoginBy == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PARENT))
                {
                    DTO.LABURNUM.COM.StudentModel studentmodel = new DTO.LABURNUM.COM.StudentModel() { ParentUserName = model.UserName, ParentPassword = model.Password, ApiClientModel = model.ApiClientModel };
                    sessionmodel.StudentModel = new API.LABURNUM.COM.Controllers.StudentController().ParentStudentLogin(studentmodel);
                    sessionmodel.LoginByUserId = sessionmodel.StudentModel.StudentId;
                    sessionmodel.LoginBy = model.LoginBy;
                }
                if (model.LoginBy == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.FACULTY))
                {
                    DTO.LABURNUM.COM.FacultyModel facultyModel = new DTO.LABURNUM.COM.FacultyModel() { UserName = model.UserName, Password = model.Password, ApiClientModel = model.ApiClientModel };
                    sessionmodel.FacultyModel = new API.LABURNUM.COM.Controllers.FacultyController().FacultyLogin(facultyModel);
                    sessionmodel.LoginByUserId = sessionmodel.FacultyModel.FacultyId;
                    sessionmodel.LoginBy = sessionmodel.FacultyModel.UserTypeId;
                }

                DTO.LABURNUM.COM.LoginActivityModel lmodel = new DTO.LABURNUM.COM.LoginActivityModel() { UserTypeId = sessionmodel.LoginBy, StudentId = sessionmodel.LoginByUserId, ClientId = new FrontEndApi.ApiClientApi().GetClientId(model.ApiClientModel.UserName, model.ApiClientModel.Password) };
                sessionmodel.LoginActivityId = new FrontEndApi.LoginActivityApi().Add(lmodel);

                return sessionmodel;
            }
            else
            {
                return null;
            }
        }
    }
}