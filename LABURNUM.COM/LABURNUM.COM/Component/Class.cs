using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace LABURNUM.COM.Component
{
    public class Class
    {
        public List<DTO.LABURNUM.COM.ClassModel> GetActiveClasses()
        {
            try
            {
                DTO.LABURNUM.COM.ClassModel model = new DTO.LABURNUM.COM.ClassModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Class/SearchActiveClasses", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.ClassModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Class List");
            }
        }

        public List<DTO.LABURNUM.COM.ClassModel> GetAllClasses()
        {
            try
            {
                DTO.LABURNUM.COM.ClassModel model = new DTO.LABURNUM.COM.ClassModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Class/SearchAllClasses", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.ClassModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting List");
            }
        }

        public void UpdateClasseStatus(DTO.LABURNUM.COM.ClassModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Class/UpdateStatus", model).Result;
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

        public List<DTO.LABURNUM.COM.ClassModel> GetClassesByAdvanceSearch(DTO.LABURNUM.COM.ClassModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Class/SearchClassByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.ClassModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Class List");
            }
        }

        public DTO.LABURNUM.COM.ClassModel GetClassByClassId(long classId)
        {
            DTO.LABURNUM.COM.ClassModel model = new DTO.LABURNUM.COM.ClassModel() { ClassId = classId };
            try
            {
                List<DTO.LABURNUM.COM.ClassModel> dbclasses = GetClassesByAdvanceSearch(model);
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