using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class UserTypes
    {
        public List<DTO.LABURNUM.COM.UserTypeModel> GetActiveUserTypes()
        {
            try
            {
                DTO.LABURNUM.COM.UserTypeModel model = new DTO.LABURNUM.COM.UserTypeModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("UserType/SearchActiveUserTypes", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.UserTypeModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting UserTypeModel List");
            }
        }
    }
}