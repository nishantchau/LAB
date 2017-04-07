using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AttendanceClassPreNurseryHelper
    {
        private List<API.LABURNUM.COM.AttendanceClassPreNursery> AttendanceClassPreNursery;

        public AttendanceClassPreNurseryHelper()
        {
            this.AttendanceClassPreNursery = new List<API.LABURNUM.COM.AttendanceClassPreNursery>();
        }

        public AttendanceClassPreNurseryHelper(List<API.LABURNUM.COM.AttendanceClassPreNursery> AttendanceClassPreNursery)
        {
            if (AttendanceClassPreNursery == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AttendanceClassPreNursery = AttendanceClassPreNursery;
        }

        public AttendanceClassPreNurseryHelper(API.LABURNUM.COM.AttendanceClassPreNursery Class)
        {
            if (Class == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AttendanceClassPreNursery = new List<API.LABURNUM.COM.AttendanceClassPreNursery>();
            this.AttendanceClassPreNursery.Add(Class);
        }

        public List<DTO.LABURNUM.COM.AttendanceClassPreNurseryModel> Map()
        {
            if (this.AttendanceClassPreNursery == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AttendanceClassPreNurseryModel> dtoAttendanceClassPreNursery = new List<DTO.LABURNUM.COM.AttendanceClassPreNurseryModel>();
            foreach (API.LABURNUM.COM.AttendanceClassPreNursery item in this.AttendanceClassPreNursery)
            {
                dtoAttendanceClassPreNursery.Add(MapCore(item));
            }
            return dtoAttendanceClassPreNursery;
        }

        public DTO.LABURNUM.COM.AttendanceClassPreNurseryModel MapSingle()
        {
            if (this.AttendanceClassPreNursery == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AttendanceClassPreNursery.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AttendanceClassPreNursery[0]);
        }

        private DTO.LABURNUM.COM.AttendanceClassPreNurseryModel MapCore(API.LABURNUM.COM.AttendanceClassPreNursery apiclass)
        {

            DTO.LABURNUM.COM.AttendanceClassPreNurseryModel dtoClass = new DTO.LABURNUM.COM.AttendanceClassPreNurseryModel()
            {
                AttendanceClassPreNurseryId = apiclass.AttendanceClassPreNurseryId,
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