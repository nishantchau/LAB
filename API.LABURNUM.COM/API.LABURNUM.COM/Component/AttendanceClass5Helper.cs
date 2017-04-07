using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AttendanceClass5Helper
    {
        private List<API.LABURNUM.COM.AttendanceClass5> AttendanceClass5;

        public AttendanceClass5Helper()
        {
            this.AttendanceClass5 = new List<API.LABURNUM.COM.AttendanceClass5>();
        }

        public AttendanceClass5Helper(List<API.LABURNUM.COM.AttendanceClass5> AttendanceClass5)
        {
            if (AttendanceClass5 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AttendanceClass5 = AttendanceClass5;
        }

        public AttendanceClass5Helper(API.LABURNUM.COM.AttendanceClass5 Class)
        {
            if (Class == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AttendanceClass5 = new List<API.LABURNUM.COM.AttendanceClass5>();
            this.AttendanceClass5.Add(Class);
        }

        public List<DTO.LABURNUM.COM.AttendanceClass5Model> Map()
        {
            if (this.AttendanceClass5 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AttendanceClass5Model> dtoAttendanceClass5 = new List<DTO.LABURNUM.COM.AttendanceClass5Model>();
            foreach (API.LABURNUM.COM.AttendanceClass5 item in this.AttendanceClass5)
            {
                dtoAttendanceClass5.Add(MapCore(item));
            }
            return dtoAttendanceClass5;
        }

        public DTO.LABURNUM.COM.AttendanceClass5Model MapSingle()
        {
            if (this.AttendanceClass5 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AttendanceClass5.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AttendanceClass5[0]);
        }

        private DTO.LABURNUM.COM.AttendanceClass5Model MapCore(API.LABURNUM.COM.AttendanceClass5 apiclass)
        {

            DTO.LABURNUM.COM.AttendanceClass5Model dtoClass = new DTO.LABURNUM.COM.AttendanceClass5Model()
            {
                AttendanceClass5Id = apiclass.AttendanceClass5Id,
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