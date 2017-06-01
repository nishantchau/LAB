using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AttendanceClassLKGHelper
    {
        private List<API.LABURNUM.COM.AttendanceClassLKG> AttendanceClassLKG;

        public AttendanceClassLKGHelper()
        {
            this.AttendanceClassLKG = new List<API.LABURNUM.COM.AttendanceClassLKG>();
        }

        public AttendanceClassLKGHelper(List<API.LABURNUM.COM.AttendanceClassLKG> AttendanceClassLKG)
        {
            if (AttendanceClassLKG == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AttendanceClassLKG = AttendanceClassLKG;
        }

        public AttendanceClassLKGHelper(API.LABURNUM.COM.AttendanceClassLKG Class)
        {
            if (Class == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AttendanceClassLKG = new List<API.LABURNUM.COM.AttendanceClassLKG>();
            this.AttendanceClassLKG.Add(Class);
        }

        public List<DTO.LABURNUM.COM.AttendanceClassLKGModel> Map()
        {
            if (this.AttendanceClassLKG == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AttendanceClassLKGModel> dtoAttendanceClassLKG = new List<DTO.LABURNUM.COM.AttendanceClassLKGModel>();
            foreach (API.LABURNUM.COM.AttendanceClassLKG item in this.AttendanceClassLKG)
            {
                dtoAttendanceClassLKG.Add(MapCore(item));
            }
            return dtoAttendanceClassLKG;
        }

        public DTO.LABURNUM.COM.AttendanceClassLKGModel MapSingle()
        {
            if (this.AttendanceClassLKG == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AttendanceClassLKG.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AttendanceClassLKG[0]);
        }

        private DTO.LABURNUM.COM.AttendanceClassLKGModel MapCore(API.LABURNUM.COM.AttendanceClassLKG apiclass)
        {

            DTO.LABURNUM.COM.AttendanceClassLKGModel dtoClass = new DTO.LABURNUM.COM.AttendanceClassLKGModel()
            {
                AttendanceClassLKGId = apiclass.AttendanceClassLKGId,
                ClassId = apiclass.ClassId,
                SectionId = apiclass.SectionId,
                StudentId = apiclass.StudentId,
                MorningAttendanceDate = apiclass.MorningAttendanceDate,
                LunchAttendanceDate = apiclass.LunchAttendanceDate.GetValueOrDefault().Year != 0001 ? apiclass.LunchAttendanceDate : null,
                IsPresentAfterLuch = apiclass.IsPresentAfterLuch,
                IsPresentInMorning = apiclass.IsPresentInMorning,
                CreatedOn = apiclass.CreatedOn,
                IsActive = apiclass.IsActive,
                LastUpdated = apiclass.LastUpdated,
                StudentName = apiclass.Student.FirstName + " " + apiclass.Student.MiddleName + " " + apiclass.Student.LastName,
                FatherName = apiclass.Student.FatherName,
                AttendanceId = apiclass.AttendanceClassLKGId,
            };
            return dtoClass;
        }
    }
}