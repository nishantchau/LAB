using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class Circular
    {
        public List<DTO.LABURNUM.COM.CircularModel> GetActiveCirculars()
        {
            try
            {
                DTO.LABURNUM.COM.CircularModel model = new DTO.LABURNUM.COM.CircularModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Circular/SearchActiveCirculars", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.CircularModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Circular List");
            }
        }

        public List<DTO.LABURNUM.COM.CircularModel> GetAllCirculars()
        {
            try
            {
                DTO.LABURNUM.COM.CircularModel model = new DTO.LABURNUM.COM.CircularModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Circular/SearchAllCirculars", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.CircularModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Circular List");
            }
        }

        public void UpdateCircularStatus(DTO.LABURNUM.COM.CircularModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Circular/UpdateStatus", model).Result;
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

        public List<DTO.LABURNUM.COM.CircularModel> GetCircularByAdvanceSearch(DTO.LABURNUM.COM.CircularModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Circular/SearchCircularByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.CircularModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Circular List");
            }
        }

        public DTO.LABURNUM.COM.CircularModel GetCircularByCircularId(long circularId)
        {
            DTO.LABURNUM.COM.CircularModel model = new DTO.LABURNUM.COM.CircularModel() { CircularId = circularId };
            try
            {
                List<DTO.LABURNUM.COM.CircularModel> dbclasses = GetCircularByAdvanceSearch(model);
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