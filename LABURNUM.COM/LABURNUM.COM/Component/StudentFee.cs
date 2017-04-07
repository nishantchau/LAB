using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace LABURNUM.COM.Component
{
    public class StudentFee
    {
        public List<DTO.LABURNUM.COM.StudentFeeModel> GetStudentFeeByAdvanceSearch(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("StudentFee", "SearchStudentFeeByAdvanceSearch", model);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    List<DTO.LABURNUM.COM.StudentFeeModel> dbStudentFees = JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.StudentFeeModel>>(data);
                    return dbStudentFees;
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

        public DTO.LABURNUM.COM.StudentFeeModel GetStudentFeeByStudentFeeId(long studentFeeId)
        {
            try
            {
                DTO.LABURNUM.COM.StudentFeeModel model = new DTO.LABURNUM.COM.StudentFeeModel() { StudentFeeId = studentFeeId };
                List<DTO.LABURNUM.COM.StudentFeeModel> dbStudentFees = GetStudentFeeByAdvanceSearch(model);
                if (dbStudentFees.Count == 0) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
                if (dbStudentFees.Count > 1) { throw new Exception(LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
                return dbStudentFees[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}