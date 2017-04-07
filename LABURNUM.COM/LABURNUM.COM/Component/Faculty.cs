using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class Faculty
    {
        public List<DTO.LABURNUM.COM.FacultyModel> GetFacultyByAdvanceSearch(DTO.LABURNUM.COM.FacultyModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Faculty/SearchFacultyByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.FacultyModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Student List");
            }
        }

        public List<DTO.LABURNUM.COM.FacultyModel> GetAllFaculties()
        {
            try
            {
                DTO.LABURNUM.COM.FacultyModel model = new DTO.LABURNUM.COM.FacultyModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Faculty/SearchAllFaculties", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.FacultyModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Student List");
            }
        }

        public List<DTO.LABURNUM.COM.FacultyModel> GetActiveFaculties()
        {
            try
            {
                DTO.LABURNUM.COM.FacultyModel model = new DTO.LABURNUM.COM.FacultyModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Faculty/SearchActiveFaculties", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.FacultyModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Student List");
            }
        }

        public DTO.LABURNUM.COM.FacultyModel GetFacultyById(long facultyId)
        {
            try
            {
                DTO.LABURNUM.COM.FacultyModel model = new DTO.LABURNUM.COM.FacultyModel() { FacultyId = facultyId };
                List<DTO.LABURNUM.COM.FacultyModel> dbFaculties = GetFacultyByAdvanceSearch(model);
                if (dbFaculties.Count == 0) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
                if (dbFaculties.Count > 1) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
                return dbFaculties[0];
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Fee List");
            }
        }

        public bool UpdateFacultyStatus(DTO.LABURNUM.COM.FacultyModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Faculty/Update", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}