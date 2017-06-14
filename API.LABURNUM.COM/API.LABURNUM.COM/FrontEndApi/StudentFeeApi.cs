using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;
using System.Globalization;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class StudentFeeApi
    {
        private LaburnumEntities _laburnum;

        public StudentFeeApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddStudentFee(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            API.LABURNUM.COM.StudentFee apiStudentFee = new StudentFee()
            {
                StudentId = model.StudentId,
                AdmissionTypeId = model.AdmissionTypeId,
                ClassId = model.ClassId,
                SectionId = model.SectionId,
                AdmissionFee = model.AdmissionFee,
                AnnualCharges = model.AnnualCharges,
                DevelopementFee = model.DevelopementFee,
                ExamFee = model.ExamFee,
                SecurityFee = model.SecurityFee,
                SportsFee = model.SportsFee,
                AnnualFunctionFee = model.AnnualFunctionFee,
                DiscountAmount = model.DiscountAmount,
                DiscountRemarks = model.DiscountRemarks,
                CollectedById = model.CollectedById,
                CreatedOn = new Component.Utility().GetISTDateTime(),
                AcademicYearId = model.AcademicYearId,
                IsActive = true,
            };
            this._laburnum.StudentFees.Add(apiStudentFee);
            this._laburnum.SaveChanges();

            return apiStudentFee.StudentFeeId;
        }

        private long AddValidation(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            model.TryValidate();
            return AddStudentFee(model);
        }

        public long Add(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            model.StudentFeeId.TryValidate();
            IQueryable<API.LABURNUM.COM.StudentFee> iQuery = this._laburnum.StudentFees.Where(x => x.StudentFeeId == model.StudentFeeId && x.IsActive == true);
            List<API.LABURNUM.COM.StudentFee> dbStudentFees = iQuery.ToList();
            if (dbStudentFees.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbStudentFees.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbStudentFees[0].ClassId = model.ClassId;
            dbStudentFees[0].AdmissionTypeId = model.AdmissionTypeId;
            dbStudentFees[0].StudentId = model.StudentId;
            dbStudentFees[0].SectionId = model.SectionId;
            dbStudentFees[0].AdmissionFee = model.AdmissionFee;
            dbStudentFees[0].AnnualCharges = model.AnnualCharges;
            dbStudentFees[0].DevelopementFee = model.DevelopementFee;
            dbStudentFees[0].ExamFee = model.ExamFee;
            dbStudentFees[0].SecurityFee = model.SecurityFee;
            dbStudentFees[0].SportsFee = model.SportsFee;
            dbStudentFees[0].AnnualFunctionFee = model.AnnualFunctionFee;
            dbStudentFees[0].DiscountAmount = model.DiscountAmount;
            dbStudentFees[0].DiscountRemarks = model.DiscountRemarks;
            dbStudentFees[0].CollectedById = model.CollectedById;
            dbStudentFees[0].LastUpdated = new Component.Utility().GetISTDateTime();
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            model.StudentFeeId.TryValidate();
            IQueryable<API.LABURNUM.COM.StudentFee> iQuery = this._laburnum.StudentFees.Where(x => x.StudentFeeId == model.StudentFeeId && x.IsActive == true);
            List<API.LABURNUM.COM.StudentFee> dbStudentFees = iQuery.ToList();
            if (dbStudentFees.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbStudentFees.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbStudentFees[0].IsActive = model.IsActive;
            dbStudentFees[0].LastUpdated = new Component.Utility().GetISTDateTime();
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.StudentFee> GetStudentFeeByAdvanceSearch(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            IQueryable<API.LABURNUM.COM.StudentFee> iQuery = null;
            //Search By Academic Year Id.
            if (iQuery != null) { if (model.AcademicYearId > 0) { iQuery = iQuery.Where(x => x.AcademicYearId == model.AcademicYearId && x.IsActive == true); } }
            else { if (model.AcademicYearId > 0) { iQuery = this._laburnum.StudentFees.Where(x => x.AcademicYearId == model.AcademicYearId && x.IsActive == true); } }
            //Search By Student Fee Id.
            if (iQuery != null) { if (model.StudentFeeId > 0) { iQuery = iQuery.Where(x => x.StudentFeeId == model.StudentFeeId && x.IsActive == true); } }
            else { if (model.StudentFeeId > 0) { iQuery = this._laburnum.StudentFees.Where(x => x.StudentFeeId == model.StudentFeeId && x.IsActive == true); } }
            //Search By Admission Type Id.
            if (iQuery != null) { if (model.AdmissionTypeId > 0) { iQuery = iQuery.Where(x => x.AdmissionTypeId == model.AdmissionTypeId && x.IsActive == true); } }
            else { if (model.AdmissionTypeId > 0) { iQuery = this._laburnum.StudentFees.Where(x => x.AdmissionTypeId == model.AdmissionTypeId && x.IsActive == true); } }
            //Search By Student Id.
            if (iQuery != null) { if (model.StudentId > 0) { iQuery = iQuery.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            else { if (model.StudentId > 0) { iQuery = this._laburnum.StudentFees.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            //Search By Class Id.
            if (iQuery != null) { if (model.ClassId > 0) { iQuery = iQuery.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            else { if (model.ClassId > 0) { iQuery = this._laburnum.StudentFees.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.StudentFees.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Date Range.
            if (iQuery != null)
            {
                if (model.StartDate.Year != 0001)
                {
                    model.StartDate = new Component.Utility().GetDate(model.StartDate);
                    if (model.EndDate.Year != 0001) { model.EndDate = new Component.Utility().GetDate(model.EndDate).AddDays(1).AddSeconds(-1); }
                    if (model.EndDate.Year == 0001) { model.EndDate = model.StartDate.AddDays(1).AddSeconds(-1); }
                    iQuery = iQuery.Where(x => x.CreatedOn >= model.StartDate && x.CreatedOn <= model.EndDate && x.IsActive == true);

                }
            }
            else
            {
                if (model.StartDate.Year != 0001)
                {
                    model.StartDate = new Component.Utility().GetDate(model.StartDate);
                    if (model.EndDate.Year != 0001) { model.EndDate = new Component.Utility().GetDate(model.EndDate).AddDays(1).AddSeconds(-1); }
                    if (model.EndDate.Year == 0001) { model.EndDate = model.StartDate.AddDays(1).AddSeconds(-1); }
                    iQuery = this._laburnum.StudentFees.Where(x => x.CreatedOn >= model.StartDate && x.CreatedOn <= model.EndDate && x.IsActive == true);

                }
            }
            List<API.LABURNUM.COM.StudentFee> dbStudentFee = iQuery.OrderByDescending(x => x.StudentFeeId).ToList();
            return dbStudentFee;
        }

        private List<API.LABURNUM.COM.StudentFeeDetail> GetStudenFeeDetails(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            List<API.LABURNUM.COM.StudentFeeDetail> dbstudentFeeDetails = new List<StudentFeeDetail>();
            API.LABURNUM.COM.StudentFeeDetail apiSFD = new StudentFeeDetail()
            {
                MonthlyFee = model.MonthlyFee,
                //AnnualFunctionFee = model.AnnualFunctionFee,
                LateFee = model.LateFee,
                PendingFee = model.PendingFee,
                IsActive = true,
                CreatedOn = new Component.Utility().GetISTDateTime(),
            };
            dbstudentFeeDetails.Add(apiSFD);

            return dbstudentFeeDetails;
        }

        public long GetStudentFeeId(long classid, long studentId, long admissionTypeId)
        {
            IQueryable<API.LABURNUM.COM.StudentFee> iQuery = this._laburnum.StudentFees.Where(x => x.AdmissionTypeId == admissionTypeId && x.StudentId == studentId && x.ClassId == classid && x.IsActive == true);
            List<API.LABURNUM.COM.StudentFee> dbStudentFee = iQuery.OrderByDescending(x => x.StudentFeeId).ToList();
            if (dbStudentFee.Count == 0) { return -1; }
            //if (dbStudentFee.Count > 1) { return -1; }
            return dbStudentFee[0].StudentFeeId;
        }

        public API.LABURNUM.COM.StudentFee GetStudentFeeById(long studentFeeId)
        {
            studentFeeId.TryValidate();
            List<API.LABURNUM.COM.StudentFee> dbStudentFee = this._laburnum.StudentFees.Where(x => x.StudentFeeId == studentFeeId && x.IsActive == true).ToList();
            if (dbStudentFee.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbStudentFee.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            return dbStudentFee[0];
        }


    }
}