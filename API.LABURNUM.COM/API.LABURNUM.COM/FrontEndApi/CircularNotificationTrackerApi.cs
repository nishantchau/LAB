using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;
using System.Globalization;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class CircularNotificationTrackerApi
    {
        private LaburnumEntities _laburnum;

        public CircularNotificationTrackerApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddCircularNotificationTracker(DTO.LABURNUM.COM.CircularNotificationTrackerModel model)
        {
            API.LABURNUM.COM.CircularNotificationTracker apiCircularNotificationTracker = new CircularNotificationTracker()
            {
                CircularId = model.CircularId,
                ReadOn = model.ReadOn,
                UserId = model.UserId,
                UserTypeId = model.UserTypeId,
                LastUpdated = model.LastUpdated,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.CircularNotificationTrackers.Add(apiCircularNotificationTracker);
            this._laburnum.SaveChanges();
            return apiCircularNotificationTracker.CircularNotificationTrackerId;
        }

        private long AddValidation(DTO.LABURNUM.COM.CircularNotificationTrackerModel model)
        {
            model.CircularId.TryValidate();
            model.UserId.TryValidate();
            model.UserTypeId.TryValidate();
            return AddCircularNotificationTracker(model);
        }

        public long Add(DTO.LABURNUM.COM.CircularNotificationTrackerModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.CircularNotificationTrackerModel model)
        {
            model.CircularNotificationTrackerId.TryValidate();
            IQueryable<API.LABURNUM.COM.CircularNotificationTracker> iQuery = this._laburnum.CircularNotificationTrackers.Where(x => x.CircularNotificationTrackerId == model.CircularNotificationTrackerId && x.IsActive == true);
            List<API.LABURNUM.COM.CircularNotificationTracker> dbRoutes = iQuery.ToList();
            if (dbRoutes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbRoutes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }

            dbRoutes[0].CircularId = model.CircularId;
            dbRoutes[0].ReadOn = model.ReadOn;
            dbRoutes[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.CircularNotificationTrackerModel model)
        {
            model.CircularNotificationTrackerId.TryValidate();
            IQueryable<API.LABURNUM.COM.CircularNotificationTracker> iQuery = this._laburnum.CircularNotificationTrackers.Where(x => x.CircularNotificationTrackerId == model.CircularNotificationTrackerId && x.IsActive == true);
            List<API.LABURNUM.COM.CircularNotificationTracker> dbRoutes = iQuery.ToList();
            if (dbRoutes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbRoutes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbRoutes[0].IsActive = model.IsActive;
            dbRoutes[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.CircularNotificationTracker> GetActiveCircularNotificationTrackers()
        {
            return this._laburnum.CircularNotificationTrackers.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.CircularNotificationTracker> GetInActiveCircularNotificationTrackers()
        {
            return this._laburnum.CircularNotificationTrackers.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.CircularNotificationTracker> GetAllCircularNotificationTrackers()
        {
            return this._laburnum.CircularNotificationTrackers.ToList();
        }

        public List<API.LABURNUM.COM.CircularNotificationTracker> GetCircularNotificationTrackerByAdvanceSearch(DTO.LABURNUM.COM.CircularNotificationTrackerModel model)
        {
            IQueryable<API.LABURNUM.COM.CircularNotificationTracker> iQuery = null;

            //Search CircularNotificationTrackerId.
            if (model.CircularNotificationTrackerId > 0)
            {
                iQuery = this._laburnum.CircularNotificationTrackers.Where(x => x.CircularNotificationTrackerId == model.CircularNotificationTrackerId && x.IsActive == true);
            }

            //Search By Date Range.
            if (iQuery != null)
            {
                if (model.StartDate.Year != 0001)
                {
                    string dd = Convert.ToString(model.StartDate.Day);
                    if (dd.Length == 1) { dd = "0" + dd; }
                    string mm = Convert.ToString(model.StartDate.Month);
                    if (mm.Length == 1) { mm = "0" + mm; }
                    string yy = Convert.ToString(model.StartDate.Year);
                    string sdate = dd + "/" + mm + "/" + yy;
                    model.StartDate = DateTime.ParseExact(sdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                if (model.EndDate.Year != 0001)
                {
                    string dd = Convert.ToString(model.EndDate.Day);
                    if (dd.Length == 1) { dd = "0" + dd; }
                    string mm = Convert.ToString(model.StartDate.Month);
                    if (mm.Length == 1) { mm = "0" + mm; }
                    string yy = Convert.ToString(model.StartDate.Year);
                    string sdate = dd + "/" + mm + "/" + yy;
                    model.EndDate = DateTime.ParseExact(sdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                if (model.EndDate.Year == 0001) { model.EndDate = model.StartDate.AddDays(1).AddSeconds(-1); }

                if (model.StartDate.Year != 0001)
                {
                    iQuery = iQuery.Where(x => x.CreatedOn >= model.StartDate && x.CreatedOn <= model.EndDate && x.IsActive == true);

                }
            }
            else
            {
                if (model.StartDate.Year != 0001)
                {
                    string dd = Convert.ToString(model.StartDate.Day);
                    if (dd.Length == 1) { dd = "0" + dd; }
                    string mm = Convert.ToString(model.StartDate.Month);
                    if (mm.Length == 1) { mm = "0" + mm; }
                    string yy = Convert.ToString(model.StartDate.Year);
                    string sdate = dd + "/" + mm + "/" + yy;
                    model.StartDate = DateTime.ParseExact(sdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                if (model.EndDate.Year != 0001)
                {
                    string dd = Convert.ToString(model.EndDate.Day);
                    if (dd.Length == 1) { dd = "0" + dd; }
                    string mm = Convert.ToString(model.StartDate.Month);
                    if (mm.Length == 1) { mm = "0" + mm; }
                    string yy = Convert.ToString(model.StartDate.Year);
                    string sdate = dd + "/" + mm + "/" + yy;
                    model.EndDate = DateTime.ParseExact(sdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                if (model.EndDate.Year == 0001) { model.EndDate = model.StartDate.AddDays(1).AddSeconds(-1); }

                if (model.StartDate.Year != 0001)
                {
                    iQuery = this._laburnum.CircularNotificationTrackers.Where(x => x.CreatedOn >= model.StartDate && x.CreatedOn <= model.EndDate && x.IsActive == true);

                }
            }

            List<API.LABURNUM.COM.CircularNotificationTracker> dbCircularNotificationTracker = iQuery.ToList();
            return dbCircularNotificationTracker;
        }
    }
}