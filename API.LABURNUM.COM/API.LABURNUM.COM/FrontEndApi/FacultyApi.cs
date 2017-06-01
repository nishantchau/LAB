using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class FacultyApi
    {
        private LaburnumEntities _laburnum;

        public FacultyApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        /// <summary>
        /// Encrypts A String Password To MD5.
        /// </summary>
        /// <param name="password">Password To Be Encrypted.</param>
        /// <returns>Returns MD5 Password.</returns>
        private string GetEncryptedPassword(string password)
        {
            return new API.LABURNUM.COM.Component.PasswordConvertor().Password(password);
        }

        private long AddFaculty(DTO.LABURNUM.COM.FacultyModel model)
        {
            if (model.ClassId.GetValueOrDefault() == 0) { model.ClassId = null; }
            if (model.SectionId.GetValueOrDefault() == 0) { model.SectionId = null; }
            if (model.SubjectId.GetValueOrDefault() == 0) { model.SubjectId = null; }

            API.LABURNUM.COM.Faculty apifaculty = new Faculty()
            {
                FacultyName = model.FacultyName,
                UserName = model.UserName,
                Password = model.Password,
                ClassId = model.ClassId,
                SectionId = model.SectionId,
                IsClassTeacher = model.IsClassTeacher,
                UserTypeId = model.UserTypeId,
                IsSubjectTeacher = model.IsSubjectTeacher,
                SubjectId = model.SubjectId,
                CreatedOn = System.DateTime.Now,
                IsActive = true,
                Photo = model.Photo,
                Email = model.Email,
                ContactNumber = model.ContactNumber
            };
            this._laburnum.Faculties.Add(apifaculty);
            this._laburnum.SaveChanges();
            return apifaculty.FacultyId;
        }

        private long AddValidation(DTO.LABURNUM.COM.FacultyModel model)
        {
            model.FacultyName.TryValidate();
            model.UserName.TryValidate();
            model.Password.TryValidate();
            return AddFaculty(model);
        }

        public long Add(DTO.LABURNUM.COM.FacultyModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.FacultyModel model)
        {
            model.FacultyId.TryValidate();
            IQueryable<API.LABURNUM.COM.Faculty> iQuery = this._laburnum.Faculties.Where(x => x.FacultyId == model.FacultyId && x.IsActive == true);
            List<API.LABURNUM.COM.Faculty> dbFacutlies = iQuery.ToList();
            if (dbFacutlies.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbFacutlies.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            if (model.ClassId.GetValueOrDefault() == 0) { model.ClassId = null; }
            if (model.SectionId.GetValueOrDefault() == 0) { model.SectionId = null; }
            if (model.SubjectId.GetValueOrDefault() == 0) { model.SubjectId = null; }

            dbFacutlies[0].FacultyName = model.FacultyName;
            dbFacutlies[0].UserName = model.UserName;
            dbFacutlies[0].Password = model.Password;
            dbFacutlies[0].ClassId = model.ClassId;
            dbFacutlies[0].SectionId = model.SectionId;
            dbFacutlies[0].UserTypeId = model.UserTypeId;
            dbFacutlies[0].IsClassTeacher = model.IsClassTeacher;
            dbFacutlies[0].IsSubjectTeacher = model.IsSubjectTeacher;
            dbFacutlies[0].SubjectId = model.SubjectId;
            dbFacutlies[0].Photo = model.Photo;
            dbFacutlies[0].Email = model.Email;
            dbFacutlies[0].ContactNumber = model.ContactNumber;
            dbFacutlies[0].LastUpdated = System.DateTime.Now;

            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.FacultyModel model)
        {
            model.FacultyId.TryValidate();
            IQueryable<API.LABURNUM.COM.Faculty> iQuery = this._laburnum.Faculties.Where(x => x.FacultyId == model.FacultyId && x.IsActive == true);
            List<API.LABURNUM.COM.Faculty> dbFacutlies = iQuery.ToList();
            if (dbFacutlies.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbFacutlies.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbFacutlies[0].IsActive = model.IsActive;
            dbFacutlies[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.Faculty> GetActiveFaculty()
        {
            return this._laburnum.Faculties.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.Faculty> GetInActiveFaculty()
        {
            return this._laburnum.Faculties.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.Faculty> GetAllFaculties()
        {
            return this._laburnum.Faculties.ToList();
        }

        public List<API.LABURNUM.COM.Faculty> GetFacultyByAdvanceSearch(DTO.LABURNUM.COM.FacultyModel model)
        {
            IQueryable<API.LABURNUM.COM.Faculty> iQuery = null;

            //Search By Faculty Id.
            if (model.FacultyId > 0)
            {
                iQuery = this._laburnum.Faculties.Where(x => x.FacultyId == model.FacultyId && x.IsActive == true);
            }

            //Seach By Faculty Name
            if (iQuery != null)
            {
                if (model.FacultyName != null)
                {
                    iQuery = iQuery.Where(x => x.FacultyName.Trim().ToLower().Equals(model.FacultyName.Trim().ToLower()) && x.IsActive == true);
                }
            }
            else
            {
                if (model.FacultyName != null)
                {
                    iQuery = this._laburnum.Faculties.Where(x => x.FacultyName.Trim().ToLower().Equals(model.FacultyName.Trim().ToLower()) && x.IsActive == true);
                }
            }

            //Seach By SubjectId.
            if (iQuery != null)
            {
                if (model.SubjectId > 0)
                {
                    iQuery = iQuery.Where(x => x.SubjectId == model.SubjectId && x.IsActive == true);
                }
            }
            else
            {
                if (model.SubjectId > 0)
                {
                    iQuery = this._laburnum.Faculties.Where(x => x.SubjectId == model.SubjectId && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.Faculty> dbFaculties = iQuery.ToList();
            return dbFaculties;
        }

        public API.LABURNUM.COM.Faculty FacultyLogin(string userName, string Password)
        {
            userName.TryValidate();
            Password.TryValidate();
            IQueryable<API.LABURNUM.COM.Faculty> iQuery = this._laburnum.Faculties.Where(x => (x.UserName.Trim().Equals(userName.Trim()) && x.Password.Trim().Equals(Password.Trim())) && x.IsActive == true);
            List<API.LABURNUM.COM.Faculty> dbFaculties = iQuery.ToList();
            if (dbFaculties.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbFaculties.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            return dbFaculties[0];
        }

        public API.LABURNUM.COM.Faculty GetFacultyById(long facultyId)
        {
            DTO.LABURNUM.COM.FacultyModel model = new DTO.LABURNUM.COM.FacultyModel() { FacultyId = facultyId };
            List<API.LABURNUM.COM.Faculty> dbFaculties = GetFacultyByAdvanceSearch(model);
            if (dbFaculties.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbFaculties.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            return dbFaculties[0];
        }

        public void UpdateProfile(DTO.LABURNUM.COM.FacultyModel model)
        {
            model.FacultyId.TryValidate();
            IQueryable<API.LABURNUM.COM.Faculty> iQuery = this._laburnum.Faculties.Where(x => x.FacultyId == model.FacultyId && x.IsActive == true);
            List<API.LABURNUM.COM.Faculty> dbFacutlies = iQuery.ToList();
            if (dbFacutlies.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbFacutlies.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbFacutlies[0].Password = model.NewPassword;
            dbFacutlies[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }
    }
}