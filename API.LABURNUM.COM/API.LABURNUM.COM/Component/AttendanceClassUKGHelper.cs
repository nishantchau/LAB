using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AttendanceClassUKGHelper
    {
        private List<API.LABURNUM.COM.AttendanceClassUKG> AttendanceClassUKG;

        public AttendanceClassUKGHelper()
        {
            this.AttendanceClassUKG = new List<API.LABURNUM.COM.AttendanceClassUKG>();
        }

        public AttendanceClassUKGHelper(List<API.LABURNUM.COM.AttendanceClassUKG> AttendanceClassUKG)
        {
            if (AttendanceClassUKG == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AttendanceClassUKG = AttendanceClassUKG;
        }

        public AttendanceClassUKGHelper(API.LABURNUM.COM.AttendanceClassUKG Class)
        {
            if (Class == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AttendanceClassUKG = new List<API.LABURNUM.COM.AttendanceClassUKG>();
            this.AttendanceClassUKG.Add(Class);
        }

        public List<DTO.LABURNUM.COM.AttendanceClassUKGModel> Map()
        {
            if (this.AttendanceClassUKG == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AttendanceClassUKGModel> dtoAttendanceClassUKG = new List<DTO.LABURNUM.COM.AttendanceClassUKGModel>();
            foreach (API.LABURNUM.COM.AttendanceClassUKG item in this.AttendanceClassUKG)
            {
                dtoAttendanceClassUKG.Add(MapCore(item));
            }
            return dtoAttendanceClassUKG;
        }

        public DTO.LABURNUM.COM.AttendanceClassUKGModel MapSingle()
        {
            if (this.AttendanceClassUKG == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AttendanceClassUKG.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AttendanceClassUKG[0]);
        }

        private DTO.LABURNUM.COM.AttendanceClassUKGModel MapCore(API.LABURNUM.COM.AttendanceClassUKG apiclass)
        {

            DTO.LABURNUM.COM.AttendanceClassUKGModel dtoClass = new DTO.LABURNUM.COM.AttendanceClassUKGModel()
            {
                AttendanceClassUKGId = apiclass.AttendanceClassUKGId,
                ClassId = apiclass.ClassId,
                SectionId = apiclass.SectionId,
                StudentId = apiclass.StudentId,
                Date = apiclass.Date,
                IsPresent = apiclass.IsPresent,
                CreatedOn = apiclass.CreatedOn,
                IsActive = apiclass.IsActive,
                LastUpdated = apiclass.LastUpdated,
                StudentName = apiclass.Student.FirstName + " " + apiclass.Student.MiddleName + " " + apiclass.Student.LastName,
                FatherName = apiclass.Student.FatherName
            };
            return dtoClass;
        }
    }
}