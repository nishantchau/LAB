using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.LABURNUM.COM.Controllers
{
    public class MobileApp : ApiController
    {
        public dynamic DoLogin(DTO.LABURNUM.COM.LoginModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.LoginBy == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.STUDENT))
                {
                    DTO.LABURNUM.COM.StudentModel studentmodel = new DTO.LABURNUM.COM.StudentModel() { StudentUserName = model.UserName, StudentPassword = model.Password, ApiClientModel = model.ApiClientModel, IsStudentLogin = true };
                    return new API.LABURNUM.COM.Controllers.StudentController().ParentStudentLogin(studentmodel);

                }
                if (model.LoginBy == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PARENT))
                {
                    DTO.LABURNUM.COM.StudentModel studentmodel = new DTO.LABURNUM.COM.StudentModel() { ParentUserName = model.UserName, ParentPassword = model.Password, ApiClientModel = model.ApiClientModel, IsStudentLogin = false };
                    return new API.LABURNUM.COM.Controllers.StudentController().ParentStudentLogin(studentmodel);
                }
                if (model.LoginBy == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.FACULTY))
                {
                    DTO.LABURNUM.COM.FacultyModel facultyModel = new DTO.LABURNUM.COM.FacultyModel() { UserName = model.UserName, Password = model.Password, ApiClientModel = model.ApiClientModel };
                    return new API.LABURNUM.COM.Controllers.FacultyController().FacultyLogin(facultyModel);
                }
                return model;
            }
            else { return null; }
        }
    }
}