using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class CurriculumDetail
    {
        public List<DTO.LABURNUM.COM.CurriculumDetailModel> GetActiveCurriculumDetails()
        {
            try
            {
                DTO.LABURNUM.COM.ClassModel model = new DTO.LABURNUM.COM.ClassModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("CurriculumDetail/SearchActiveCurriculumDetails", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.CurriculumDetailModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting CurriculumDetail List");
            }
        }

        public List<DTO.LABURNUM.COM.CurriculumDetailModel> GetAllCurriculumDetails()
        {
            try
            {
                DTO.LABURNUM.COM.CurriculumDetailModel model = new DTO.LABURNUM.COM.CurriculumDetailModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("CurriculumDetail/SearchAllCurriculumDetails", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.CurriculumDetailModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting CurriculumDetail List");
            }
        }

        public void UpdateCurriculumDetailStatus(DTO.LABURNUM.COM.CurriculumDetailModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("CurriculumDetail/UpdateStatus", model).Result;
                if (response.IsSuccessStatusCode)
                {

                }
                else { }
            }
            catch (Exception)
            {
                throw new Exception("Error While Updating CurriculumDetail Status");
            }
        }

        public List<DTO.LABURNUM.COM.CurriculumDetailModel> GetCurriculumDetailByAdvanceSearch(DTO.LABURNUM.COM.CurriculumDetailModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("CurriculumDetail/SearchCurriculumDetailByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.CurriculumDetailModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Admission Type Model List");
            }
        }

        public DTO.LABURNUM.COM.CurriculumDetailModel GetCurriculumDetailByCurriculumDetailId(long id)
        {
            try
            {
                DTO.LABURNUM.COM.CurriculumDetailModel model = new DTO.LABURNUM.COM.CurriculumDetailModel() { CurriculumDetailId = id };
                List<DTO.LABURNUM.COM.CurriculumDetailModel> dbCurriculumDetails = GetCurriculumDetailByAdvanceSearch(model);
                if (dbCurriculumDetails.Count == 0) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
                if (dbCurriculumDetails.Count > 1) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
                return dbCurriculumDetails[0];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}