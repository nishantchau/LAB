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
            this.AnnualFunctionFee = new double();
            this.MonthlyFee = new double();
            this.PendingFee = new double();
            this.Months = new List<MonthModel>();

        }

        public long StudentFeeDetailId { get; set; }
        public long StudentId { get; set; }
        public long ClassId { get; set; }
        public long SectionId { get; set; }
        public double MonthlyFee { get; set; }
        public double LateFee { get; set; }
        public Nullable<double> TransportFee { get; set; }
        public Nullable<double> AnnualFunctionFee { get; set; }
        public Nullable<double> PendingFee { get; set; }
        public int PayForTheMonth { get; set; }
        public double DiscountAmount { get; set; }
        public string DiscountRemarks { get; set; }
        public long CollectedById { get; set; }
        public long AcademicYearId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }



        public string MonthName { get; set; }
        public int AnnualFunctionFeePayableMonth { get; set; }
        public string AcademicYear { get; set; }
        public bool IsNewAdmission { get; set; }
        public double TotalPayableAmount { get; set; }
        public string CollectedByName { get; set; }
        public List<DTO.LABURNUM.COM.MonthModel> Months { get; set; }
        public DTO.LABURNUM.COM.ApiClientModel ApiClientModel { get; set; }

        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string ClassName { get; set; }
        public string SectionName { get; set; }
    }
}
