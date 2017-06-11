using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class StudentFeeHelper
    {

        private List<API.LABURNUM.COM.StudentFee> StudentFees;

        public StudentFeeHelper()
        {
            this.StudentFees = new List<API.LABURNUM.COM.StudentFee>();
        }

        public StudentFeeHelper(List<API.LABURNUM.COM.StudentFee> studentFees)
        {
            if (studentFees == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.StudentFees = studentFees;
        }

        public StudentFeeHelper(API.LABURNUM.COM.StudentFee studentFee)
        {
            if (studentFee == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.StudentFees = new List<API.LABURNUM.COM.StudentFee>();
            this.StudentFees.Add(studentFee);
        }

        public List<DTO.LABURNUM.COM.StudentFeeModel> Map()
        {
            if (this.StudentFees == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.StudentFeeModel> dtoStudentFee = new List<DTO.LABURNUM.COM.StudentFeeModel>();
            foreach (API.LABURNUM.COM.StudentFee item in this.StudentFees)
            {
                dtoStudentFee.Add(MapCore(item));
            }
            return dtoStudentFee;
        }

        public DTO.LABURNUM.COM.StudentFeeModel MapSingle()
        {
            if (this.StudentFees == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.StudentFees.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.StudentFees[0]);
        }

        private DTO.LABURNUM.COM.StudentFeeModel MapCore(API.LABURNUM.COM.StudentFee studentFee)
        {

            DTO.LABURNUM.COM.StudentFeeModel dtoStudentFee = new DTO.LABURNUM.COM.StudentFeeModel()
            {
                StudentFeeId = studentFee.StudentFeeId,
                ClassId = studentFee.ClassId,
                AdmissionTypeId = studentFee.AdmissionTypeId,
                AdmissionFee = studentFee.AdmissionFee,
                DevelopementFee = studentFee.DevelopementFee,
                AnnualCharges = studentFee.AnnualCharges,
                ExamFee = studentFee.ExamFee,
                SportsFee = studentFee.SportsFee,
                SecurityFee = studentFee.SecurityFee,
                StudentId = studentFee.StudentId,
                AnnualFunctionFee = studentFee.AnnualFunctionFee,
                CollectedById = studentFee.CollectedById,
                SectionId = studentFee.SectionId,
                CreatedOn = studentFee.CreatedOn,
                IsActive = studentFee.IsActive,
                LastUpdated = studentFee.LastUpdated,
                AcademicYearId = studentFee.AcademicYearId,
                ClassName = studentFee.Class.ClassName,
                StudentName = studentFee.Student.FirstName + " " + studentFee.Student.MiddleName + " " + studentFee.Student.LastName,
                SectionName = studentFee.Section.SectionName,
                DiscountAmount = studentFee.DiscountAmount,
                DiscountRemarks = studentFee.DiscountRemarks,
                TotalPayableAmount = (studentFee.AdmissionFee + studentFee.DevelopementFee + studentFee.AnnualCharges + studentFee.ExamFee + studentFee.SportsFee + studentFee.SecurityFee + studentFee.AnnualFunctionFee.GetValueOrDefault()) - studentFee.DiscountAmount,
                CollectedByName = studentFee.Faculty.FacultyName,
                ParentName = studentFee.Student.FatherName,
                AcademicYear = studentFee.AcademicYearTable.StartYear + "-" + studentFee.AcademicYearTable.EndYear,
                StudentAdmissionNumber = studentFee.Student.AdmissionNumber,
            };
            return dtoStudentFee;
        }
    }
}