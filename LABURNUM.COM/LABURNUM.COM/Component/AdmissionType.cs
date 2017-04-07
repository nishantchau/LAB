using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class AdmissionType
    {
        public List<DTO.LABURNUM.COM.AdmissionTypeModel> GetActiveAdmissionTypes()
        {
            try
            {
                DTO.LABURNUM.COM.ClassModel model = new DTO.LABURNUM.COM.ClassModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("AdmissionType/SearchActiveAdmissionTypes", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.AdmissionTypeModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting AdmissionType List");
            }
        }

        public List<DTO.LABURNUM.COM.AdmissionTypeModel> GetAllAdmissionTypes()
        {
            try
            {
                DTO.LABURNUM.COM.AdmissionTypeModel model = new DTO.LABURNUM.COM.AdmissionTypeModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("AdmissionType/SearchAllAdmissionTypes", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.AdmissionTypeModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting AdmissionType List");
            }
        }

        public void UpdateClasseStatus(DTO.LABURNUM.COM.ClassModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("AdmissionType/UpdateStatus", model).Result;
                if (response.IsSuccessStatusCode)
                {

                }
                else { }
            }
            catch (Exception)
            {
                throw new Exception("Error While Updating AdmissionType Status");
            }
        }

        public List<DTO.LABURNUM.COM.AdmissionTypeModel> GetAdmissionTypeByAdvanceSearch(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("AdmissionType/SearchAdmissionTypeByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.AdmissionTypeModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Admission Type Model List");
            }
        }

        public DTO.LABURNUM.COM.AdmissionTypeModel GetAdmissionTypeByAdmissionTypeId(long id)
        {
            try
            {
                DTO.LABURNUM.COM.AdmissionTypeModel model = new DTO.LABURNUM.COM.AdmissionTypeModel() { AdmissionTypeId = id };
                List<DTO.LABURNUM.COM.AdmissionTypeModel> dbAdmissionTypes = GetAdmissionTypeByAdvanceSearch(model);
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