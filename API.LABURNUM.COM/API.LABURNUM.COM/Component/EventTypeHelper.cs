using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class EventTypeHelper
    {
        private List<API.LABURNUM.COM.EventType> EventTypes;

        public EventTypeHelper()
        {
            this.EventTypes = new List<API.LABURNUM.COM.EventType>();
        }

        public EventTypeHelper(List<API.LABURNUM.COM.EventType> eventTypes)
        {
            if (eventTypes == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.EventTypes = eventTypes;
        }

        public EventTypeHelper(API.LABURNUM.COM.EventType eventType)
        {
            if (eventType == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.EventTypes = new List<API.LABURNUM.COM.EventType>();
            this.EventTypes.Add(eventType);
        }

        public List<DTO.LABURNUM.COM.EventTypeModel> Map()
        {
            if (this.EventTypes == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.EventTypeModel> dtoEventTypes = new List<DTO.LABURNUM.COM.EventTypeModel>();
            foreach (API.LABURNUM.COM.EventType item in this.EventTypes)
            {
                dtoEventTypes.Add(MapCore(item));
            }
            return dtoEventTypes;
        }

        public DTO.LABURNUM.COM.EventTypeModel MapSingle()
        {
            if (this.EventTypes == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.EventTypes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.EventTypes[0]);
        }

        private DTO.LABURNUM.COM.EventTypeModel MapCore(API.LABURNUM.COM.EventType eventType)
        {

            DTO.LABURNUM.COM.EventTypeModel dtoClass = new DTO.LABURNUM.COM.EventTypeModel()
            {
                EventTypeId = eventType.EventTypeId,
                Text = eventType.Text,
                CreatedOn = eventType.CreatedOn,
                IsActive = eventType.IsActive,
                LastUpdated = eventType.LastUpdated
            };
            return dtoClass;
        }
    }
}