using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class Reporting
    {
        public DTO.LABURNUM.COM.FeeRepoting.CollectionSummary SearchCollectionSummary(DTO.LABURNUM.COM.FeeRepoting.FeeReportRequestModel model)
        {
            try
            {
                model.ApiClientModel = new Component.Common().GetApiClientModel();
                HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("FeeReports", "SearchCollectionSummary", model);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<DTO.LABURNUM.COM.FeeRepoting.CollectionSummary>(data);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DTO.LABURNUM.COM.AttendanceReporting.AttendanceSummaryReportModel SearchAttendanceSummaryReport(DTO.LABURNUM.COM.AttendanceReporting.AttendanceSummaryRequestModel model)
        {
            try
            {
                model.ApiClientModel = new Component.Common().GetApiClientModel();
                HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("AttendanceReports", "SearchAttendanceSummary", model);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<DTO.LABURNUM.COM.AttendanceReporting.AttendanceSummaryReportModel>(data);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}