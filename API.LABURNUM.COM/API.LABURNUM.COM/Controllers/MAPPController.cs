using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class MAPPController : ApiController
    {
        private DTO.LABURNUM.COM.ApiResponseModel GetApiResponseModel(string message, bool status, object model)
        {
            DTO.LABURNUM.COM.ApiResponseModel apiresponsemodel = new DTO.LABURNUM.COM.ApiResponseModel() { Message = message, Status = status, Result = model };
            return apiresponsemodel;
        }

        public dynamic DoLogin(DTO.LABURNUM.COM.LoginModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                DTO.LABURNUM.COM.SessionModel sessionmodel = new DTO.LABURNUM.COM.SessionModel();
                try
                {
                    if (model.LoginBy == 0)
                    {
                        return GetApiResponseModel("Login By Cannot Be Null.", false, null);
                    }


                    if (model.LoginBy == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.STUDENT))
                    {
                        if (model.UserName == "" || model.Password == "")
                        {
                            return GetApiResponseModel("Student UserName Or Password Cannnot Be Blank.", false, null);
                        }

                        DTO.LABURNUM.COM.StudentModel studentmodel = new DTO.LABURNUM.COM.StudentModel() { StudentUserName = model.UserName, StudentPassword = model.Password, ApiClientModel = model.ApiClientModel, IsStudentLogin = true };

                        sessionmodel.StudentModel = new API.LABURNUM.COM.Controllers.StudentController().ParentStudentLogin(studentmodel);
                    }
                    if (model.LoginBy == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PARENT))
                    {

                        if (model.UserName == "" || model.Password == "")
                        {
                            return GetApiResponseModel("Parent UserName Or Password Cannnot Be Blank.", false, null);
                        }

                        DTO.LABURNUM.COM.StudentModel studentmodel = new DTO.LABURNUM.COM.StudentModel() { ParentUserName = model.UserName, ParentPassword = model.Password, ApiClientModel = model.ApiClientModel };
                        sessionmodel.StudentModel = new API.LABURNUM.COM.Controllers.StudentController().ParentStudentLogin(studentmodel);
                    }
                    if (model.LoginBy == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.FACULTY))
                    {
                        if (model.UserName == "" || model.Password == "")
                        {
                            return GetApiResponseModel("Faculty UserName Or Password Cannnot Be Blank.", false, null);
                        }

                        DTO.LABURNUM.COM.FacultyModel facultyModel = new DTO.LABURNUM.COM.FacultyModel() { UserName = model.UserName, Password = model.Password, ApiClientModel = model.ApiClientModel };
                        sessionmodel.FacultyModel = new API.LABURNUM.COM.Controllers.FacultyController().FacultyLogin(facultyModel);
                    }

                    sessionmodel.LoginBy = model.LoginBy;

                    DTO.LABURNUM.COM.LoginActivityModel lmodel = new DTO.LABURNUM.COM.LoginActivityModel() { UserTypeId = sessionmodel.LoginBy, StudentId = sessionmodel.LoginByUserId, ClientId = new FrontEndApi.ApiClientApi().GetClientId(model.ApiClientModel.UserName, model.ApiClientModel.Password) };
                    sessionmodel.LoginActivityId = new FrontEndApi.LoginActivityApi().Add(lmodel);

                    return GetApiResponseModel("SuccessFully Performed", true, sessionmodel);
                }
                catch (Exception ex)
                {
                    return GetApiResponseModel(ex.Message.ToString(), false, null);
                }
            }
            else
            {
                return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null);
            }
        }

        public dynamic SearchFeeResult(DTO.LABURNUM.COM.FeeReportingModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.ClassId == 0 && model.SectionId == 0 && model.StudentId == 0 && model.StartDate.Year == 0001 && model.EndDate.Year == 0001)
                {
                    return GetApiResponseModel("Search Creteria Cannot Be Blank.", false, null);
                }

                DTO.LABURNUM.COM.StudentFeeModel studentFeeModel = new Controllers.ReportsController().GetStudentFeeModel(model);

                List<DTO.LABURNUM.COM.StudentFeeModel> studentFeeList = new StudentFeeHelper(new FrontEndApi.StudentFeeApi().GetStudentFeeByAdvanceSearch(studentFeeModel)).Map();

                return GetApiResponseModel("Successfully Performed.", true, studentFeeList);
            }
            else
            {
                return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null);
            }
        }
    }
}