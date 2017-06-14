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

        public bool IsAlreadyPaidForThisMonth(long month, long studentId, long classId, long sectionId)
        {
            try
            {
                List<DTO.LABURNUM.COM.StudentFeeDetailModel> dbstudentFeeDetailsList = GetStudentFeeDetailByAdvanceSearch(new DTO.LABURNUM.COM.StudentFeeDetailModel() { StudentId = studentId, ClassId = classId, SectionId = sectionId, PayForTheMonth = month });
                if (dbstudentFeeDetailsList.Count >= 1)
                {
                    if (dbstudentFeeDetailsList[0].MonthlyFee > 0)
                    {
                        return true;
                    }
                    else
                    { return false; }
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DTO.LABURNUM.COM.StudentFeeDetailModel GetPendingFee(long studentId, long classId, long sectionId, long academicYear)
        {
            try
            {
                DTO.LABURNUM.COM.StudentFeeDetailModel model = new DTO.LABURNUM.COM.StudentFeeDetailModel() { AcademicYearId = academicYear, StudentId = studentId, ClassId = classId, SectionId = sectionId };
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("StudentFeeDetail", "SearchPendingFee", model);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    DTO.LABURNUM.COM.StudentFeeDetailModel dbStudentFeeDetail = JsonConvert.DeserializeObject<DTO.LABURNUM.COM.StudentFeeDetailModel>(data);
                    return dbStudentFeeDetail;
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

        public DTO.LABURNUM.COM.StudentFeeDetailModel GetFeePaidDetailDuringAdmission(long studentId, long classId, long sectionId, long academicYear)
        {
            try
            {
                List<DTO.LABURNUM.COM.StudentFeeDetailModel> model = GetStudentFeeDetailByAdvanceSearch(new DTO.LABURNUM.COM.StudentFeeDetailModel() { AcademicYearId = academicYear, StudentId = studentId, ClassId = classId, SectionId = sectionId });
                List<DTO.LABURNUM.COM.StudentFeeDetailModel> dblist = model.Where(x => x.MonthlyFee == 0).ToList();
                if (dblist.Count == 0) { }
                return dblist[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DTO.LABURNUM.COM.StudentFeeDetailModel GetFeePaidDetailDuringMonthlyFeePayment(long studentId, long classId, long sectionId, long academicYear)
        {
            try
            {
                List<DTO.LABURNUM.COM.StudentFeeDetailModel> model = GetStudentFeeDetailByAdvanceSearch(new DTO.LABURNUM.COM.StudentFeeDetailModel() { AcademicYearId = academicYear, StudentId = studentId, ClassId = classId, SectionId = sectionId });
                List<DTO.LABURNUM.COM.StudentFeeDetailModel> dblist = model.ToList();
                if (dblist.Count == 0) { }
                return dblist[1];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DTO.LABURNUM.COM.StudentFeeDetailModel GetMonthlyFeeReceiptData(long studentFeeDetailsId)
        {
            try
            {
                DTO.LABURNUM.COM.StudentFeeDetailModel model = new DTO.LABURNUM.COM.StudentFeeDetailModel() { StudentFeeDetailId = studentFeeDetailsId };
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("StudentFeeDetail", "SearchMonthlyFeeReceiptData", model);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    DTO.LABURNUM.COM.StudentFeeDetailModel dbStudentFeeDetails = JsonConvert.DeserializeObject<DTO.LABURNUM.COM.StudentFeeDetailModel>(data);
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

        public bool UpdateChequeStatus(long studentFeeDetailId, long chequeStatusId, string remarks)
        {
            try
            {
                DTO.LABURNUM.COM.StudentFeeDetailModel model = new DTO.LABURNUM.COM.StudentFeeDetailModel() { StudentFeeDetailId = studentFeeDetailId, ChequeStatus = chequeStatusId, ChequeBounceRemarks = remarks };
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("StudentFeeDetail", "UpdateChequeStatus", model);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return Convert.ToBoolean(data);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsAlreadyAdmissionDone(long studentId, long classId, long sectionId)
        {
            try
            {

                List<DTO.LABURNUM.COM.StudentFeeDetailModel> dbstudentFeeDetailsList = GetStudentFeeDetailByAdvanceSearch(new DTO.LABURNUM.COM.StudentFeeDetailModel() { StudentId = studentId, ClassId = classId }).Where(x => x.MonthlyFee == 0).ToList();
                if (dbstudentFeeDetailsList.Count >= 1)
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

        public List<DTO.LABURNUM.COM.StudentFeeDetailModel> GetPendingFeeByAdmissionNumberandAcademicYear(string admissionNumber, long academicYear)
        {
            try
            {
                DTO.LABURNUM.COM.StudentModel model = new DTO.LABURNUM.COM.StudentModel() { AcademicYearId = academicYear, AdmissionNumber = admissionNumber };
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("StudentFeeDetail", "SearchPendingFeeByStudentModel", model);
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

        public DTO.LABURNUM.COM.StudentFeeDetailModel GetPendingFeeReceiptData(long studentFeeDetailsId)
        {
            try
            {
                DTO.LABURNUM.COM.StudentFeeDetailModel model = new DTO.LABURNUM.COM.StudentFeeDetailModel() { StudentFeeDetailId = studentFeeDetailsId };
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("StudentFeeDetail", "SearchPendingFeeReceiptData", model);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    DTO.LABURNUM.COM.StudentFeeDetailModel dbStudentFeeDetails = JsonConvert.DeserializeObject<DTO.LABURNUM.COM.StudentFeeDetailModel>(data);
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

    }
}
