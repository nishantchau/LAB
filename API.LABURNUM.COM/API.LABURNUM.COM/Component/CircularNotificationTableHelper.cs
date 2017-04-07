using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class CircularNotificationTableHelper
    {
        private List<API.LABURNUM.COM.CircularNotificationTable> CircularNotifications;

        public CircularNotificationTableHelper()
        {
            this.CircularNotifications = new List<API.LABURNUM.COM.CircularNotificationTable>();
        }

        public CircularNotificationTableHelper(List<API.LABURNUM.COM.CircularNotificationTable> circularNotifications)
        {
            if (circularNotifications == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.CircularNotifications = circularNotifications;
        }

        public CircularNotificationTableHelper(API.LABURNUM.COM.CircularNotificationTable circularNotification)
        {
            if (circularNotification == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.CircularNotifications = new List<API.LABURNUM.COM.CircularNotificationTable>();
            this.CircularNotifications.Add(circularNotification);
        }

        public List<DTO.LABURNUM.COM.CircularNotificationTableModel> Map()
        {
            if (this.CircularNotifications == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.CircularNotificationTableModel> dtoClasses = new List<DTO.LABURNUM.COM.CircularNotificationTableModel>();
            foreach (API.LABURNUM.COM.CircularNotificationTable item in this.CircularNotifications)
            {
                dtoClasses.Add(MapCore(item));
            }
            return dtoClasses;
        }

        public DTO.LABURNUM.COM.CircularNotificationTableModel MapSingle()
        {
            if (this.CircularNotifications == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.CircularNotifications.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.CircularNotifications[0]);
        }

        private DTO.LABURNUM.COM.CircularNotificationTableModel MapCore(API.LABURNUM.COM.CircularNotificationTable model)
        {

            DTO.LABURNUM.COM.CircularNotificationTableModel dtoClass = new DTO.LABURNUM.COM.CircularNotificationTableModel()
            {
                CircularNotificationTableId = model.CircularNotificationTableId,
                CircularId = model.CircularId,
                IsForAdmin = model.IsForAdmin,
                IsForFaculty = model.IsForFaculty,
                IsForParents = model.IsForParents,
                IsForStudent = model.IsForStudent,
                ClassIds=model.ClassIds,
                CreatedOn = model.CreatedOn,
                IsActive = model.IsActive,
                LastUpdated = model.LastUpdated
            };
            return dtoClass;
        }
    }
}