using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AttendanceClass1Helper
    {
        private List<API.LABURNUM.COM.AttendanceClass1> AttendanceClass1;

        public AttendanceClass1Helper()
        {
            this.AttendanceClass1 = new List<API.LABURNUM.COM.AttendanceClass1>();
        }

        public AttendanceClass1Helper(List<API.LABURNUM.COM.AttendanceClass1> AttendanceClass1)
        {
            if (AttendanceClass1 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AttendanceClass1 = AttendanceClass1;
        }

        public AttendanceClass1Helper(API.LABURNUM.COM.AttendanceClass1 Class)
        {
            if (Class == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AttendanceClass1 = new List<API.LABURNUM.COM.AttendanceClass1>();
            this.AttendanceClass1.Add(Class);
        }

        public List<DTO.LABURNUM.COM.AttendanceClass1Model> Map()
        {
            if (this.AttendanceClass1 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AttendanceClass1Model> dtoAttendanceClass1 = new List<DTO.LABURNUM.COM.AttendanceClass1Model>();
            foreach (API.LABURNUM.COM.AttendanceClass1 item in this.AttendanceClass1)
            {
                dtoAttendanceClass1.Add(MapCore(item));
            }
            return dtoAttendanceClass1;
        }

        public DTO.LABURNUM.COM.AttendanceClass1Model MapSingle()
        {
            if (this.AttendanceClass1 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AttendanceClass1.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AttendanceClass1[0]);
        }

        private DTO.LABURNUM.COM.AttendanceClass1Model MapCore(API.LABURNUM.COM.AttendanceClass1 apiclass)
        {

            DTO.LABURNUM.COM.AttendanceClass1Model dtoClass = new DTO.LABURNUM.COM.AttendanceClass1Model()
            {
                AttendanceClass1Id = apiclass.AttendanceClass1Id,
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