using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class StudentFeeModel
    {
        public StudentFeeModel()
        {
            this.ApiClientModel = new ApiClientModel();
            //this.StudentFeeDetailModel = new StudentFeeDetailModel();
            this.StudentFeeDetails = new List<StudentFeeDetailModel>();
            this.Sections = new List<SectionModel>();
            this.Banks = new List<BankModel>();

        }

        public long StudentFeeId { get; set; }
        public long StudentId { get; set; }
        public long ClassId { get; set; }
        public long SectionId { get; set; }
        public long AdmissionTypeId { get; set; }
        public double AdmissionFee { get; set; }
        public double DevelopementFee { get; set; }
        public double AnnualCharges { get; set; }
        public double ExamFee { get; set; }
        public double SportsFee { get; set; }
        public double SecurityFee { get; set; }
        public Nullable<double> AnnualFunctionFee { get; set; }
        public double DiscountAmount { get; set; }
        public string DiscountRemarks { get; set; }
        public long CollectedById { get; set; }
        public long AcademicYearId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }



        public bool IsNewAdmission { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string SectionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AcademicYear { get; set; }
        public double TotalEarningFromAdmission { get; set; }
        public double TotalEarningFromMonthlyFee { get; set; }
        public double TotalEarning { get; set; }

        public double TotalPayableAmount { get; set; }
        public double PaidMonthlyFee { get; set; }
        public double PendingFee { get; set; }
        public string CollectedByName { get; set; }
        public string ParentName { get; set; }
        public double CashPaidAmount { get; set; }
        public double ChequePaidAmount { get; set; }
        public string ChequeNumber { get; set; }
        public long BankId { get; set; }
        public Nullable<System.DateTime> ChequeDate { get; set; }
        public Nullable<long> ChequeStatus { get; set; }


        public DTO.LABURNUM.COM.ApiClientModel ApiClientModel { get; set; }
        public List<DTO.LABURNUM.COM.ClassModel> Classes { get; set; }
        public List<DTO.LABURNUM.COM.SectionModel> Sections { get; set; }
        public List<DTO.LABURNUM.COM.BankModel> Banks { get; set; }
        public List<DTO.LABURNUM.COM.StudentFeeDetailModel> StudentFeeDetails { get; set; }

        public string StudentAdmissionNumber { get; set; }
    }
}
