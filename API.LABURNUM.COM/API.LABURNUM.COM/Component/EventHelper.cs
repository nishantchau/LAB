using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class EventHelper
    {
        private List<API.LABURNUM.COM.Event> Events;

        public EventHelper()
        {
            this.Events = new List<API.LABURNUM.COM.Event>();
        }

        public EventHelper(List<API.LABURNUM.COM.Event> events)
        {
            if (events == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.Events = events;
        }

        public EventHelper(API.LABURNUM.COM.Event apiEvent)
        {
            if (apiEvent == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.Events = new List<API.LABURNUM.COM.Event>();
            this.Events.Add(apiEvent);
        }

        public List<DTO.LABURNUM.COM.EventModel> Map()
        {
            if (this.Events == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.EventModel> dtoEvents = new List<DTO.LABURNUM.COM.EventModel>();
            foreach (API.LABURNUM.COM.Event item in this.Events)
            {
                dtoEvents.Add(MapCore(item));
            }
            return dtoEvents;
        }

        public DTO.LABURNUM.COM.EventModel MapSingle()
        {
            if (this.Events == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.Events.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.Events[0]);
        }

        private DTO.LABURNUM.COM.EventModel MapCore(API.LABURNUM.COM.Event apiEvent)
        {

            DTO.LABURNUM.COM.EventModel dtoClass = new DTO.LABURNUM.COM.EventModel()
            {
                EventId = apiEvent.EventId,
                EventName = apiEvent.EventName,
                EventTypeId = apiEvent.EventTypeId,
                AcademicYearId = apiEvent.AcademicYearId,
                Classes = apiEvent.Classes,
                EventDate = apiEvent.EventDate,
                EventTypeText = apiEvent.EventType.Text,
                AcademicYearText = apiEvent.AcademicYearTable.StartYear + "-" + apiEvent.AcademicYearTable.EndYear,
                CreatedOn = apiEvent.CreatedOn,
                IsActive = apiEvent.IsActive,
                LastUpdated = apiEvent.LastUpdated
            };
            return dtoClass;
        }
    }
}