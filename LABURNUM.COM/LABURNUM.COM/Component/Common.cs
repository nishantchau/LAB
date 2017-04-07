using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace LABURNUM.COM.Component
{
    public class Common
    {
        public DTO.LABURNUM.COM.ApiClientModel GetApiClientModel()
        {
            DTO.LABURNUM.COM.ApiClientModel model = new DTO.LABURNUM.COM.ApiClientModel()
            {
                UserName = LABURNUM.COM.Component.Constants.APIACCESS.APIUSERNAME,
                Password = LABURNUM.COM.Component.Constants.APIACCESS.APIPASSWORD
            };
            return model;
        }

        public HttpClient GetHTTPClient(string contentType)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(LABURNUM.COM.Component.Constants.URL.WEBAPIURL);
                client.Timeout = TimeSpan.FromMinutes(LABURNUM.COM.Component.Constants.APIACCESS.HTTPTIME);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                return client;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetErrorView()
        {
            DTO.LABURNUM.COM.ClassModel model = new DTO.LABURNUM.COM.ClassModel();
            ControllerContext cont = new ControllerContext();
            string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(cont, "~/Views/Error404.cshtml", model);
            return html;
        }

        public HttpResponseMessage GetHTTPResponse(string controllerName, string actionMethod, object model)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(LABURNUM.COM.Component.Constants.URL.WEBAPIURL);
                client.Timeout = TimeSpan.FromMinutes(LABURNUM.COM.Component.Constants.APIACCESS.HTTPTIME);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync(controllerName + "/" + actionMethod, model).Result;
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}