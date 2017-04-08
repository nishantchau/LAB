using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class CircularNotificationTracker
    {
        public List<DTO.LABURNUM.COM.CircularNotificationTrackerModel> GetActiveCircularNotificationTrackers()
        {
            try
            {
                DTO.LABURNUM.COM.CircularNotificationTrackerModel model = new DTO.LABURNUM.COM.CircularNotificationTrackerModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("CircularNotificationTracker/SearchActiveCircularNotificationTrackers", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.CircularNotificationTrackerModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting CircularNotificationTracker List");
            }
        }

        public List<DTO.LABURNUM.COM.CircularNotificationTrackerModel> GetAllCircularNotificationTrackers()
        {
            try
            {
                DTO.LABURNUM.COM.CircularNotificationTrackerModel model = new DTO.LABURNUM.COM.CircularNotificationTrackerModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("CircularNotificationTracker/SearchAllCircularNotificationTrackers", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.CircularNotificationTrackerModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting CircularNotificationTracker List");
            }
        }

        public void UpdateCircularNotificationTrackerStatus(DTO.LABURNUM.COM.CircularNotificationTrackerModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("CircularNotificationTracker/UpdateStatus", model).Result;
                if (response.IsSuccessStatusCode)
                {

                }
                else { }
            }
            catch (Exception)
            {
                throw new Exception("Error While Updating CircularNotificationTracker Status");
            }
        }

        public List<DTO.LABURNUM.COM.CircularNotificationTrackerModel> GetCircularNotificationTrackerByAdvanceSearch(DTO.LABURNUM.COM.CircularNotificationTrackerModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("CircularNotificationTracker/SearchCircularNotificationTrackerByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.CircularNotificationTrackerModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting CircularNotificationTracker List");
            }
        }

        public DTO.LABURNUM.COM.CircularNotificationTrackerModel GetCircularNotificationTrackerByCircularNotificationTrackerId(long CircularNotificationTrackerId)
        {
            DTO.LABURNUM.COM.CircularNotificationTrackerModel model = new DTO.LABURNUM.COM.CircularNotificationTrackerModel() { CircularNotificationTrackerId = CircularNotificationTrackerId };
            try
            {
                List<DTO.LABURNUM.COM.CircularNotificationTrackerModel> dbclasses = GetCircularNotificationTrackerByAdvanceSearch(model);
                if (dbclasses.Count == 0) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
                if (dbclasses.Count > 1) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
                return dbclasses[0];
            }
            catch (Exception)
            {
                return model;
            }
        }
    }
}