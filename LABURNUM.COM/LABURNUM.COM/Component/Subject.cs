using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class Subject
    {
        public List<DTO.LABURNUM.COM.SubjectModel> GetActiveSubjectes()
        {
            try
            {
                DTO.LABURNUM.COM.SubjectModel model = new DTO.LABURNUM.COM.SubjectModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Subject/SearchActiveSubjectes", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.SubjectModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Subject List");
            }
        }

        public List<DTO.LABURNUM.COM.SubjectModel> GetAllSubjectes()
        {
            try
            {
                DTO.LABURNUM.COM.SubjectModel model = new DTO.LABURNUM.COM.SubjectModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Subject/SearchAllSubjectes", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.SubjectModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting List");
            }
        }

        public void UpdateSubjecteStatus(DTO.LABURNUM.COM.SubjectModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Subject/UpdateStatus", model).Result;
                if (response.IsSuccessStatusCode)
                {

                }
                else { }
            }
            catch (Exception)
            {
                throw new Exception("Error While Updating Subject Status");
            }
        }

        public List<DTO.LABURNUM.COM.SubjectModel> GetSubjectesByAdvanceSearch(DTO.LABURNUM.COM.SubjectModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Subject/SearchSubjectByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.SubjectModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Subject List");
            }
        }

        public DTO.LABURNUM.COM.SubjectModel GetSubjectBySubjectId(long SubjectId)
        {
            DTO.LABURNUM.COM.SubjectModel model = new DTO.LABURNUM.COM.SubjectModel() { SubjectId = SubjectId };
            try
            {
                List<DTO.LABURNUM.COM.SubjectModel> dbSubjectes = GetSubjectesByAdvanceSearch(model);
                if (dbSubjectes.Count == 0) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
                if (dbSubjectes.Count > 1) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
                return dbSubjectes[0];
            }
            catch (Exception)
            {
                return model;
            }
        }
    }
}