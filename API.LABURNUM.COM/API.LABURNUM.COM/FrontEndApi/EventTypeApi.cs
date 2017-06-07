using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class EventTypeApi
    {
        private LaburnumEntities _laburnum;

        public EventTypeApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddEventType(DTO.LABURNUM.COM.EventTypeModel model)
        {
            API.LABURNUM.COM.EventType apiEventType = new EventType()
            {
                EventTypeId = model.EventTypeId,
                Text = model.Text,
                CreatedOn = new Component.Utility().GetISTDateTime(),
                IsActive = true
            };
            this._laburnum.EventTypes.Add(apiEventType);
            this._laburnum.SaveChanges();
            return apiEventType.EventTypeId;
        }

        private long AddValidation(DTO.LABURNUM.COM.EventTypeModel model)
        {
            model.Text.TryValidate();
            return AddEventType(model);
        }

        public long Add(DTO.LABURNUM.COM.EventTypeModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.EventTypeModel model)
        {
            model.EventTypeId.TryValidate();
            IQueryable<API.LABURNUM.COM.EventType> iQuery = this._laburnum.EventTypes.Where(x => x.EventTypeId == model.EventTypeId && x.IsActive == true);
            List<API.LABURNUM.COM.EventType> dbEventTypeTypes = iQuery.ToList();
            if (dbEventTypeTypes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbEventTypeTypes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbEventTypeTypes[0].Text = model.Text;
            dbEventTypeTypes[0].LastUpdated = new Component.Utility().GetISTDateTime();
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.EventTypeModel model)
        {
            model.EventTypeId.TryValidate();
            IQueryable<API.LABURNUM.COM.EventType> iQuery = this._laburnum.EventTypes.Where(x => x.EventTypeId == model.EventTypeId && x.IsActive == true);
            List<API.LABURNUM.COM.EventType> dbEventTypeTypes = iQuery.ToList();
            if (dbEventTypeTypes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbEventTypeTypes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbEventTypeTypes[0].IsActive = model.IsActive;
            dbEventTypeTypes[0].LastUpdated = new Component.Utility().GetISTDateTime();
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.EventType> GetActiveEventTypes()
        {
            return this._laburnum.EventTypes.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.EventType> GetInActiveEventTypes()
        {
            return this._laburnum.EventTypes.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.EventType> GetAllEventTypes()
        {
            return this._laburnum.EventTypes.ToList();
        }

        public List<API.LABURNUM.COM.EventType> GetEventTypeByAdvanceSearch(DTO.LABURNUM.COM.EventTypeModel model)
        {
            IQueryable<API.LABURNUM.COM.EventType> iQuery = null;
            
            //SearchBy EventType Id.
            if (model.EventTypeId > 0)
            {
                iQuery = this._laburnum.EventTypes.Where(x => x.EventTypeId == model.EventTypeId && x.IsActive == true);
            }
            //Search By EventTypeId.
            if (iQuery != null)
            {
                if (model.EventTypeId > 0)
                {
                    iQuery = iQuery.Where(x => x.EventTypeId == model.EventTypeId && x.IsActive == true);
                }
            }
            else
            {
                if (model.EventTypeId > 0)
                {
                    iQuery = this._laburnum.EventTypes.Where(x => x.EventTypeId == model.EventTypeId && x.IsActive == true);
                }
            }

            //Search By EventTypeName.
            if (iQuery != null)
            {
                if (model.Text != null)
                {
                    iQuery = iQuery.Where(x => x.Text.Contains(model.Text) && x.IsActive == true);
                }
            }
            else
            {
                if (model.Text != null)
                {
                    iQuery = this._laburnum.EventTypes.Where(x => x.Text.Contains(model.Text) && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.EventType> dbEventTypes = iQuery.ToList();
            return dbEventTypes;
        }

        public API.LABURNUM.COM.EventType GetEventTypeById(long EventTypeId)
        {
            IQueryable<API.LABURNUM.COM.EventType> iQuery = this._laburnum.EventTypes.Where(x => (x.EventTypeId == EventTypeId) && x.IsActive == true);
            List<API.LABURNUM.COM.EventType> dbEventTypes = iQuery.ToList();
            if (dbEventTypes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbEventTypes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            return dbEventTypes[0];
        }
    }
}