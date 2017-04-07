using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class SessionManagement
    {
        private DTO.LABURNUM.COM.SessionModel _sessionModel;

        public SessionManagement()
        {
            this._sessionModel = new DTO.LABURNUM.COM.SessionModel();

            bool isSessionTimedOut = true;

            if (HttpContext.Current.Session.Count > 0)
            {
                if (HttpContext.Current.Session[LABURNUM.COM.Component.Constants.SessionName] != null)
                {
                    isSessionTimedOut = false;
                }
            }

            if (isSessionTimedOut)
            {
                new LABURNUM.COM.Component.RedirectHelperController().RedirectTo("Index", "Login");
            }
            else
            {
                this._sessionModel = ((DTO.LABURNUM.COM.SessionModel)HttpContext.Current.Session[LABURNUM.COM.Component.Constants.SessionName]);
            }
        }

        public bool isSessionAlive()
        {
            bool SessionAlive = true;
            if (HttpContext.Current.Session.Count > 0)
            {
                if (HttpContext.Current.Session[LABURNUM.COM.Component.Constants.SessionName] != null)
                {
                    SessionAlive = true;
                    return SessionAlive;
                }
            }
            else { return false; }
            return false;
        }

        public void ClearSession()
        {
            if (HttpContext.Current.Session.Count > 0)
            {
                if (HttpContext.Current.Session[LABURNUM.COM.Component.Constants.SessionName] != null)
                {
                    HttpContext.Current.Session.Remove(LABURNUM.COM.Component.Constants.SessionName);
                }
            }
        }

        public long GetLoginBy() { return this._sessionModel.LoginBy; }
        public string GetStudentAdmissionNumber() { return this._sessionModel.StudentModel.AdmissionNumber; }
        public string GetStudentPhoto() { return this._sessionModel.StudentModel.StudentPhoto; }
        public string GetSudentFullName() { return this._sessionModel.StudentModel.StudentFullName; }
        public string GetSudentFirstName() { return this._sessionModel.StudentModel.FirstName; }
        public string GetSudentMiddleName() { return this._sessionModel.StudentModel.MiddleName; }
        public string GetSudentLastName() { return this._sessionModel.StudentModel.LastName; }
        public string GetSudentMobile() { return this._sessionModel.StudentModel.Mobile; }
        public string GetSudentAadharNo() { return this._sessionModel.StudentModel.StudentAadharNumber; }
        public DateTime GetSudentDOB() { return this._sessionModel.StudentModel.DOB; }
        public long GetSudentId() { return this._sessionModel.StudentModel.StudentId; }
        public long GetClassId() { return this._sessionModel.StudentModel.ClassId; }
        public long GetSectionId() { return this._sessionModel.StudentModel.SectionId; }
        public string GetAddress() { return this._sessionModel.StudentModel.Address; }
        public long GetBusRouteNo() { return this._sessionModel.StudentModel.BusRouteId; }
        public string GetEmailId() { return this._sessionModel.StudentModel.EmailId; }
        public string GetFatherName() { return this._sessionModel.StudentModel.FatherName; }
        public string GetFatherMobile() { return this._sessionModel.StudentModel.FatherMobile; }
        public string GetFatherProfession() { return this._sessionModel.StudentModel.FatherProfession; }
        public string GetFatherAadhar() { return this._sessionModel.StudentModel.FatherAadharNumber; }
        public string GetPAN() { return this._sessionModel.StudentModel.PAN; }
        public string GetLandLine() { return this._sessionModel.StudentModel.Landline; }
        public long GetSalutationId() { return this._sessionModel.StudentModel.SalutationId; }
        public string GetMotherName() { return this._sessionModel.StudentModel.MotherName; }
        public string GetMotherMobile() { return this._sessionModel.StudentModel.MotherMobile; }
        public string GetMotherProfession() { return this._sessionModel.StudentModel.MotherProfession; }
        public string GetMotherAadharNumber() { return this._sessionModel.StudentModel.MotherAadharNumber; }
        public string GetStudentClassName() { return this._sessionModel.StudentModel.ClassName; }
        public string GetStudentSectionName() { return this._sessionModel.StudentModel.SectionName; }
        public string GetClassStartWithName() { return this._sessionModel.StudentModel.ClassStartWithName; }
        public string GetStudentPassword() { return this._sessionModel.StudentModel.StudentPassword; }
        public string GetParentPassword() { return this._sessionModel.StudentModel.ParentPassword; }

        public long GetFacultyId() { return this._sessionModel.FacultyModel.FacultyId; }
        public string GetFacultyName() { return this._sessionModel.FacultyModel.FacultyName; }
        public long GetFacultyClassId() { return this._sessionModel.FacultyModel.ClassId; }
        public string GetFacultyClassName() { return this._sessionModel.FacultyModel.ClassName; }
        public long GetFacultySectionId() { return this._sessionModel.FacultyModel.SectionId; }
        public string GetFacultySectionName() { return this._sessionModel.FacultyModel.SectionName; }
        public string GetUserTypeText() { return this._sessionModel.FacultyModel.UserTypeText; }
        public bool GetIsClassTeacher() { return this._sessionModel.FacultyModel.IsClassTeacher; }
        public string GetFacultyPhoto() { return this._sessionModel.FacultyModel.Photo; }
        public string GetFacultyEmail() { return this._sessionModel.FacultyModel.Email; }
        public string GetFacultyContactNo() { return this._sessionModel.FacultyModel.ContactNumber; }
        public string GetFacultyPassword() { return this._sessionModel.FacultyModel.Password; }
        public bool GetIsSubjectTeacher() { return this._sessionModel.FacultyModel.IsSubjectTeacher; }
        public long GetSubjectId() { return this._sessionModel.FacultyModel.SubjectId; }
        public string GetSubjectName() { return this._sessionModel.FacultyModel.SubjectName; }


        public long GetLoginActivityId() { return this._sessionModel.LoginActivityId; }
    }
}