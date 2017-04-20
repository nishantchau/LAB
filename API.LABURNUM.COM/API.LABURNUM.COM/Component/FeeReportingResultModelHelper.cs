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
                SectionName = dbStudentFee.Section.SectionName,
                TotalPaidOnAdmission = (dbStudentFee.AdmissionFee + dbStudentFee.AnnualCharges + dbStudentFee.ExamFee + dbStudentFee.SportsFee + dbStudentFee.SecurityFee) - dbStudentFee.DiscountAmount,
            };
            return model;
        }

        public List<DTO.LABURNUM.COM.FeeReportingResultModel> GetFeeReportingResultModel(API.LABURNUM.COM.StudentFee dbStudentFee, List<API.LABURNUM.COM.StudentFeeDetail> dblist)
        {
            int counter = 1;
            List<DTO.LABURNUM.COM.FeeReportingResultModel> dbFRList = new List<DTO.LABURNUM.COM.FeeReportingResultModel>();
            DTO.LABURNUM.COM.FeeReportingResultModel model = new DTO.LABURNUM.COM.FeeReportingResultModel();
            foreach (API.LABURNUM.COM.StudentFeeDetail item in dblist)
            {
                if (item.PayForTheMonth == dbStudentFee.CreatedOn.Month)
                {
                    model.AdmissionFee = dbStudentFee.AdmissionFee;
                    model.AnnualCharges = dbStudentFee.AnnualCharges;
                    model.DevelopementFee = dbStudentFee.DevelopementFee;
                    model.ExamFee = dbStudentFee.ExamFee;
                    model.SportsFee = dbStudentFee.SportsFee;
                    model.SecurityFee = dbStudentFee.SecurityFee;
                    model.DiscountAmount = dbStudentFee.DiscountAmount;
                    model.MonthlyFee = item.MonthlyFee;
                    model.LateFee = item.LateFee;
                    model.TransportFee = item.TransportFee;
                    model.PendingFee = item.PendingFee;
                    model.AnnualFunctionFee = item.AnnualFunctionFee;
                    model.MonthDiscountAmount = item.DiscountAmount;
                    model.MonthName = item.Month.MonthName;
                    model.StudentName = dbStudentFee.Student.FirstName + " " + dbStudentFee.Student.MiddleName + " " + dbStudentFee.Student.LastName;
                    model.ClassName = dbStudentFee.Class.ClassName;
                    model.SectionName = dbStudentFee.Section.SectionName;
                }
                else
                {
                    model.MonthlyFee = item.MonthlyFee;
                    model.LateFee = item.LateFee;
                    model.TransportFee = item.TransportFee;
                    model.PendingFee = item.PendingFee;
                    model.AnnualFunctionFee = item.AnnualFunctionFee;
                    model.MonthDiscountAmount = item.DiscountAmount;
                    model.MonthName = item.Month.MonthName;
                    model.StudentName = dbStudentFee.Student.FirstName + " " + dbStudentFee.Student.MiddleName + " " + dbStudentFee.Student.LastName;
                    model.ClassName = dbStudentFee.Class.ClassName;
                    model.SectionName = dbStudentFee.Section.SectionName;
                }
                dbFRList.Add(model);
            }
            return dbFRList;
        }
    }
}