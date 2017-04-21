using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AttendanceClass7Helper
    {
        private List<API.LABURNUM.COM.AttendanceClass7> AttendanceClass7;

        public AttendanceClass7Helper()
        {
            this.AttendanceClass7 = new List<API.LABURNUM.COM.AttendanceClass7>();
        }

        public AttendanceClass7Helper(List<API.LABURNUM.COM.AttendanceClass7> AttendanceClass7)
        {
            if (AttendanceClass7 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AttendanceClass7 = AttendanceClass7;
        }

        public AttendanceClass7Helper(API.LABURNUM.COM.AttendanceClass7 Class)
        {
            if (Class == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AttendanceClass7 = new List<API.LABURNUM.COM.AttendanceClass7>();
            this.AttendanceClass7.Add(Class);
        }

        public List<DTO.LABURNUM.COM.AttendanceClass7Model> Map()
        {
            if (this.AttendanceClass7 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AttendanceClass7Model> dtoAttendanceClass7 = new List<DTO.LABURNUM.COM.AttendanceClass7Model>();
            foreach (API.LABURNUM.COM.AttendanceClass7 item in this.AttendanceClass7)
            {
                dtoAttendanceClass7.Add(MapCore(item));
            }
            return dtoAttendanceClass7;
        }

        public DTO.LABURNUM.COM.AttendanceClass7Model MapSingle()
        {
            if (this.AttendanceClass7 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AttendanceClass7.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AttendanceClass7[0]);
        }

        private DTO.LABURNUM.COM.AttendanceClass7Model MapCore(API.LABURNUM.COM.AttendanceClass7 apiclass)
        {

            DTO.LABURNUM.COM.AttendanceClass7Model dtoClass = new DTO.LABURNUM.COM.AttendanceClass7Model()
            {
                AttendanceClass7Id = apiclass.AttendanceClass7Id,
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