using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class ClassSubjectFacultyTable
    {
        public List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel> GetActiveClassSubjectFaculties()
        {
            try
            {
                DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model = new DTO.LABURNUM.COM.ClassSubjectFacultyTableModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("ClassSubjectFacultyTable/SearchActiveClassSubjectFaculties", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Class Subject Faculty Table Model List");
            }
        }

        public List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel> GetAllClassSubjectFaculties()
        {
            try
            {
                DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model = new DTO.LABURNUM.COM.ClassSubjectFacultyTableModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("ClassSubjectFacultyTable/SearchAllClassSubjectFaculties", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Class Subject Faculty Table Model List");
            }
        }

        public void UpdateClassSubjectFacultyStatus(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("ClassSubjectFacultyTable/UpdateStatus", model).Result;
                if (response.IsSuccessStatusCode)
                {

                }
                else { }
            }
            catch (Exception)
            {
                throw new Exception("Error While Updating Class Subject Faculty Table Status");
            }
        }

        public List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel> GetClassSubjectFacultyByAdvanceSearch(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("ClassSubjectFacultyTable/SearchClassSubjectFacultyByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Class Subject Faculty Table Model List");
            }
        }

        public DTO.LABURNUM.COM.ClassSubjectFacultyTableModel GetClassSubjectFacultyById(long id)
        {
            try
            {
                DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model = new DTO.LABURNUM.COM.ClassSubjectFacultyTableModel() { ClassSubjectFacultyTableId = id };
                List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel> dbAdmissionTypes = GetClassSubjectFacultyByAdvanceSearch(model);
                if (dbAdmissionTypes.Count == 0) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
                if (dbAdmissionTypes.Count > 1) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
                return dbAdmissionTypes[0];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}