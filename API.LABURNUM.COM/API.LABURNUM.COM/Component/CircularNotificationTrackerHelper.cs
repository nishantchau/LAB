using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class CircularNotificationTrackerHelper
    {
        private List<API.LABURNUM.COM.CircularNotificationTracker> CircularNotificationTrackers;

        public CircularNotificationTrackerHelper()
        {
            this.CircularNotificationTrackers = new List<API.LABURNUM.COM.CircularNotificationTracker>();
        }

        public CircularNotificationTrackerHelper(List<API.LABURNUM.COM.CircularNotificationTracker> circularNotificationTrackers)
        {
            if (circularNotificationTrackers == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.CircularNotificationTrackers = circularNotificationTrackers;
        }

        public CircularNotificationTrackerHelper(API.LABURNUM.COM.CircularNotificationTracker circularNotificationTracker)
        {
            if (circularNotificationTracker == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.CircularNotificationTrackers = new List<API.LABURNUM.COM.CircularNotificationTracker>();
            this.CircularNotificationTrackers.Add(circularNotificationTracker);
        }

        public List<DTO.LABURNUM.COM.CircularNotificationTrackerModel> Map()
        {
            if (this.CircularNotificationTrackers == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.CircularNotificationTrackerModel> dtoClasses = new List<DTO.LABURNUM.COM.CircularNotificationTrackerModel>();
            foreach (API.LABURNUM.COM.CircularNotificationTracker item in this.CircularNotificationTrackers)
            {
                dtoClasses.Add(MapCore(item));
            }
            return dtoClasses;
        }

        public DTO.LABURNUM.COM.CircularNotificationTrackerModel MapSingle()
        {
            if (this.CircularNotificationTrackers == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.CircularNotificationTrackers.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.CircularNotificationTrackers[0]);
        }

        private DTO.LABURNUM.COM.CircularNotificationTrackerModel MapCore(API.LABURNUM.COM.CircularNotificationTracker model)
        {

            DTO.LABURNUM.COM.CircularNotificationTrackerModel dtoClass = new DTO.LABURNUM.COM.CircularNotificationTrackerModel()
            {
                CircularId = model.CircularId,
                CircularNotificationTrackerId = model.CircularNotificationTrackerId,
                ReadOn = model.ReadOn,
                UserId = model.UserId,
                UserTypeId = model.UserTypeId,
                CreatedOn = model.CreatedOn,
                IsActive = model.IsActive,
                LastUpdated = model.LastUpdated
            };
            return dtoClass;
        }
    }
}