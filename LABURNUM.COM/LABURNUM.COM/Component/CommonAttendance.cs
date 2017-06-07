using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class CommonAttendance
    {
        public List<DTO.LABURNUM.COM.CommonAttendanceModel> GetStudentListForAttendance(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("CommonAttendance/SearchStudentListForAttendance", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.CommonAttendanceModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Student List");
            }
        }

        public List<DTO.LABURNUM.COM.CommonAttendanceModel> GetAttendanceByAdvanceSearch(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("CommonAttendance/SearchAttendanceByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.CommonAttendanceModel>>(data);
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                throw new Exception("Error While Getting Student List");
            }
        }

        public bool IsAttendanceSubmittedForToday(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            model.StartDate = new Component.Utility().GetISTDateTime();
            List<DTO.LABURNUM.COM.CommonAttendanceModel> dbList = GetAttendanceByAdvanceSearch(model);
            if (dbList.Count == 0) { return false; }
            else { return true; }
        }

        public bool IsAttendanceSubmittedAfterLunchForToday(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            model.StartDate = new Component.Utility().GetISTDateTime();
            List<DTO.LABURNUM.COM.CommonAttendanceModel> dbList = GetAttendanceByAdvanceSearch(model).Where(x=>x.LunchAttendanceDate.GetValueOrDefault().Year!=0001).ToList();
            if (dbList.Count == 0) { return false; }
            else { return true; }
        }

        public DTO.LABURNUM.COM.AttendanceReporting.AttendanceReportResponseModel GetAttendanceReport(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("CommonAttendance/SearchAttendanceReport", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<DTO.LABURNUM.COM.AttendanceReporting.AttendanceReportResponseModel>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Student List");
            }
        }
    }
}