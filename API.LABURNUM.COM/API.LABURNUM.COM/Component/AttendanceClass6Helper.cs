using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AttendanceClass6Helper
    {
        private List<API.LABURNUM.COM.AttendanceClass6> AttendanceClass6;

        public AttendanceClass6Helper()
        {
            this.AttendanceClass6 = new List<API.LABURNUM.COM.AttendanceClass6>();
        }

        public AttendanceClass6Helper(List<API.LABURNUM.COM.AttendanceClass6> AttendanceClass6)
        {
            if (AttendanceClass6 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AttendanceClass6 = AttendanceClass6;
        }

        public AttendanceClass6Helper(API.LABURNUM.COM.AttendanceClass6 Class)
        {
            if (Class == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AttendanceClass6 = new List<API.LABURNUM.COM.AttendanceClass6>();
            this.AttendanceClass6.Add(Class);
        }

        public List<DTO.LABURNUM.COM.AttendanceClass6Model> Map()
        {
            if (this.AttendanceClass6 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AttendanceClass6Model> dtoAttendanceClass6 = new List<DTO.LABURNUM.COM.AttendanceClass6Model>();
            foreach (API.LABURNUM.COM.AttendanceClass6 item in this.AttendanceClass6)
            {
                dtoAttendanceClass6.Add(MapCore(item));
            }
            return dtoAttendanceClass6;
        }

        public DTO.LABURNUM.COM.AttendanceClass6Model MapSingle()
        {
            if (this.AttendanceClass6 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AttendanceClass6.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AttendanceClass6[0]);
        }

        private DTO.LABURNUM.COM.AttendanceClass6Model MapCore(API.LABURNUM.COM.AttendanceClass6 apiclass)
        {

            DTO.LABURNUM.COM.AttendanceClass6Model dtoClass = new DTO.LABURNUM.COM.AttendanceClass6Model()
            {
                AttendanceClass6Id = apiclass.AttendanceClass6Id,
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