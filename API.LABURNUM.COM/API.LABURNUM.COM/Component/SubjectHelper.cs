using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class SubjectHelper
    {
        private List<API.LABURNUM.COM.Subject> Subjects;

        public SubjectHelper()
        {
            this.Subjects = new List<API.LABURNUM.COM.Subject>();
        }

        public SubjectHelper(List<API.LABURNUM.COM.Subject> subjects)
        {
            if (subjects == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.Subjects = subjects;
        }

        public SubjectHelper(API.LABURNUM.COM.Subject subject)
        {
            if (subject == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.Subjects = new List<API.LABURNUM.COM.Subject>();
            this.Subjects.Add(subject);
        }

        public List<DTO.LABURNUM.COM.SubjectModel> Map()
        {
            if (this.Subjects == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.SubjectModel> dtoSubjectes = new List<DTO.LABURNUM.COM.SubjectModel>();
            foreach (API.LABURNUM.COM.Subject item in this.Subjects)
            {
                dtoSubjectes.Add(MapCore(item));
            }
            return dtoSubjectes;
        }

        public DTO.LABURNUM.COM.SubjectModel MapSingle()
        {
            if (this.Subjects == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.Subjects.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.Subjects[0]);
        }

        private DTO.LABURNUM.COM.SubjectModel MapCore(API.LABURNUM.COM.Subject apiSubject)
        {
            DTO.LABURNUM.COM.SubjectModel dtoSubject = new DTO.LABURNUM.COM.SubjectModel()
            {
                SubjectId = apiSubject.SubjectId,
                SubjectName = apiSubject.SubjectName,
                CreatedOn = apiSubject.CreatedOn,
                IsActive = apiSubject.IsActive,
                LastUpdated = apiSubject.LastUpdated
            };
            return dtoSubject;
        }
    }
}