using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class StudentFeeDetails
    {


        public List<DTO.LABURNUM.COM.StudentFeeDetailModel> GetStudentFeeDetailByAdvanceSearch(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("StudentFeeDetail", "SearchStudentFeeDetailByAdvanceSearch", model);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    List<DTO.LABURNUM.COM.StudentFeeDetailModel> dbStudentFeeDetails = JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.StudentFeeDetailModel>>(data);
                    return dbStudentFeeDetails;
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

        public DTO.LABURNUM.COM.StudentFeeDetailModel GetStudentFeeDetailsById(long id)
        {
            try
            {
                DTO.LABURNUM.COM.StudentFeeDetailModel model = new DTO.LABURNUM.COM.StudentFeeDetailModel() { StudentFeeDetailId = id };
                List<DTO.LABURNUM.COM.StudentFeeDetailModel> dbStudentFeeDetails = GetStudentFeeDetailByAdvanceSearch(model);
                if (dbStudentFeeDetails.Count == 0) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
                if (dbStudentFeeDetails.Count > 1) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
                return dbStudentFeeDetails[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool IsAlreadyPaidForThisMonth(int month, long studentId, long classId, long sectionId)
        {
            try
            {
                List<DTO.LABURNUM.COM.StudentFeeDetailModel> dbstudentFeeDetailsList = GetStudentFeeDetailByAdvanceSearch(new DTO.LABURNUM.COM.StudentFeeDetailModel() { StudentId = studentId, ClassId = classId, SectionId = sectionId, PayForTheMonth = month });
                if (dbstudentFeeDetailsList.Count >= 1) { return true; }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}