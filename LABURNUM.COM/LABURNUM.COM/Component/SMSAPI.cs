using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class SMSAPI
    {
        public string GetSMSBalance()
        {
            try
            {
                DTO.LABURNUM.COM.SMSAPIModel model = new DTO.LABURNUM.COM.SMSAPIModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("SMSAPI/SearchSMSBalance", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return data;
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting SMS Balance.");
            }
        }
    }
}