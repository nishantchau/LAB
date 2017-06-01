using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AttendanceClass3Helper
    {
        private List<API.LABURNUM.COM.AttendanceClass3> AttendanceClass3;

        public AttendanceClass3Helper()
        {
            this.AttendanceClass3 = new List<API.LABURNUM.COM.AttendanceClass3>();
        }

        public AttendanceClass3Helper(List<API.LABURNUM.COM.AttendanceClass3> AttendanceClass3)
        {
            if (AttendanceClass3 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AttendanceClass3 = AttendanceClass3;
        }

        public AttendanceClass3Helper(API.LABURNUM.COM.AttendanceClass3 Class)
        {
            if (Class == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AttendanceClass3 = new List<API.LABURNUM.COM.AttendanceClass3>();
            this.AttendanceClass3.Add(Class);
        }

        public List<DTO.LABURNUM.COM.AttendanceClass3Model> Map()
        {
            if (this.AttendanceClass3 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AttendanceClass3Model> dtoAttendanceClass3 = new List<DTO.LABURNUM.COM.AttendanceClass3Model>();
            foreach (API.LABURNUM.COM.AttendanceClass3 item in this.AttendanceClass3)
            {
                dtoAttendanceClass3.Add(MapCore(item));
            }
            return dtoAttendanceClass3;
        }

        public DTO.LABURNUM.COM.AttendanceClass3Model MapSingle()
        {
            if (this.AttendanceClass3 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AttendanceClass3.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AttendanceClass3[0]);
        }

        private DTO.LABURNUM.COM.AttendanceClass3Model MapCore(API.LABURNUM.COM.AttendanceClass3 apiclass)
        {

            DTO.LABURNUM.COM.AttendanceClass3Model dtoClass = new DTO.LABURNUM.COM.AttendanceClass3Model()
            {
                AttendanceClass3Id = apiclass.AttendanceClass3Id,
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
                AttendanceId = apiclass.AttendanceClass3Id,
            };
            return dtoClass;
        }
    }
}