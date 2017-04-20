using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class FeeReportingResultModel
    {
        public FeeReportingResultModel()
        {
            this.MonthlyFeeDetails = new List<StudentFeeDetailModel>();
        }
        public long StudentId { get; set; }
        public long SectionId { get; set; }
        public long ClassId { get; set; }
        public long AcademicYearId { get; set; }

        public string StudentName { get; set; }
        public string SectionName { get; set; }
        public string ClassName { get; set; }
        public string AcademicYear { get; set; }

        public double AdmissionFee { get; set; }
        public double DevelopementFee { get; set; }
        public double AnnualCharges { get; set; }
        public double ExamFee { get; set; }
        public double SportsFee { get; set; }
        public double SecurityFee { get; set; }
        public double DiscountAmount { get; set; }

        public string MonthName { get; set; }

        public double TotalPaidAmount { get; set; }
        public double TotalPaidOnAdmission { get; set; }
        public double TotalPaidOnMonthly { get; set; }
        public List<DTO.LABURNUM.COM.StudentFeeDetailModel> MonthlyFeeDetails { get; set; }

        public double MonthlyFee { get; set; }
        public double LateFee { get; set; }
        public Nullable<double> TransportFee { get; set; }
        public Nullable<double> AnnualFunctionFee { get; set; }
        public Nullable<double> PendingFee { get; set; }
        public int PayForTheMonth { get; set; }
        public double MonthDiscountAmount { get; set; }
    }
}
