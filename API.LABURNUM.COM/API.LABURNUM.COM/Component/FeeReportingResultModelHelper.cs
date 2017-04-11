using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class FeeReportingResultModelHelper
    {
        public DTO.LABURNUM.COM.FeeReportingResultModel GetFeeReportingResultModel(API.LABURNUM.COM.StudentFee dbStudentFee)
        {
            DTO.LABURNUM.COM.FeeReportingResultModel model = new DTO.LABURNUM.COM.FeeReportingResultModel()
            {
                AcademicYearId = dbStudentFee.AcademicYearId,
                AcademicYear = dbStudentFee.AcademicYearTable.AcademicYear,
                AdmissionFee = dbStudentFee.AdmissionFee,
                AnnualCharges = dbStudentFee.AnnualCharges,
                DevelopementFee = dbStudentFee.DevelopementFee,
                ExamFee = dbStudentFee.ExamFee,
                SportsFee = dbStudentFee.SportsFee,
                SecurityFee = dbStudentFee.SecurityFee,
                DiscountAmount = dbStudentFee.DiscountAmount,
                ClassId = dbStudentFee.ClassId,
                ClassName = dbStudentFee.Class.ClassName,
                StudentId = dbStudentFee.StudentId,
                StudentName = dbStudentFee.Student.FirstName + " " + dbStudentFee.Student.MiddleName + " " + dbStudentFee.Student.LastName,
                SectionId = dbStudentFee.SectionId,
                SectionName = dbStudentFee.Section.SectionName
            };
            return model;
        }
    }
}