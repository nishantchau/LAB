using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class AcademicYear
    {
        public List<DTO.LABURNUM.COM.AcademicYearTableModel> GetActiveAcademicYears()
        {
            try
            {
                DTO.LABURNUM.COM.AcademicYearTableModel model = new DTO.LABURNUM.COM.AcademicYearTableModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("AcademicYear/SearchActiveAcademicYears", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.AcademicYearTableModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Academic Year Table Model List");
            }
        }

        public List<DTO.LABURNUM.COM.AcademicYearTableModel> GetAllAdmissionTypes()
        {
            try
            {
                DTO.LABURNUM.COM.AcademicYearTableModel model = new DTO.LABURNUM.COM.AcademicYearTableModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("AcademicYear/SearchAllAcademicYears", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.AcademicYearTableModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Academic Year Table Model List");
            }
        }

        public void UpdateClasseStatus(DTO.LABURNUM.COM.AcademicYearTableModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("AcademicYear/UpdateStatus", model).Result;
                if (response.IsSuccessStatusCode)
                {

                }
                else { }
            }
            catch (Exception)
            {
                throw new Exception("Error While Updating Academic Year Status");
            }
        }

        public List<DTO.LABURNUM.COM.AcademicYearTableModel> GetAcademicYearByAdvanceSearch(DTO.LABURNUM.COM.AcademicYearTableModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("AcademicYear/SearchAcademicYearByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.AcademicYearTableModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Admission Type Model List");
            }
        }

        public DTO.LABURNUM.COM.AcademicYearTableModel GetAcademicYearByAcademicYearId(long id)
        {
            try
            {
                DTO.LABURNUM.COM.AcademicYearTableModel model = new DTO.LABURNUM.COM.AcademicYearTableModel() { AcademicYearTableId = id };
                List<DTO.LABURNUM.COM.AcademicYearTableModel> dbAdmissionTypes = GetAcademicYearByAdvanceSearch(model);
                if (dbAdmissionTypes.Count == 0) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
                if (dbAdmissionTypes.Count > 1) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
                return dbAdmissionTypes[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DTO.LABURNUM.COM.AcademicYearTableModel GetAcademicYearIdByYear()
        {
            try
            {
                DTO.LABURNUM.COM.AcademicYearTableModel model = new DTO.LABURNUM.COM.AcademicYearTableModel() { Year = System.DateTime.Now.Year };
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("AcademicYear/SearchAcademicYearByYear", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<DTO.LABURNUM.COM.AcademicYearTableModel>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Admission Type Model.");
            }
        }

    }
}