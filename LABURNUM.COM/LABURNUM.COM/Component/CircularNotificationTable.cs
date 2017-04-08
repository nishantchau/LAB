using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class CircularNotificationTable
    {
        public List<DTO.LABURNUM.COM.CircularNotificationTableModel> GetActiveCircularNotificationTables()
        {
            try
            {
                DTO.LABURNUM.COM.CircularNotificationTableModel model = new DTO.LABURNUM.COM.CircularNotificationTableModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("CircularNotificationTable/SearchActiveCircularNotificationTable", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.CircularNotificationTableModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Circular List");
            }
        }

        public List<DTO.LABURNUM.COM.CircularNotificationTableModel> GetAllCircularNotificationTables()
        {
            try
            {
                DTO.LABURNUM.COM.CircularModel model = new DTO.LABURNUM.COM.CircularModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("CircularNotificationTable/SearchAllCircularNotificationTable", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.CircularNotificationTableModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Circular List");
            }
        }

        public void UpdateCircularNotificationTableStatus(DTO.LABURNUM.COM.CircularNotificationTableModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("CircularNotificationTable/UpdateStatus", model).Result;
                if (response.IsSuccessStatusCode)
                {

                }
                else { }
            }
            catch (Exception)
            {
                throw new Exception("Error While Updating Circular Status");
            }
        }

        public List<DTO.LABURNUM.COM.CircularNotificationTableModel> GetCircularNotificationTableByAdvanceSearch(DTO.LABURNUM.COM.CircularNotificationTableModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("CircularNotificationTable/SearchCircularNotificationTableByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.CircularNotificationTableModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Circular List");
            }
        }

        public DTO.LABURNUM.COM.CircularNotificationTableModel GetCircularNotificationTableById(long circularId)
        {
            DTO.LABURNUM.COM.CircularNotificationTableModel model = new DTO.LABURNUM.COM.CircularNotificationTableModel() { CircularId = circularId };
            try
            {
                List<DTO.LABURNUM.COM.CircularNotificationTableModel> dbCircularNotificationTables = GetCircularNotificationTableByAdvanceSearch(model);
                if (dbCircularNotificationTables.Count == 0) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
                if (dbCircularNotificationTables.Count > 1) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
                return dbCircularNotificationTables[0];
            }
            catch (Exception)
            {
                return model;
            }
        }
    }
}