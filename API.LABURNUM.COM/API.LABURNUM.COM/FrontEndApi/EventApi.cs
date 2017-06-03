using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class EventApi
    {
        private LaburnumEntities _laburnum;

        public EventApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddEventType(DTO.LABURNUM.COM.EventModel model)
        {
            API.LABURNUM.COM.Event apievent = new Event()
            {
                EventDate = model.EventDate,
                EventName = model.EventName,
                EventTypeId = model.EventTypeId,
                Classes = model.Classes,
                AcademicYearId=model.AcademicYearId,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.Events.Add(apievent);
            this._laburnum.SaveChanges();
            return apievent.EventId;
        }

        private long AddValidation(DTO.LABURNUM.COM.EventModel model)
        {
            model.EventTypeId.TryValidate();
            model.EventName.TryValidate();
            model.Classes.TryValidate();
            return AddEventType(model);
        }

        public long Add(DTO.LABURNUM.COM.EventModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.EventModel model)
        {
            model.EventId.TryValidate();
            IQueryable<API.LABURNUM.COM.Event> iQuery = this._laburnum.Events.Where(x => x.EventId == model.EventId && x.IsActive == true);
            List<API.LABURNUM.COM.Event> dbEventTypes = iQuery.ToList();
            if (dbEventTypes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbEventTypes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbEventTypes[0].EventName = model.EventName;
            dbEventTypes[0].Classes = model.Classes;
            dbEventTypes[0].EventTypeId = model.EventTypeId;
            dbEventTypes[0].EventDate = model.EventDate;
            dbEventTypes[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.EventModel model)
        {
            model.EventId.TryValidate();
            IQueryable<API.LABURNUM.COM.Event> iQuery = this._laburnum.Events.Where(x => x.EventId == model.EventId && x.IsActive == true);
            List<API.LABURNUM.COM.Event> dbEventTypes = iQuery.ToList();
            if (dbEventTypes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbEventTypes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbEventTypes[0].IsActive = model.IsActive;
            dbEventTypes[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.Event> GetActiveEvents()
        {
            return this._laburnum.Events.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.Event> GetInActiveEvents()
        {
            return this._laburnum.Events.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.Event> GetAllEvents()
        {
            return this._laburnum.Events.ToList();
        }

        public List<API.LABURNUM.COM.Event> GetEventByAdvanceSearch(DTO.LABURNUM.COM.EventModel model)
        {
            IQueryable<API.LABURNUM.COM.Event> iQuery = null;
            if (model.EventId > 0)
            {
                iQuery = this._laburnum.Events.Where(x => x.EventId == model.EventId && x.IsActive == true);
            }
            //Search By AcademicYearId.
            if (iQuery != null)
            {
                if (model.AcademicYearId > 0)
                {
                    iQuery = iQuery.Where(x => x.AcademicYearId == model.AcademicYearId && x.IsActive == true);
                }
            }
            else
            {
                if (model.AcademicYearId > 0)
                {
                    iQuery = this._laburnum.Events.Where(x => x.AcademicYearId == model.AcademicYearId && x.IsActive == true);
                }
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
                    iQuery = this._laburnum.Events.Where(x => x.EventTypeId == model.EventTypeId && x.IsActive == true);
                }
            }

            //Search By EventName.
            if (iQuery != null)
            {
                if (model.EventName != null)
                {
                    iQuery = iQuery.Where(x => x.EventName.Contains(model.EventName) && x.IsActive == true);
                }
            }
            else
            {
                if (model.EventName != null)
                {
                    iQuery = this._laburnum.Events.Where(x => x.EventName.Contains(model.EventName) && x.IsActive == true);
                }
            }

            //Search By Date Range.
            if (iQuery != null)
            {
                if (model.StartDate.Year != 0001)
                {
                    model.StartDate = new Component.Utility().GetDate(model.StartDate);
                }
                if (model.EndDate.Year != 0001)
                {
                    model.EndDate = new Component.Utility().GetDate(model.EndDate).AddDays(1).AddSeconds(-1);
                }
                if (model.EndDate.Year == 0001) { model.EndDate = model.StartDate.AddDays(1).AddSeconds(-1); }

                if (model.StartDate.Year != 0001)
                {
                    iQuery = iQuery.Where(x => x.EventDate >= model.StartDate && x.EventDate <= model.EndDate && x.IsActive == true);
                }
            }
            else
            {
                if (model.StartDate.Year != 0001)
                {
                    model.StartDate = new Component.Utility().GetDate(model.StartDate);
                }
                if (model.EndDate.Year != 0001)
                {
                    model.EndDate = new Component.Utility().GetDate(model.EndDate).AddDays(1).AddSeconds(-1);
                }
                if (model.EndDate.Year == 0001) { model.EndDate = model.StartDate.AddDays(1).AddSeconds(-1); }

                if (model.StartDate.Year != 0001)
                {
                    iQuery = this._laburnum.Events.Where(x => x.EventDate >= model.StartDate && x.EventDate <= model.EndDate && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.Event> dbEvents = iQuery.ToList();
            return dbEvents;
        }

        public API.LABURNUM.COM.Event GetEventById(long eventId)
        {
            IQueryable<API.LABURNUM.COM.Event> iQuery = this._laburnum.Events.Where(x => (x.EventId == eventId) && x.IsActive == true);
            List<API.LABURNUM.COM.Event> dbEvents = iQuery.ToList();
            if (dbEvents.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbEvents.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            return dbEvents[0];
        }
    }
}