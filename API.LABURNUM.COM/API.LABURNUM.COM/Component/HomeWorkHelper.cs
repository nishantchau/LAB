using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class HomeWorkHelper
    {
        private List<API.LABURNUM.COM.HomeWork> HomeWork;

        public HomeWorkHelper()
        {
            this.HomeWork = new List<API.LABURNUM.COM.HomeWork>();
        }

        public HomeWorkHelper(List<API.LABURNUM.COM.HomeWork> homeworks)
        {
            if (homeworks == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.HomeWork = homeworks;
        }

        public HomeWorkHelper(API.LABURNUM.COM.HomeWork homework)
        {
            if (homework == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.HomeWork = new List<API.LABURNUM.COM.HomeWork>();
            this.HomeWork.Add(homework);
        }

        public List<DTO.LABURNUM.COM.HomeWorkModel> Map()
        {
            if (this.HomeWork == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.HomeWorkModel> dtoClasses = new List<DTO.LABURNUM.COM.HomeWorkModel>();
            foreach (API.LABURNUM.COM.HomeWork item in this.HomeWork)
            {
                dtoClasses.Add(MapCore(item));
            }
            return dtoClasses;
        }

        public DTO.LABURNUM.COM.HomeWorkModel MapSingle()
        {
            if (this.HomeWork == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.HomeWork.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.HomeWork[0]);
        }

        private DTO.LABURNUM.COM.HomeWorkModel MapCore(API.LABURNUM.COM.HomeWork model)
        {

            DTO.LABURNUM.COM.HomeWorkModel dtoClass = new DTO.LABURNUM.COM.HomeWorkModel()
            {
                HomeWorkId = model.HomeWorkId,
                FacultyId = model.FacultyId,
                SubjectId = model.SubjectId,
                ClassId = model.ClassId,
                SectionId = model.SectionId,
                HomeWorkText = model.HomeWorkText,
                FacultyName = model.Faculty.FacultyName,
                SubjectName = model.Subject.SubjectName,
                ClassName = model.Class.ClassName,
                SectionName = model.Section.SectionName,
                Attachment = model.Attachment,
                CreatedOn = model.CreatedOn,
                IsActive = model.IsActive,
                LastUpdated = model.LastUpdated
            };
            return dtoClass;
        }
    }
}