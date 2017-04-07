using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class FacultyHelper
    {
        private List<API.LABURNUM.COM.Faculty> Faculties;

        public FacultyHelper()
        {
            this.Faculties = new List<API.LABURNUM.COM.Faculty>();
        }

        public FacultyHelper(List<API.LABURNUM.COM.Faculty> faculties)
        {
            if (faculties == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.Faculties = faculties;
        }

        public FacultyHelper(API.LABURNUM.COM.Faculty faculty)
        {
            if (faculty == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.Faculties = new List<API.LABURNUM.COM.Faculty>();
            this.Faculties.Add(faculty);
        }

        public List<DTO.LABURNUM.COM.FacultyModel> Map()
        {
            if (this.Faculties == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.FacultyModel> dtoFaculties = new List<DTO.LABURNUM.COM.FacultyModel>();
            foreach (API.LABURNUM.COM.Faculty item in this.Faculties)
            {
                dtoFaculties.Add(MapCore(item));
            }
            return dtoFaculties;
        }

        public DTO.LABURNUM.COM.FacultyModel MapSingle()
        {
            if (this.Faculties == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.Faculties.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.Faculties[0]);
        }

        private DTO.LABURNUM.COM.FacultyModel MapCore(API.LABURNUM.COM.Faculty apifaculty)
        {

            DTO.LABURNUM.COM.FacultyModel dtoFaculty = new DTO.LABURNUM.COM.FacultyModel()
            {
                FacultyId = apifaculty.FacultyId,
                FacultyName = apifaculty.FacultyName,
                UserName = apifaculty.UserName,
                Password = apifaculty.Password,
                ClassId = apifaculty.ClassId,
                SectionId = apifaculty.SectionId,
                UserTypeId = apifaculty.UserTypeId,
                IsClassTeacher = apifaculty.IsClassTeacher,
                UserTypeText = apifaculty.UserType.Text,
                ClassName = apifaculty.Class.ClassName,
                SectionName = apifaculty.Section.SectionName,
                IsSubjectTeacher = apifaculty.IsSubjectTeacher,
                SubjectId = apifaculty.SubjectId,
                SubjectName = apifaculty.Subject.SubjectName,
                CreatedOn = apifaculty.CreatedOn,
                Email = apifaculty.Email,
                ContactNumber = apifaculty.ContactNumber,
                Photo = apifaculty.Photo,
                IsActive = apifaculty.IsActive,
                LastUpdated = apifaculty.LastUpdated
            };
            return dtoFaculty;
        }
    }
}