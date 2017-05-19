using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class StudentFeeDetailHelper
    {
        private List<API.LABURNUM.COM.StudentFeeDetail> StudentFeeDetails;

        public StudentFeeDetailHelper()
        {
            this.StudentFeeDetails = new List<API.LABURNUM.COM.StudentFeeDetail>();
        }

        public StudentFeeDetailHelper(List<API.LABURNUM.COM.StudentFeeDetail> studentFeeDetails)
        {
            if (studentFeeDetails == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.StudentFeeDetails = studentFeeDetails;
        }

        public StudentFeeDetailHelper(API.LABURNUM.COM.StudentFeeDetail studentFeeDetail)
        {
            if (studentFeeDetail == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.StudentFeeDetails = new List<API.LABURNUM.COM.StudentFeeDetail>();
            this.StudentFeeDetails.Add(studentFeeDetail);
        }

        public List<DTO.LABURNUM.COM.StudentFeeDetailModel> Map()
        {
            if (this.StudentFeeDetails == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.StudentFeeDetailModel> dtoStudentFeeDetails = new List<DTO.LABURNUM.COM.StudentFeeDetailModel>();
            foreach (API.LABURNUM.COM.StudentFeeDetail item in this.StudentFeeDetails)
            {
                dtoStudentFeeDetails.Add(MapCore(item));
            }
            return dtoStudentFeeDetails;
        }

        public DTO.LABURNUM.COM.StudentFeeDetailModel MapSingle()
        {
            if (this.StudentFeeDetails == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.StudentFeeDetails.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.StudentFeeDetails[0]);
        }

        private DTO.LABURNUM.COM.StudentFeeDetailModel MapCore(API.LABURNUM.COM.StudentFeeDetail studentFeeDetail)
        {

            DTO.LABURNUM.COM.StudentFeeDetailModel dtoStudentFeeDetail = new DTO.LABURNUM.COM.StudentFeeDetailModel()
            {
                StudentId = studentFeeDetail.StudentId,
                StudentFeeDetailId = studentFeeDetail.StudentFeeDetailId,
                MonthlyFee = studentFeeDetail.MonthlyFee,
                LateFee = studentFeeDetail.LateFee,
                TransportFee = studentFeeDetail.TransportFee,
                //AnnualFunctionFee = studentFeeDetail.AnnualFunctionFee,
                ChequeBankName = studentFeeDetail.Bank.BankName,
                BankId = studentFeeDetail.BankId,
                CashPaidAmount = studentFeeDetail.CashPaidAmount.GetValueOrDefault(),
                ChequeNumber = studentFeeDetail.ChequeNumber,
                ChequeStatus = studentFeeDetail.ChequeStatus,
                ChequeDate = studentFeeDetail.ChequeDate,
                ChequePaidAmount = studentFeeDetail.ChequePaidAmount.GetValueOrDefault(),
                CollectedById = studentFeeDetail.CollectedById,
                ClassId = studentFeeDetail.ClassId,
                SectionId = studentFeeDetail.SectionId,
                PendingFee = studentFeeDetail.PendingFee,
                DiscountAmount = studentFeeDetail.DiscountAmount,
                DiscountRemarks = studentFeeDetail.DiscountRemarks,
                CreatedOn = studentFeeDetail.CreatedOn,
                IsActive = studentFeeDetail.IsActive,
                LastUpdated = studentFeeDetail.LastUpdated,
                CollectedByName = studentFeeDetail.Faculty.FacultyName,
                MonthName = studentFeeDetail.Month.MonthName,
                FatherName = studentFeeDetail.Student.FatherName,
                StudentName = studentFeeDetail.Student.FirstName + " " + studentFeeDetail.Student.MiddleName + " " + studentFeeDetail.Student.LastName,
                ClassName = studentFeeDetail.Class.ClassName,
                SectionName = studentFeeDetail.Section.SectionName,
                TotalPayableAmount = (studentFeeDetail.MonthlyFee + studentFeeDetail.LateFee + studentFeeDetail.TransportFee.GetValueOrDefault()) - studentFeeDetail.DiscountAmount,
                AcademicYearId = studentFeeDetail.AcademicYearId,
                AcademicYear = studentFeeDetail.AcademicYearTable.StartYear + "-" + studentFeeDetail.AcademicYearTable.EndYear,
                ChequeBounceRemarks = studentFeeDetail.ChequeBounceRemarks

            };
            if (studentFeeDetail.ChequeStatusMaster != null)
            {
                dtoStudentFeeDetail.ChequeStatusName = studentFeeDetail.ChequeStatusMaster.TextToDisplay;
            }
            return dtoStudentFeeDetail;
        }
    }
}