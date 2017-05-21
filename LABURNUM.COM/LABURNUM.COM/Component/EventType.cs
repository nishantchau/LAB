using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class EventType
    {
        public List<DTO.LABURNUM.COM.EventTypeModel> GetActiveEventTypes()
        {
            try
            {
                DTO.LABURNUM.COM.EventTypeModel model = new DTO.LABURNUM.COM.EventTypeModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("EventType/SearchActiveEventTypes", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.EventTypeModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Academic Year Table Model List");
            }
        }

        public List<DTO.LABURNUM.COM.EventTypeModel> GetAllAdmissionTypes()
        {
            try
            {
                DTO.LABURNUM.COM.EventTypeModel model = new DTO.LABURNUM.COM.EventTypeModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("EventType/SearchAllEventTypes", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.EventTypeModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Event Type Model List");
            }
        }

        public void UpdateClasseStatus(DTO.LABURNUM.COM.EventTypeModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("EventType/UpdateStatus", model).Result;
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

        public List<DTO.LABURNUM.COM.EventTypeModel> GetEventTypeByAdvanceSearch(DTO.LABURNUM.COM.EventTypeModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("EventType/SearchEventTypeByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.EventTypeModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Event Type List");
            }
        }

        public DTO.LABURNUM.COM.EventTypeModel GetEventTypeByEventTypeId(long id)
        {
            try
            {
                DTO.LABURNUM.COM.EventTypeModel model = new DTO.LABURNUM.COM.EventTypeModel() { EventTypeId = id };
                List<DTO.LABURNUM.COM.EventTypeModel> dbEventTypes = GetEventTypeByAdvanceSearch(model);
                if (dbEventTypes.Count == 0) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
                if (dbEventTypes.Count > 1) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
                return dbEventTypes[0];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}