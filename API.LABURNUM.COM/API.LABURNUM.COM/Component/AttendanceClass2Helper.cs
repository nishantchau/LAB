using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AttendanceClass2Helper
    {
        private List<API.LABURNUM.COM.AttendanceClass2> AttendanceClass2;

        public AttendanceClass2Helper()
        {
            this.AttendanceClass2 = new List<API.LABURNUM.COM.AttendanceClass2>();
        }

        public AttendanceClass2Helper(List<API.LABURNUM.COM.AttendanceClass2> AttendanceClass2)
        {
            if (AttendanceClass2 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AttendanceClass2 = AttendanceClass2;
        }

        public AttendanceClass2Helper(API.LABURNUM.COM.AttendanceClass2 Class)
        {
            if (Class == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AttendanceClass2 = new List<API.LABURNUM.COM.AttendanceClass2>();
            this.AttendanceClass2.Add(Class);
        }

        public List<DTO.LABURNUM.COM.AttendanceClass2Model> Map()
        {
            if (this.AttendanceClass2 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AttendanceClass2Model> dtoAttendanceClass2 = new List<DTO.LABURNUM.COM.AttendanceClass2Model>();
            foreach (API.LABURNUM.COM.AttendanceClass2 item in this.AttendanceClass2)
            {
                dtoAttendanceClass2.Add(MapCore(item));
            }
            return dtoAttendanceClass2;
        }

        public DTO.LABURNUM.COM.AttendanceClass2Model MapSingle()
        {
            if (this.AttendanceClass2 == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AttendanceClass2.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AttendanceClass2[0]);
        }

        private DTO.LABURNUM.COM.AttendanceClass2Model MapCore(API.LABURNUM.COM.AttendanceClass2 apiclass)
        {

            DTO.LABURNUM.COM.AttendanceClass2Model dtoClass = new DTO.LABURNUM.COM.AttendanceClass2Model()
            {
                AttendanceClass2Id = apiclass.AttendanceClass2Id,
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