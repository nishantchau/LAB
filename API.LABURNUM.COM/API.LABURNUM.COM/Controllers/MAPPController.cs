﻿using System;
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
        private string GetEncryptedPassword(string password)
        {
            return new API.LABURNUM.COM.Component.PasswordConvertor().Password(password);
        }

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
                //model.Password = GetEncryptedPassword(model.Password);
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
                        sessionmodel.LoginByUserId = sessionmodel.StudentModel.StudentId;
                    }
                    if (model.LoginBy == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PARENT))
                    {

                        if (model.UserName == "" || model.Password == "")
                        {
                            return GetApiResponseModel("Parent UserName Or Password Cannnot Be Blank.", false, null);
                        }

                        DTO.LABURNUM.COM.StudentModel studentmodel = new DTO.LABURNUM.COM.StudentModel() { ParentUserName = model.UserName, ParentPassword = model.Password, ApiClientModel = model.ApiClientModel };
                        sessionmodel.StudentModel = new API.LABURNUM.COM.Controllers.StudentController().ParentStudentLogin(studentmodel);
                        sessionmodel.LoginByUserId = sessionmodel.StudentModel.StudentId;
                    }
                    if (model.LoginBy == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.FACULTY))
                    {
                        if (model.UserName == "" || model.Password == "")
                        {
                            return GetApiResponseModel("Faculty UserName Or Password Cannnot Be Blank.", false, null);
                        }

                        DTO.LABURNUM.COM.FacultyModel facultyModel = new DTO.LABURNUM.COM.FacultyModel() { UserName = model.UserName, Password = model.Password, ApiClientModel = model.ApiClientModel };
                        sessionmodel.FacultyModel = new API.LABURNUM.COM.Controllers.FacultyController().FacultyLogin(facultyModel);
                        sessionmodel.LoginByUserId = sessionmodel.FacultyModel.FacultyId;
                    }

                    sessionmodel.LoginBy = model.LoginBy;
                    API.LABURNUM.COM.AcademicYearTable acy = new FrontEndApi.AcademicYearTableApi().GetAcademicYearByYear(new Component.Utility().GetISTDateTime().Year);
                    sessionmodel.AcademicYear = acy.AcademicYear;
                    sessionmodel.AcademicYearId = acy.AcademicYearTableId;
                    sessionmodel.LastLoginAt = new FrontEndApi.LoginActivityApi().GetLastLogin(sessionmodel.LoginByUserId, sessionmodel.LoginBy);
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
                if (model.StudentPassword == null || model.StudentPassword == "") { return GetApiResponseModel("Password Cannnot be Null.", false, null); }
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
                if (model.ParentPassword == null || model.ParentPassword == "") { return GetApiResponseModel("Password Cannnot be Null.", false, null); }
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

        public dynamic SearchStudentListForAttendance(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.ClassId <= 0 && model.SectionId <= 0) { return GetApiResponseModel("Class Id And Section Id Cannot be blank.", false, null); }
                if (model.ClassId <= 0) { return GetApiResponseModel("Class Id Id Cannot be blank.", false, null); }
                if (model.SectionId <= 0) { return GetApiResponseModel("Section Id Cannot be blank.", false, null); }
                List<DTO.LABURNUM.COM.CommonAttendanceModel> dbList = new List<DTO.LABURNUM.COM.CommonAttendanceModel>();
                List<API.LABURNUM.COM.Student> dbStudents = new FrontEndApi.StudentApi().GetStudentByAdvanceSearch(new DTO.LABURNUM.COM.StudentModel() { ClassId = model.ClassId, SectionId = model.SectionId });
                foreach (API.LABURNUM.COM.Student item in dbStudents)
                {
                    dbList.Add(new DTO.LABURNUM.COM.CommonAttendanceModel()
                    {
                        ClassId = item.ClassId,
                        SectionId = item.SectionId,
                        StudentId = item.StudentId,
                        StudentName = item.FirstName + " " + item.MiddleName + " " + item.LastName,
                        Mobile = item.Mobile,
                        FatherName = item.FatherName,
                        AdmissionNumber = item.AdmissionNumber,
                    });
                }
                return GetApiResponseModel("Successfully Performed.", true, dbList);
            }
            else
            {
                return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null);
            }
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
                return GetApiResponseModel("Morning Attendance Submitted Successfully", true, id);
            }
            else
            {
                return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null);
            }
        }

        public dynamic AddAttendanceList(List<DTO.LABURNUM.COM.CommonAttendanceModel> model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model[0].ApiClientModel.UserName, model[0].ApiClientModel.Password))
            {
                foreach (DTO.LABURNUM.COM.CommonAttendanceModel item in model)
                {
                    AddAttendance(item);
                }
                return GetApiResponseModel("Morning Attendance List Submitted Successfully", true, null);
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }

        public dynamic SubmitAfterLunchAttendance(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.AttendanceId <= 0 && model.ClassId <= 0 && model.StudentId <= 0) { return GetApiResponseModel("Class Id, AttendanceId & StudentId Cannnot be Zero or Less Than Zero.", true, null); }
                if (model.AttendanceId <= 0) { return GetApiResponseModel("Attendance Id Cannnot be null.", true, null); }
                if (model.ClassId <= 0) { return GetApiResponseModel("Class Id Cannnot be null.", true, null); }
                if (model.StudentId <= 0) { return GetApiResponseModel("Student Id Cannnot be null.", true, null); }
                new Controllers.CommonAttendanceController().SubmitAfterLunchAttendanceAsPerClass(model);
                return GetApiResponseModel("After Lunch Attendance Submitted Successfully", true, null);
            }
            else
            {
                return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null);
            }
        }

        public dynamic SubmitAfterLunchAttendanceList(List<DTO.LABURNUM.COM.CommonAttendanceModel> model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model[0].ApiClientModel.UserName, model[0].ApiClientModel.Password))
            {
                foreach (DTO.LABURNUM.COM.CommonAttendanceModel item in model)
                {
                    SubmitAfterLunchAttendance(item);
                }
                return GetApiResponseModel("After Lunch Attendance List Submitted Successfully", true, null);
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }

        public dynamic SearchAttendanceByAdvanceSearch(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return GetApiResponseModel("Search Attendance Result", true, new Controllers.CommonAttendanceController().SearchAttendanceByAdvanceSearch(model));
            }
            else
            {
                return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null);
            }
        }

        public dynamic UpdateLoginActivity(DTO.LABURNUM.COM.LoginActivityModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.LoginActivityId == 0) { return GetApiResponseModel("Login Activity Id Cannot be Zero", true, null); }
                new FrontEndApi.LoginActivityApi().Update(model);
                return GetApiResponseModel("Logout Activity Update SuccessFully", true, null);
            }
            else
            {
                return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null);
            }
        }

        public dynamic AddHomeWork(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.FacultyId == 0) { return GetApiResponseModel("Faculty Id Cannot be Zero", true, null); }
                if (model.ClassId == 0) { return GetApiResponseModel("Class Id Cannot be Zero", true, null); }
                if (model.SectionId == 0) { return GetApiResponseModel("Section Id Cannot be Zero", true, null); }
                if (model.SubjectId == 0) { return GetApiResponseModel("Subject Id Cannot be Zero", true, null); }
                if (model.HomeWorkText.Trim() == null) { return GetApiResponseModel("HomeWork Text Cannot be Null", true, null); }
                if (model.HomeWorkText.Trim() == "") { return GetApiResponseModel("Home Work Cannot be Blank", true, null); }
                long homeworkid = new FrontEndApi.HomeWorkApi().Add(model);
                return GetApiResponseModel("Home Work Posted Successfully.", true, homeworkid);
            }
            else
            {
                return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null);
            }
        }

        public dynamic UpdateHomeWork(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.HomeWorkId == 0 || model.HomeWorkId < 0) { return GetApiResponseModel("HomeWork Id Cannot be Zero", true, null); }
                if (model.HomeWorkText.Trim() == null) { return GetApiResponseModel("HomeWork Text Cannot be Null", true, null); }
                if (model.HomeWorkText.Trim() == "") { return GetApiResponseModel("HomeWork Text Cannot be Blank", true, null); }
                new FrontEndApi.HomeWorkApi().Update(model);
                return GetApiResponseModel("Home Work Updated Successfully.", true, null);
            }
            else
            {
                return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null);
            }
        }

        public dynamic SearchHomeWorkByAdvanceSearch(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return GetApiResponseModel("Successfully Performed.", true, new HomeWorkHelper(new FrontEndApi.HomeWorkApi().GetHomeWorkByAdvanceSearch(model)).Map());
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }

        /// <summary>
        /// Return Subject Wise Assigned Teacher to Classes.
        /// </summary>
        /// <param name="model">Model Should have 2 value i.e Class Id & Section Id. </param>
        /// <returns>Return Subject Wise Assigned Teacher to Classes.</returns>
        public dynamic SearchSubjectWiseFacultiesForClass(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.ClassId == 0) { return GetApiResponseModel("Class Id Cannot be Zero.", true, null); }
                if (model.SectionId == 0) { return GetApiResponseModel("Section Id Cannot be Zero.", true, null); }
                return GetApiResponseModel("Successfully Performed.", true, new ClassSubjectFacultyTableHelper(new FrontEndApi.ClassSubjectFacultyTableApi().GetClassSubjectFacultyTableByAdvanceSearch(model)).Map());
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }

        /// <summary>
        /// Search Assigned Classes to Faculties.
        /// </summary>
        /// <param name="model">Accepting Faculty Id To Search Details</param>
        /// <returns>Returng Assigned Classes to Faculties.</returns>
        public dynamic SearchAssignedClassForFaculties(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                if (model.FacultyId == 0) { return GetApiResponseModel("Faculty Id Cannot be Zero.", true, null); }
                return GetApiResponseModel("Successfully Performed.", true, new ClassSubjectFacultyTableHelper(new FrontEndApi.ClassSubjectFacultyTableApi().GetClassSubjectFacultyTableByAdvanceSearch(model)).Map());
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }

        public dynamic SearchActiveEvents(DTO.LABURNUM.COM.EventModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return GetApiResponseModel("Successfully Performed.", true, new EventHelper(new FrontEndApi.EventApi().GetActiveEvents()).Map());
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }

        public dynamic SearchActiveCirculars(DTO.LABURNUM.COM.CircularModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return GetApiResponseModel("Successfully Performed.", true, new CircularHelper(new FrontEndApi.CircularApi().GetActiveCirculars()).Map());
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }

        public dynamic SearchAttendanceReport(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return GetApiResponseModel("Successfully Performed.", true, new API.LABURNUM.COM.Controllers.CommonAttendanceController().SearchAttendanceReport(model));
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }

        public dynamic SearchAllActiveSubjects(DTO.LABURNUM.COM.SubjectModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return GetApiResponseModel("Successfully Performed.", true, new SubjectHelper(new FrontEndApi.SubjectApi().GetActiveSubject()).Map());
            }
            else { return GetApiResponseModel("Api Access User Name or Password Invalid.", false, null); }
        }
    }
}