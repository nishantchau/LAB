﻿using System;
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

        public double TotalPaidAmount { get; set; }
        public List<DTO.LABURNUM.COM.StudentFeeDetailModel> MonthlyFeeDetails { get; set; }
    }
}
