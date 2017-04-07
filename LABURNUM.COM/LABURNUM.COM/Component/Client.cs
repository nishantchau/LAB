using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class Client
    {
        public List<DTO.LABURNUM.COM.ApiClientModel> GetClientList()
        {
            try
            {
                DTO.LABURNUM.COM.ApiClientModel model = new DTO.LABURNUM.COM.ApiClientModel();
                //model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("AdmissionType/SearchActiveAdmissionTypes", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.ApiClientModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting AdmissionType List");
            }
        }
    }
}