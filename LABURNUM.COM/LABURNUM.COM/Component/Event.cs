using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class Event
    {
        public List<DTO.LABURNUM.COM.EventModel> GetActiveEvents()
        {
            try
            {
                DTO.LABURNUM.COM.EventModel model = new DTO.LABURNUM.COM.EventModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Event/SearchActiveEvents", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.EventModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Event Model List");
            }
        }

        public List<DTO.LABURNUM.COM.EventModel> GetAllEvents()
        {
            try
            {
                DTO.LABURNUM.COM.EventModel model = new DTO.LABURNUM.COM.EventModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Event/SearchAllEvents", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.EventModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Event Model List");
            }
        }

        public void UpdateClasseStatus(DTO.LABURNUM.COM.EventModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Event/UpdateStatus", model).Result;
                if (response.IsSuccessStatusCode)
                {

                }
                else { }
            }
            catch (Exception)
            {
                throw new Exception("Error While Updating Event Status");
            }
        }

        public List<DTO.LABURNUM.COM.EventModel> GetEventByAdvanceSearch(DTO.LABURNUM.COM.EventModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Event/SearchEventByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.EventModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Event Model List");
            }
        }

        public List<DTO.LABURNUM.COM.EventModel> GetEventsForSite()
        {
            try
            {
                DTO.LABURNUM.COM.EventModel model = new DTO.LABURNUM.COM.EventModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Event/SearchEventForSite", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.EventModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Event Model List");
            }
        }
        public DTO.LABURNUM.COM.EventModel GetEventByEventId(long id)
        {
            try
            {
                DTO.LABURNUM.COM.EventModel model = new DTO.LABURNUM.COM.EventModel() { EventId = id };
                List<DTO.LABURNUM.COM.EventModel> dbAdmissionTypes = GetEventByAdvanceSearch(model);
                if (dbAdmissionTypes.Count == 0) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
                if (dbAdmissionTypes.Count > 1) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
                return dbAdmissionTypes[0];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}