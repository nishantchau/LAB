using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AttendanceClass12Helper
    {
        private List<API.LABURNUM.COM.AttendanceClass12> AttendanceClass12;

        public AttendanceClass12Helper()
        {
            this.AttendanceClass12 = new List<API.LABURNUM.COM.AttendanceClass12>();
        }

        public AttendanceClass12Helper(List<API.LABURNUM.COM.AttendanceClass12> AttendanceClass12)
        {
            if (AttendanceClass12 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AttendanceClass12 = AttendanceClass12;
        }

        public AttendanceClass12Helper(API.LABURNUM.COM.AttendanceClass12 Class)
        {
            if (Class == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AttendanceClass12 = new List<API.LABURNUM.COM.AttendanceClass12>();
            this.AttendanceClass12.Add(Class);
        }

        public List<DTO.LABURNUM.COM.AttendanceClass12Model> Map()
        {
            if (this.AttendanceClass12 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AttendanceClass12Model> dtoAttendanceClass12 = new List<DTO.LABURNUM.COM.AttendanceClass12Model>();
            foreach (API.LABURNUM.COM.AttendanceClass12 item in this.AttendanceClass12)
            {
                dtoAttendanceClass12.Add(MapCore(item));
            }
            return dtoAttendanceClass12;
        }

        public DTO.LABURNUM.COM.AttendanceClass12Model MapSingle()
        {
            if (this.AttendanceClass12 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AttendanceClass12.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AttendanceClass12[0]);
        }

        private DTO.LABURNUM.COM.AttendanceClass12Model MapCore(API.LABURNUM.COM.AttendanceClass12 apiclass)
        {

            DTO.LABURNUM.COM.AttendanceClass12Model dtoClass = new DTO.LABURNUM.COM.AttendanceClass12Model()
            {
                AttendanceClass12Id = apiclass.AttendanceClass12Id,
                ClassId = apiclass.ClassId,
                SectionId = apiclass.SectionId,
                StudentId = apiclass.StudentId,
                Date = apiclass.Date,
                IsPresent = apiclass.IsPresent,
                CreatedOn = apiclass.CreatedOn,
                IsActive = apiclass.IsActive,
                LastUpdated = apiclass.LastUpdated
            };
            return dtoClass;
        }
    }
}