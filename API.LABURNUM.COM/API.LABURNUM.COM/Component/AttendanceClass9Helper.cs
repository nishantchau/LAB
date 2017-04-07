using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AttendanceClass9Helper
    {
        private List<API.LABURNUM.COM.AttendanceClass9> AttendanceClass9;

        public AttendanceClass9Helper()
        {
            this.AttendanceClass9 = new List<API.LABURNUM.COM.AttendanceClass9>();
        }

        public AttendanceClass9Helper(List<API.LABURNUM.COM.AttendanceClass9> attendanceClass9)
        {
            if (attendanceClass9 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AttendanceClass9 = attendanceClass9;
        }

        public AttendanceClass9Helper(API.LABURNUM.COM.AttendanceClass9 Class)
        {
            if (Class == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AttendanceClass9 = new List<API.LABURNUM.COM.AttendanceClass9>();
            this.AttendanceClass9.Add(Class);
        }

        public List<DTO.LABURNUM.COM.AttendanceClass9Model> Map()
        {
            if (this.AttendanceClass9 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AttendanceClass9Model> dtoAttendanceClass9 = new List<DTO.LABURNUM.COM.AttendanceClass9Model>();
            foreach (API.LABURNUM.COM.AttendanceClass9 item in this.AttendanceClass9)
            {
                dtoAttendanceClass9.Add(MapCore(item));
            }
            return dtoAttendanceClass9;
        }

        public DTO.LABURNUM.COM.AttendanceClass9Model MapSingle()
        {
            if (this.AttendanceClass9 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AttendanceClass9.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AttendanceClass9[0]);
        }

        private DTO.LABURNUM.COM.AttendanceClass9Model MapCore(API.LABURNUM.COM.AttendanceClass9 apiclass)
        {

            DTO.LABURNUM.COM.AttendanceClass9Model dtoClass = new DTO.LABURNUM.COM.AttendanceClass9Model()
            {
                AttendanceClass9Id = apiclass.AttendanceClass9Id,
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