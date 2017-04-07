using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class BusRouteApi
    {
        private LaburnumEntities _laburnum;

        public BusRouteApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddBusRoute(DTO.LABURNUM.COM.BusRouteModel model)
        {
            API.LABURNUM.COM.BusRoute apibusRoute = new BusRoute()
            {
                BusRouteNumber = model.BusRouteNumber,
                BusStartFrom = model.BusStartFrom,
                BusEndAt = model.BusEndAt,
                TranportCharges=model.TranportCharges,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.BusRoutes.Add(apibusRoute);
            this._laburnum.SaveChanges();
            return apibusRoute.BusRouteId;
        }

        private long AddValidation(DTO.LABURNUM.COM.BusRouteModel model)
        {
            model.BusStartFrom.TryValidate();
            model.BusRouteNumber.TryValidate();
            model.BusEndAt.TryValidate();
            return AddBusRoute(model);
        }

        public long Add(DTO.LABURNUM.COM.BusRouteModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.BusRouteModel model)
        {
            model.BusRouteId.TryValidate();
            IQueryable<API.LABURNUM.COM.BusRoute> iQuery = this._laburnum.BusRoutes.Where(x => x.BusRouteId == model.BusRouteId && x.IsActive == true);
            List<API.LABURNUM.COM.BusRoute> dbRoutes = iQuery.ToList();
            if (dbRoutes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbRoutes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbRoutes[0].BusStartFrom = model.BusStartFrom;
            dbRoutes[0].BusEndAt = model.BusEndAt;
            dbRoutes[0].BusRouteNumber = model.BusRouteNumber;
            dbRoutes[0].TranportCharges = model.TranportCharges;
            dbRoutes[0].LastUpdate = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.BusRouteModel model)
        {
            model.BusRouteId.TryValidate();
            IQueryable<API.LABURNUM.COM.BusRoute> iQuery = this._laburnum.BusRoutes.Where(x => x.BusRouteId == model.BusRouteId && x.IsActive == true);
            List<API.LABURNUM.COM.BusRoute> dbRoutes = iQuery.ToList();
            if (dbRoutes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbRoutes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbRoutes[0].IsActive = model.IsActive;
            dbRoutes[0].LastUpdate = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.BusRoute> GetActiveBusRoutes()
        {
            return this._laburnum.BusRoutes.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.BusRoute> GetInActiveBusRoutes()
        {
            return this._laburnum.BusRoutes.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.BusRoute> GetAllBusRoutes()
        {
            return this._laburnum.BusRoutes.ToList();
        }

        public List<API.LABURNUM.COM.BusRoute> GetBusRouteByAdvanceSearch(DTO.LABURNUM.COM.BusRouteModel model)
        {
            IQueryable<API.LABURNUM.COM.BusRoute> iQuery = null;

            //Search Bus Route Id.
            if (model.BusRouteId > 0)
            {
                iQuery = this._laburnum.BusRoutes.Where(x => x.BusRouteId == model.BusRouteId && x.IsActive == true);
            }

            //Search Bus Number.
            if (iQuery != null)
            {
                if (model.BusRouteNumber != null)
                {
                    iQuery = iQuery.Where(x => x.BusRouteNumber.Trim().ToLower().Equals(model.BusRouteNumber.Trim().ToLower()) && x.IsActive == true);
                }
            }
            else
            {
                if (model.BusRouteNumber != null)
                {
                    iQuery = this._laburnum.BusRoutes.Where(x => x.BusRouteNumber.Trim().ToLower().Equals(model.BusRouteNumber.Trim().ToLower()) && x.IsActive == true);
                }
            }

            //Search Bus Start From.
            if (iQuery != null)
            {
                if (model.BusStartFrom != null)
                {
                    iQuery = iQuery.Where(x => x.BusStartFrom.Trim().ToLower().Contains(model.BusStartFrom.Trim().ToLower()) && x.IsActive == true);
                }
            }
            else
            {
                if (model.BusStartFrom != null)
                {
                    iQuery = this._laburnum.BusRoutes.Where(x => x.BusStartFrom.Trim().ToLower().Contains(model.BusStartFrom.Trim().ToLower()) && x.IsActive == true);
                }
            }

            //Search Bus End At.
            if (iQuery != null)
            {
                if (model.BusEndAt != null)
                {
                    iQuery = iQuery.Where(x => x.BusEndAt.Trim().ToLower().Contains(model.BusEndAt.Trim().ToLower()) && x.IsActive == true);
                }
            }
            else
            {
                if (model.BusEndAt != null)
                {
                    iQuery = this._laburnum.BusRoutes.Where(x => x.BusEndAt.Trim().ToLower().Contains(model.BusEndAt.Trim().ToLower()) && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.BusRoute> dbBusRoute = iQuery.ToList();
            return dbBusRoute;
        }
    }
}