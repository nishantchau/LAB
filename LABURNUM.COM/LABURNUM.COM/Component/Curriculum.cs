using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class Curriculum
    {
        public List<DTO.LABURNUM.COM.CurriculumModel> GetActiveCurriculums()
        {
            try
            {
                DTO.LABURNUM.COM.ClassModel model = new DTO.LABURNUM.COM.ClassModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Curriculum/SearchActiveCurriculums", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.CurriculumModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Curriculum List");
            }
        }

        public List<DTO.LABURNUM.COM.CurriculumModel> GetAllCurriculums()
        {
            try
            {
                DTO.LABURNUM.COM.CurriculumModel model = new DTO.LABURNUM.COM.CurriculumModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Curriculum/SearchAllCurriculums", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.CurriculumModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Curriculum List");
            }
        }

        public void UpdateCurriculumStatus(DTO.LABURNUM.COM.CurriculumModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Curriculum/UpdateStatus", model).Result;
                if (response.IsSuccessStatusCode)
                {

                }
                else { }
            }
            catch (Exception)
            {
                throw new Exception("Error While Updating Curriculum Status");
            }
        }

        public List<DTO.LABURNUM.COM.CurriculumModel> GetCurriculumByAdvanceSearch(DTO.LABURNUM.COM.CurriculumModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Curriculum/SearchCurriculumByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.CurriculumModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Admission Type Model List");
            }
        }

        public DTO.LABURNUM.COM.CurriculumModel GetCurriculumByCurriculumId(long id)
        {
            try
            {
                DTO.LABURNUM.COM.CurriculumModel model = new DTO.LABURNUM.COM.CurriculumModel() { CurriculumId = id };
                List<DTO.LABURNUM.COM.CurriculumModel> dbCurriculums = GetCurriculumByAdvanceSearch(model);
                if (dbCurriculums.Count == 0) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
                if (dbCurriculums.Count > 1) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
                return dbCurriculums[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool IsCurriculumPostForThisMonth(long classId, long monthId)
        {
            try
            {
                List<DTO.LABURNUM.COM.CurriculumModel> dbCurriculumList = GetCurriculumByAdvanceSearch(new DTO.LABURNUM.COM.CurriculumModel() { ClassId = classId, MonthId = monthId });
                if (dbCurriculumList.Count >= 1)
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

        public List<DTO.LABURNUM.COM.CurriculumModel> GetCurriculumForSite()
        {
            return GetCurriculumByAdvanceSearch(new DTO.LABURNUM.COM.CurriculumModel() { AcademicYearId = new Component.AcademicYear().GetAcademicYearIdByYear().AcademicYearTableId });
        }
    }
}