using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class BusRoute
    {
        public List<DTO.LABURNUM.COM.BusRouteModel> GetActiveBusRoutes()
        {
            try
            {
                DTO.LABURNUM.COM.BusRouteModel model = new DTO.LABURNUM.COM.BusRouteModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("BusRoute/SearchActiveBusRoutes", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.BusRouteModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Bus Route List");
            }
        }

        public List<DTO.LABURNUM.COM.BusRouteModel> GetAllBusRoutes()
        {
            try
            {
                DTO.LABURNUM.COM.ClassModel model = new DTO.LABURNUM.COM.ClassModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("BusRoute/SearchAllBusRoutes", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.BusRouteModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting List");
            }
        }

        public void UpdateBusRouteStatus(DTO.LABURNUM.COM.BusRouteModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("BusRoute/UpdateStatus", model).Result;
                if (response.IsSuccessStatusCode)
                {

                }
                else { }
            }
            catch (Exception)
            {
                throw new Exception("Error While Updating Class Status");
            }
        }

        public List<DTO.LABURNUM.COM.BusRouteModel> GetBusRoutesByAdvanceSearch(DTO.LABURNUM.COM.BusRouteModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("BusRoute/SearchBusRouteByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.BusRouteModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Class List");
            }
        }

        public DTO.LABURNUM.COM.BusRouteModel GetBusRouteByRouteId(long routeId)
        {
            DTO.LABURNUM.COM.BusRouteModel model = new DTO.LABURNUM.COM.BusRouteModel() { BusRouteId = routeId };
            try
            {
                List<DTO.LABURNUM.COM.BusRouteModel> dbBusRoutes = GetBusRoutesByAdvanceSearch(model);
                if (dbBusRoutes.Count == 0) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
                if (dbBusRoutes.Count > 1) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
                return dbBusRoutes[0];
            }
            catch (Exception)
            {
                return model;
            }
        }

        public double GetTransportChargeByRouteId(long routeId)
        {
            try
            {
                return GetBusRouteByRouteId(routeId).TranportCharges;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}