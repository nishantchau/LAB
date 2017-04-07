using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class Section
    {
        public List<DTO.LABURNUM.COM.SectionModel> GetActiveSections()
        {
            try
            {
                DTO.LABURNUM.COM.ClassModel model = new DTO.LABURNUM.COM.ClassModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Section/SearchActiveSections", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.SectionModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Section List");
            }
        }

        public List<DTO.LABURNUM.COM.SectionModel> GetAllSections()
        {
            try
            {
                DTO.LABURNUM.COM.SectionModel model = new DTO.LABURNUM.COM.SectionModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Section/SearchAllSections", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.SectionModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Section List");
            }
        }

        public List<DTO.LABURNUM.COM.SectionModel> GetSectionByAdvanceSearch(DTO.LABURNUM.COM.SectionModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Section/SearchSectionByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.SectionModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Section List");
            }
        }

        public List<DTO.LABURNUM.COM.SectionModel> GetSectionByClassId(long classid)
        {
            try
            {
                DTO.LABURNUM.COM.SectionModel model = new DTO.LABURNUM.COM.SectionModel() { ClassId = classid };
                return GetSectionByAdvanceSearch(model);
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Section List");
            }
        }

        public void UpdateSectionStatus(DTO.LABURNUM.COM.ClassModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Section/UpdateStatus", model).Result;
                if (response.IsSuccessStatusCode)
                {

                }
                else { }
            }
            catch (Exception)
            {
                throw new Exception("Error While Updating Section Status");
            }
        }

        public DTO.LABURNUM.COM.SectionModel GetSectionBySectionId(long sectionId)
        {
            try
            {
                DTO.LABURNUM.COM.SectionModel model = new DTO.LABURNUM.COM.SectionModel() { SectionId = sectionId };
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Section/SearchSectionById", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<DTO.LABURNUM.COM.SectionModel>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}