using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AttendanceClass11Helper
    {
        private List<API.LABURNUM.COM.AttendanceClass11> AttendanceClass11;

        public AttendanceClass11Helper()
        {
            this.AttendanceClass11 = new List<API.LABURNUM.COM.AttendanceClass11>();
        }

        public AttendanceClass11Helper(List<API.LABURNUM.COM.AttendanceClass11> AttendanceClass11)
        {
            if (AttendanceClass11 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AttendanceClass11 = AttendanceClass11;
        }

        public AttendanceClass11Helper(API.LABURNUM.COM.AttendanceClass11 Class)
        {
            if (Class == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AttendanceClass11 = new List<API.LABURNUM.COM.AttendanceClass11>();
            this.AttendanceClass11.Add(Class);
        }

        public List<DTO.LABURNUM.COM.AttendanceClass11Model> Map()
        {
            if (this.AttendanceClass11 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AttendanceClass11Model> dtoAttendanceClass11 = new List<DTO.LABURNUM.COM.AttendanceClass11Model>();
            foreach (API.LABURNUM.COM.AttendanceClass11 item in this.AttendanceClass11)
            {
                dtoAttendanceClass11.Add(MapCore(item));
            }
            return dtoAttendanceClass11;
        }

        public DTO.LABURNUM.COM.AttendanceClass11Model MapSingle()
        {
            if (this.AttendanceClass11 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AttendanceClass11.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AttendanceClass11[0]);
        }

        private DTO.LABURNUM.COM.AttendanceClass11Model MapCore(API.LABURNUM.COM.AttendanceClass11 apiclass)
        {

            DTO.LABURNUM.COM.AttendanceClass11Model dtoClass = new DTO.LABURNUM.COM.AttendanceClass11Model()
            {
                AttendanceClass11Id = apiclass.AttendanceClass11Id,
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