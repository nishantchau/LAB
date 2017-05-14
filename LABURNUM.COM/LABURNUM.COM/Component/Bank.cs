using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class Bank
    {
        public void UpdateBankStatus(DTO.LABURNUM.COM.BankModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Bank/UpdateStatus", model).Result;
                if (response.IsSuccessStatusCode)
                {

                }
                else { }
            }
            catch (Exception)
            {
                throw new Exception("Error While Updating Bank Status");
            }
        }

        public List<DTO.LABURNUM.COM.BankModel> GetBankByAdvanceSearch(DTO.LABURNUM.COM.BankModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Bank/SearchBankByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.BankModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Bank List");
            }
        }

        public DTO.LABURNUM.COM.BankModel GetBankById(long Bankid)
        {
            try
            {
                DTO.LABURNUM.COM.BankModel model = new DTO.LABURNUM.COM.BankModel() { BankId = Bankid };
                List<DTO.LABURNUM.COM.BankModel> dbBanks = GetBankByAdvanceSearch(model);
                if (dbBanks.Count == 0) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
                if (dbBanks.Count > 1) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
                return dbBanks[0];
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Bank List");
            }
        }

        public List<DTO.LABURNUM.COM.BankModel> GetAllActiveBank()
        {
            try
            {
                DTO.LABURNUM.COM.BankModel model = new DTO.LABURNUM.COM.BankModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Bank/SearchAllActiveBank", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.BankModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Bank List");
            }
        }
    }
}