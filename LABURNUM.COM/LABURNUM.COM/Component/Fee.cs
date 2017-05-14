using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class Fee
    {
        public void UpdateFeeStatus(DTO.LABURNUM.COM.FeeModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Fee/UpdateStatus", model).Result;
                if (response.IsSuccessStatusCode)
                {

                }
                else { }
            }
            catch (Exception)
            {
                throw new Exception("Error While Updating Fee Status");
            }
        }

        public List<DTO.LABURNUM.COM.FeeModel> GetFeeByAdvanceSearch(DTO.LABURNUM.COM.FeeModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Fee/SearchFeeByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.FeeModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Fee List");
            }
        }

        public DTO.LABURNUM.COM.FeeModel GetFeeById(long feeid)
        {
            try
            {
                DTO.LABURNUM.COM.FeeModel model = new DTO.LABURNUM.COM.FeeModel() { FeeId = feeid };
                List<DTO.LABURNUM.COM.FeeModel> dbFees = GetFeeByAdvanceSearch(model);
                if (dbFees.Count == 0) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
                if (dbFees.Count > 1) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
                return dbFees[0];
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Fee List");
            }
        }

        public DTO.LABURNUM.COM.FeeModel GetFeeByClassIdandAdmissionType(long classId, bool IsNewAdmission)
        {
            try
            {
                DTO.LABURNUM.COM.FeeModel model = new DTO.LABURNUM.COM.FeeModel() { ClassId = classId };
                if (IsNewAdmission) { model.AdmissionTypeId = DTO.LABURNUM.COM.Utility.AdmissionType.GetValue(DTO.LABURNUM.COM.Utility.EnumAdmissionType.NEWADMISSION); }
                else { model.AdmissionTypeId = DTO.LABURNUM.COM.Utility.AdmissionType.GetValue(DTO.LABURNUM.COM.Utility.EnumAdmissionType.READMISSION); }
                List<DTO.LABURNUM.COM.FeeModel> dbFees = GetFeeByAdvanceSearch(model);
                if (dbFees.Count == 0) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
                if (dbFees.Count > 1) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
                return dbFees[0];
            }
            catch
            {
                return null;
            }
        }

        public List<DTO.LABURNUM.COM.FeeModel> GetAllActiveFee()
        {
            try
            {
                DTO.LABURNUM.COM.FeeModel model = new DTO.LABURNUM.COM.FeeModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Fee/SearchAllActiveFee", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.FeeModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Fee List");
            }
        }
    }
}