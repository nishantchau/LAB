using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AttendanceClass8Helper
    {
        private List<API.LABURNUM.COM.AttendanceClass8> AttendanceClass8;

        public AttendanceClass8Helper()
        {
            this.AttendanceClass8 = new List<API.LABURNUM.COM.AttendanceClass8>();
        }

        public AttendanceClass8Helper(List<API.LABURNUM.COM.AttendanceClass8> AttendanceClass8)
        {
            if (AttendanceClass8 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AttendanceClass8 = AttendanceClass8;
        }

        public AttendanceClass8Helper(API.LABURNUM.COM.AttendanceClass8 Class)
        {
            if (Class == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AttendanceClass8 = new List<API.LABURNUM.COM.AttendanceClass8>();
            this.AttendanceClass8.Add(Class);
        }

        public List<DTO.LABURNUM.COM.AttendanceClass8Model> Map()
        {
            if (this.AttendanceClass8 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AttendanceClass8Model> dtoAttendanceClass8 = new List<DTO.LABURNUM.COM.AttendanceClass8Model>();
            foreach (API.LABURNUM.COM.AttendanceClass8 item in this.AttendanceClass8)
            {
                dtoAttendanceClass8.Add(MapCore(item));
            }
            return dtoAttendanceClass8;
        }

        public DTO.LABURNUM.COM.AttendanceClass8Model MapSingle()
        {
            if (this.AttendanceClass8 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AttendanceClass8.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AttendanceClass8[0]);
        }

        private DTO.LABURNUM.COM.AttendanceClass8Model MapCore(API.LABURNUM.COM.AttendanceClass8 apiclass)
        {

            DTO.LABURNUM.COM.AttendanceClass8Model dtoClass = new DTO.LABURNUM.COM.AttendanceClass8Model()
            {
                AttendanceClass8Id = apiclass.AttendanceClass8Id,
                ClassId = apiclass.ClassId,
                SectionId = apiclass.SectionId,
                StudentId = apiclass.StudentId,
                MorningAttendanceDate = apiclass.MorningAttendanceDate,
                LunchAttendanceDate = apiclass.LunchAttendanceDate.GetValueOrDefault().Year != 0001 ? apiclass.LunchAttendanceDate : null,
                IsPresentAfterLuch = apiclass.IsPresentAfterLuch,
                IsPresentInMorning = apiclass.IsPresentInMorning,
                CreatedOn = apiclass.CreatedOn,
                IsActive = apiclass.IsActive,
                LastUpdated = apiclass.LastUpdated,
                StudentName = apiclass.Student.FirstName + " " + apiclass.Student.MiddleName + " " + apiclass.Student.LastName,
                FatherName = apiclass.Student.FatherName,
                AttendanceId = apiclass.AttendanceClass8Id,
            };
            return dtoClass;
        }
    }
}