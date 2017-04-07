using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class LoginActivity
    {
        public long AddLoginActivity(DTO.LABURNUM.COM.LoginActivityModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("LoginActivity/Add", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return Convert.ToInt64(data);
                }
                else { return -1; }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public void UpdateLoginActivity(long loginActivityId)
        {
            try
            {
                DTO.LABURNUM.COM.LoginActivityModel model = new DTO.LABURNUM.COM.LoginActivityModel() { LoginActivityId = loginActivityId };
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("LoginActivity/Update", model).Result;
                if (response.IsSuccessStatusCode)
                {
                }
            }
            catch (Exception)
            {
            }
        }

        public List<DTO.LABURNUM.COM.LoginActivityModel> GetLoginActivityByAdvSearch(DTO.LABURNUM.COM.LoginActivityModel model)
        {
            try
            {

                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("LoginActivity/SearchLoginActivityByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    List<DTO.LABURNUM.COM.LoginActivityModel> dbLoginActivities = JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.LoginActivityModel>>(data);
                    return dbLoginActivities;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}