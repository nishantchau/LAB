using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class HomeWork
    {
        public List<DTO.LABURNUM.COM.HomeWorkModel> GetActiveHomeWork()
        {
            try
            {
                DTO.LABURNUM.COM.HomeWorkModel model = new DTO.LABURNUM.COM.HomeWorkModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("HomeWork/SearchActiveHomeWork", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.HomeWorkModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting HomeWork List");
            }
        }

        public List<DTO.LABURNUM.COM.HomeWorkModel> GetAllHomeWork()
        {
            try
            {
                DTO.LABURNUM.COM.HomeWorkModel model = new DTO.LABURNUM.COM.HomeWorkModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("HomeWork/SearchAllHomeWork", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.HomeWorkModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting List");
            }
        }

        public void UpdateHomeWorkStatus(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("HomeWork/UpdateStatus", model).Result;
                if (response.IsSuccessStatusCode)
                {

                }
                else { }
            }
            catch (Exception)
            {
                throw new Exception("Error While Updating HomeWork Status");
            }
        }

        public List<DTO.LABURNUM.COM.HomeWorkModel> GetHomeWorkByAdvanceSearch(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("HomeWork/SearchHomeWorkByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.HomeWorkModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting HomeWork List");
            }
        }

        public DTO.LABURNUM.COM.HomeWorkModel GetHomeWorkById(long homeworkId)
        {
            DTO.LABURNUM.COM.HomeWorkModel model = new DTO.LABURNUM.COM.HomeWorkModel() { HomeWorkId = homeworkId };
            try
            {
                List<DTO.LABURNUM.COM.HomeWorkModel> dbclasses = GetHomeWorkByAdvanceSearch(model);
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