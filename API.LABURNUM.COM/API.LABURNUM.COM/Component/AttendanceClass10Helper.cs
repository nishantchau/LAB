using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AttendanceClass10Helper
    {
        private List<API.LABURNUM.COM.AttendanceClass10> AttendanceClass10;

        public AttendanceClass10Helper()
        {
            this.AttendanceClass10 = new List<API.LABURNUM.COM.AttendanceClass10>();
        }

        public AttendanceClass10Helper(List<API.LABURNUM.COM.AttendanceClass10> AttendanceClass10)
        {
            if (AttendanceClass10 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AttendanceClass10 = AttendanceClass10;
        }

        public AttendanceClass10Helper(API.LABURNUM.COM.AttendanceClass10 Class)
        {
            if (Class == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AttendanceClass10 = new List<API.LABURNUM.COM.AttendanceClass10>();
            this.AttendanceClass10.Add(Class);
        }

        public List<DTO.LABURNUM.COM.AttendanceClass10Model> Map()
        {
            if (this.AttendanceClass10 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AttendanceClass10Model> dtoAttendanceClass10 = new List<DTO.LABURNUM.COM.AttendanceClass10Model>();
            foreach (API.LABURNUM.COM.AttendanceClass10 item in this.AttendanceClass10)
            {
                dtoAttendanceClass10.Add(MapCore(item));
            }
            return dtoAttendanceClass10;
        }

        public DTO.LABURNUM.COM.AttendanceClass10Model MapSingle()
        {
            if (this.AttendanceClass10 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AttendanceClass10.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AttendanceClass10[0]);
        }

        private DTO.LABURNUM.COM.AttendanceClass10Model MapCore(API.LABURNUM.COM.AttendanceClass10 apiclass)
        {

            DTO.LABURNUM.COM.AttendanceClass10Model dtoClass = new DTO.LABURNUM.COM.AttendanceClass10Model()
            {
                AttendanceClass10Id = apiclass.AttendanceClass10Id,
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