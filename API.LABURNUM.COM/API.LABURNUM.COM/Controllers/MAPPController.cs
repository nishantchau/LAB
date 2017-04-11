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
                    API.LABURNUM.COM.AcademicYearTable acy = new FrontEndApi.AcademicYearTableApi().GetAcademicYearByYear(System.DateTime.Now.Year);
                    sessionmodel.AcademicYear = acy.AcademicYear;
                    sessionmodel.AcademicYearId = acy.AcademicYearTableId;
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

        public dynamic SearchActiveSalutations(DTO.LABURNUM.COM.SalutationModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                List<DTO.LABURNUM.COM.SalutationModel> dbSalutations = new SalutationHelper(new FrontEndApi.SalutationApi().GetActiveSalutations()).Map();
                return GetApiResponseModel("Successfully Performed.", true, dbSalutations);
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }

        public dynamic SearchSalutationById(DTO.LABURNUM.COM.SalutationModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.SalutationId <= 0) { return GetApiResponseModel("Salutation Id Cannnot be null.", true, null); }
                List<DTO.LABURNUM.COM.SalutationModel> dbClasses = new SalutationHelper(new FrontEndApi.SalutationApi().GetSalutationByAdvanceSearch(model)).Map();
                if (dbClasses.Count == 0) { return GetApiResponseModel("No Record Found For Given Salutation Id", true, null); }
                if (dbClasses.Count > 1) { return GetApiResponseModel("More Than One Record Found Please Contact Administrator", true, null); }
                return GetApiResponseModel("Successfully Performed.", true, dbClasses[0]);
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }

        public dynamic SearchAllClasses(DTO.LABURNUM.COM.ClassModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                List<DTO.LABURNUM.COM.ClassModel> dbClasses = new ClassHelper(new FrontEndApi.ClassApi().GetActiveClass()).Map();
                return GetApiResponseModel("Successfully Performed.", true, dbClasses);
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }

        public dynamic SearchClassById(DTO.LABURNUM.COM.ClassModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.ClassId <= 0) { return GetApiResponseModel("Class Id Cannnot be null.", true, null); }

                List<DTO.LABURNUM.COM.ClassModel> dbClasses = new ClassHelper(new FrontEndApi.ClassApi().GetClassByAdvanceSearch(model)).Map();
                if (dbClasses.Count == 0) { return GetApiResponseModel("No Record Found For Given Class Id", true, null); }
                if (dbClasses.Count > 1) { return GetApiResponseModel("More Than One Record Please Contact Administrator", true, null); }
                return GetApiResponseModel("Successfully Performed.", true, dbClasses[0]);
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }

        public dynamic SearchAllSections(DTO.LABURNUM.COM.SectionModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                List<DTO.LABURNUM.COM.SectionModel> dbSections = new SectionHelper(new FrontEndApi.SectionApi().GetActiveSections()).Map();
                return GetApiResponseModel("Successfully Performed.", true, dbSections);
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }

        public dynamic SearchSectionByClassId(DTO.LABURNUM.COM.SectionModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.ClassId <= 0) { return GetApiResponseModel("Class Id Cannnot Be Null.", true, null); }

                List<DTO.LABURNUM.COM.SectionModel> dbSections = new SectionHelper(new FrontEndApi.SectionApi().GetSectionByAdvanceSearch(model)).Map();
                if (dbSections.Count == 0) { return GetApiResponseModel("No Section Found For Given Class Id", true, dbSections); }
                return GetApiResponseModel("Successfully Performed.", true, dbSections);
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }

        public dynamic SearchSectionBySectionId(DTO.LABURNUM.COM.SectionModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.SectionId <= 0) { return GetApiResponseModel("Section Id Cannnot Be Null.", true, null); }

                List<DTO.LABURNUM.COM.SectionModel> dbSections = new SectionHelper(new FrontEndApi.SectionApi().GetSectionByAdvanceSearch(model)).Map();
                if (dbSections.Count == 0) { return GetApiResponseModel("No Record Found For Given Section Id", true, null); }
                if (dbSections.Count > 1) { return GetApiResponseModel("More Than One Record Found Please Contact Administrator", true, null); }
                return GetApiResponseModel("Successfully Performed.", true, dbSections[0]);
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }

        public dynamic SearchAllUserTypes(DTO.LABURNUM.COM.UserTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                List<DTO.LABURNUM.COM.UserTypeModel> dbUserTypes = new UserTypeHelper(new FrontEndApi.UserTypeApi().GetActiveUserTypes()).Map();
                return GetApiResponseModel("Successfully Performed.", true, dbUserTypes);
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }

        public dynamic AddAttendance(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {

                if (model.ClassId <= 0 && model.SectionId <= 0 && model.StudentId <= 0) { return GetApiResponseModel("Class Id, SectionId & Student Id Cannnot be Zero or Less Than Zero.", true, null); }
                if (model.ClassId <= 0) { return GetApiResponseModel("Class Id Cannnot be null.", true, null); }
                if (model.SectionId <= 0) { return GetApiResponseModel("Section Id Cannnot be null.", true, null); }
                if (model.StudentId <= 0) { return GetApiResponseModel("Student Id Cannnot be null.", true, null); }
                long id = new Controllers.CommonAttendanceController().Add(model);
                //if (id <= 0) { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
                return GetApiResponseModel("Attendance Submitted Successfully", false, id);
            }
            else
            {
                return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null);
            }
        }

        public dynamic AddAttendanceList(List<DTO.LABURNUM.COM.CommonAttendanceModel> model)
        {
            foreach (DTO.LABURNUM.COM.CommonAttendanceModel item in model)
            {
                AddAttendance(item);
            }
            return GetApiResponseModel("Attendance Submitted Successfully", false, null);
        }

        public dynamic SearchFacultyByFacultyId(DTO.LABURNUM.COM.FacultyModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.FacultyId <= 0) { return GetApiResponseModel("Faculty Id Cannnot be Zero or Less Than Zero.", true, null); }
                List<DTO.LABURNUM.COM.FacultyModel> dbFacutlies = new FacultyHelper(new FrontEndApi.FacultyApi().GetFacultyByAdvanceSearch(model)).Map();
                if (dbFacutlies.Count == 0) { return GetApiResponseModel("No Record Found For Given Faculty Id", true, null); }
                if (dbFacutlies.Count > 1) { return GetApiResponseModel("More Than One Record Found Please Contact Administrator", true, null); }
                return GetApiResponseModel("Successfully Performed.", true, dbFacutlies[0]);
            }
            else
            {
                return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null);
            }
        }

        public dynamic UpdateFacultyProfile(DTO.LABURNUM.COM.FacultyModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.FacultyId <= 0) { return GetApiResponseModel("Faculty Id Cannnot be Zero or Less Than Zero.", false, null); }
                if (model.FacultyId <= 0 || model.NewPassword == null) { return GetApiResponseModel("Password Cannnot be Null.", false, null); }
                new FrontEndApi.FacultyApi().UpdateProfile(model);
                return GetApiResponseModel("Profile Updated Successfully.", true, null);
            }
            else
            {
                return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null);
            }
        }

        public dynamic LateFeePanelties(DTO.LABURNUM.COM.LateFeePaneltyMasterModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                List<DTO.LABURNUM.COM.LateFeePaneltyMasterModel> dbLateFeePanelties = new LateFeePaneltyMasterHelper(new FrontEndApi.LateFeePaneltyMasterApi().GetActiveLateFeePaneltyMaster()).Map();
                return GetApiResponseModel("Successfully Performed.", false, dbLateFeePanelties);
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }

        public dynamic SearchStudentByStudentId(DTO.LABURNUM.COM.StudentModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.StudentId <= 0) { return GetApiResponseModel("Student Id Cannnot be Zero or Less Than Zero.", true, null); }
                List<DTO.LABURNUM.COM.StudentModel> dbStudents = new StudentHelper(new FrontEndApi.StudentApi().GetStudentByAdvanceSearch(model)).Map();
                if (dbStudents.Count == 0) { return GetApiResponseModel("No Record Found For Given Student Id", true, null); }
                if (dbStudents.Count > 1) { return GetApiResponseModel("More Than One Record Found Please Contact Administrator", true, null); }
                return GetApiResponseModel("Successfully Performed.", true, dbStudents[0]);
            }
            else
            {
                return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null);
            }
        }

        public dynamic UpdateStudentProfile(DTO.LABURNUM.COM.StudentModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.StudentId <= 0) { return GetApiResponseModel("Student Id Cannnot be Zero or Less Than Zero.", false, null); }
                if (model.StudentId <= 0 || model.StudentPassword == null) { return GetApiResponseModel("Password Cannnot be Null.", false, null); }
                new FrontEndApi.StudentApi().UpdateStudentProfile(model);
                return GetApiResponseModel("Profile Updated Successfully.", true, null);
            }
            else
            {
                return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null);
            }
        }

        public dynamic UpdateParentProfile(DTO.LABURNUM.COM.StudentModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.StudentId <= 0) { return GetApiResponseModel("Student Id Cannnot be Zero or Less Than Zero.", false, null); }
                if (model.StudentId <= 0 || model.ParentPassword == null) { return GetApiResponseModel("Password Cannnot be Null.", false, null); }
                new FrontEndApi.StudentApi().UpdateStudentProfile(model);
                return GetApiResponseModel("Profile Updated Successfully.", true, null);
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