using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class BusRouteHelper
    {
        private List<API.LABURNUM.COM.BusRoute> BusRoutes;

        public BusRouteHelper()
        {
            this.BusRoutes = new List<API.LABURNUM.COM.BusRoute>();
        }

        public BusRouteHelper(List<API.LABURNUM.COM.BusRoute> busRoutes)
        {
            if (busRoutes == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.BusRoutes = busRoutes;
        }

        public BusRouteHelper(API.LABURNUM.COM.BusRoute busRoute)
        {
            if (busRoute == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.BusRoutes = new List<API.LABURNUM.COM.BusRoute>();
            this.BusRoutes.Add(busRoute);
        }

        public List<DTO.LABURNUM.COM.BusRouteModel> Map()
        {
            if (this.BusRoutes == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.BusRouteModel> dtoBusRoutes = new List<DTO.LABURNUM.COM.BusRouteModel>();
            foreach (API.LABURNUM.COM.BusRoute item in this.BusRoutes)
            {
                dtoBusRoutes.Add(MapCore(item));
            }
            return dtoBusRoutes;
        }

        public DTO.LABURNUM.COM.BusRouteModel MapSingle()
        {
            if (this.BusRoutes == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.BusRoutes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.BusRoutes[0]);
        }

        private DTO.LABURNUM.COM.BusRouteModel MapCore(API.LABURNUM.COM.BusRoute apiBusRoute)
        {

            DTO.LABURNUM.COM.BusRouteModel dtoClass = new DTO.LABURNUM.COM.BusRouteModel()
            {
                BusRouteId = apiBusRoute.BusRouteId,
                BusRouteNumber = apiBusRoute.BusRouteNumber,
                BusStartFrom = apiBusRoute.BusStartFrom,
                BusEndAt = apiBusRoute.BusEndAt,
                TranportCharges = apiBusRoute.TranportCharges,
                CreatedOn = apiBusRoute.CreatedOn,
                IsActive = apiBusRoute.IsActive,
                LastUpdate = apiBusRoute.LastUpdate,
                StartPointEndPoint = apiBusRoute.BusStartFrom + " To " + apiBusRoute.BusEndAt
            };
            return dtoClass;
        }
    }
}