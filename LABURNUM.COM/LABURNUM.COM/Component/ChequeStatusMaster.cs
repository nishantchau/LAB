using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class ChequeStatusMaster
    {
        public List<DTO.LABURNUM.COM.ChequeStatusMasterModel> GetActiveChequeStatusMasters()
        {
            try
            {
                DTO.LABURNUM.COM.ChequeStatusMasterModel model = new DTO.LABURNUM.COM.ChequeStatusMasterModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("ChequeStatusMaster/SearchActiveChequeStatusMasters", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.ChequeStatusMasterModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Cheque Status Master List");
            }
        }
    }
}