using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AttendanceClass4Helper
    {
        private List<API.LABURNUM.COM.AttendanceClass4> AttendanceClass4;

        public AttendanceClass4Helper()
        {
            this.AttendanceClass4 = new List<API.LABURNUM.COM.AttendanceClass4>();
        }

        public AttendanceClass4Helper(List<API.LABURNUM.COM.AttendanceClass4> AttendanceClass4)
        {
            if (AttendanceClass4 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AttendanceClass4 = AttendanceClass4;
        }

        public AttendanceClass4Helper(API.LABURNUM.COM.AttendanceClass4 Class)
        {
            if (Class == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AttendanceClass4 = new List<API.LABURNUM.COM.AttendanceClass4>();
            this.AttendanceClass4.Add(Class);
        }

        public List<DTO.LABURNUM.COM.AttendanceClass4Model> Map()
        {
            if (this.AttendanceClass4 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AttendanceClass4Model> dtoAttendanceClass4 = new List<DTO.LABURNUM.COM.AttendanceClass4Model>();
            foreach (API.LABURNUM.COM.AttendanceClass4 item in this.AttendanceClass4)
            {
                dtoAttendanceClass4.Add(MapCore(item));
            }
            return dtoAttendanceClass4;
        }

        public DTO.LABURNUM.COM.AttendanceClass4Model MapSingle()
        {
            if (this.AttendanceClass4 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AttendanceClass4.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AttendanceClass4[0]);
        }

        private DTO.LABURNUM.COM.AttendanceClass4Model MapCore(API.LABURNUM.COM.AttendanceClass4 apiclass)
        {

            DTO.LABURNUM.COM.AttendanceClass4Model dtoClass = new DTO.LABURNUM.COM.AttendanceClass4Model()
            {
                AttendanceClass4Id = apiclass.AttendanceClass4Id,
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