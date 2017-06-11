using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class StudentFeeDetailModel
    {
        public StudentFeeDetailModel()
        {
            this.ApiClientModel = new ApiClientModel();
            this.LateFee = new double();
            this.TransportFee = new double();
            //this.AnnualFunctionFee = new double();
            this.MonthlyFee = new double();
            this.PendingFee = new double();
            this.Months = new List<MonthModel>();
            this.Banks = new List<BankModel>();
            this.ChequeStatusMasters = new List<ChequeStatusMasterModel>();
        }

        public long StudentFeeDetailId { get; set; }
        public long StudentId { get; set; }
        public long ClassId { get; set; }
        public long SectionId { get; set; }
        public double MonthlyFee { get; set; }
        public double LateFee { get; set; }
        public Nullable<double> TransportFee { get; set; }
        //public Nullable<double> AnnualFunctionFee { get; set; }
        public Nullable<double> PendingFee { get; set; }
        public long? PayForTheMonth { get; set; }
        public double DiscountAmount { get; set; }
        public string DiscountRemarks { get; set; }
        public long CollectedById { get; set; }
        public long AcademicYearId { get; set; }
        public double CashPaidAmount { get; set; }
        public double ChequePaidAmount { get; set; }
        public string ChequeNumber { get; set; }
        public string ChequeBankName { get; set; }
        public long BankId { get; set; }
        public Nullable<System.DateTime> ChequeDate { get; set; }
        public Nullable<long> ChequeStatus { get; set; }
        public string ChequeBounceRemarks { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public double LastPendingFee { get; set; }
        public double BounceChequeAmount { get; set; }
        public string BounceChequeNumber { get; set; }
        public string BounceChequeBankName { get; set; }
        public DateTime BounceChequeDate { get; set; }
        public string ChequeStatusName { get; set; }
        public int BounceChequePanelty { get; set; }


        public string MonthName { get; set; }
        public int AnnualFunctionFeePayableMonth { get; set; }
        public string AcademicYear { get; set; }
        public bool IsNewAdmission { get; set; }
        public double TotalPayableAmount { get; set; }
        public string CollectedByName { get; set; }
        public List<DTO.LABURNUM.COM.MonthModel> Months { get; set; }
        public List<DTO.LABURNUM.COM.BankModel> Banks { get; set; }
        public DTO.LABURNUM.COM.ApiClientModel ApiClientModel { get; set; }
        public List<DTO.LABURNUM.COM.ChequeStatusMasterModel> ChequeStatusMasters { get; set; }

        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string ClassName { get; set; }
        public string SectionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ChequeSearchEndDate { get; set; }

        public string PUN { get; set; }
        public string PUP { get; set; }

        public string SUN { get; set; }
        public string SUP { get; set; }

        public string StudentAdmissionNumber { get; set; }

        public double TotalCashPaidAmount { get; set; }
        public double TotalChequePaidAmount { get; set; }
        public double TotalEarning { get; set; }
        public double TotalDiscountAmount { get; set; }
    }
}
