using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;
using System.Globalization;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class StudentFeeDetailApi
    {
        private LaburnumEntities _laburnum;

        public StudentFeeDetailApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddStudentFeeDetail(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (model.ChequeDate.GetValueOrDefault().Year == 0001) { model.ChequeDate = null; }
            else { if (model.ChequePaidAmount <= 0) { model.ChequeDate = null; } }
            API.LABURNUM.COM.StudentFeeDetail apiStudentFeeDetail = new StudentFeeDetail()
            {
                StudentId = model.StudentId,
                ClassId = model.ClassId,
                SectionId = model.SectionId,
                MonthlyFee = model.MonthlyFee,
                // AnnualFunctionFee = model.AnnualFunctionFee,
                CashPaidAmount = model.CashPaidAmount,
                BankId = model.BankId,
                ChequeDate = model.ChequeDate,
                ChequeNumber = model.ChequeNumber,
                ChequePaidAmount = model.ChequePaidAmount,
                ChequeStatus = model.ChequeStatus,
                LateFee = model.LateFee,
                PendingFee = model.PendingFee,
                TransportFee = model.TransportFee,
                DiscountAmount = model.DiscountAmount,
                DiscountRemarks = model.DiscountRemarks,
                PayForTheMonth = model.PayForTheMonth,
                CollectedById = model.CollectedById,
                AcademicYearId = model.AcademicYearId,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.StudentFeeDetails.Add(apiStudentFeeDetail);
            this._laburnum.SaveChanges();
            return apiStudentFeeDetail.StudentFeeDetailId;
        }

        private long AddValidation(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            model.TryValidate();
            return AddStudentFeeDetail(model);
        }

        public long Add(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            model.StudentFeeDetailId.TryValidate();
            IQueryable<API.LABURNUM.COM.StudentFeeDetail> iQuery = this._laburnum.StudentFeeDetails.Where(x => x.StudentFeeDetailId == model.StudentFeeDetailId && x.IsActive == true);
            List<API.LABURNUM.COM.StudentFeeDetail> dbStudentFeeDetails = iQuery.ToList();
            if (dbStudentFeeDetails.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbStudentFeeDetails.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbStudentFeeDetails[0].StudentId = model.StudentId;
            dbStudentFeeDetails[0].ClassId = model.ClassId;
            dbStudentFeeDetails[0].SectionId = model.SectionId;
            dbStudentFeeDetails[0].MonthlyFee = model.MonthlyFee;
            dbStudentFeeDetails[0].LateFee = model.LateFee;
            dbStudentFeeDetails[0].TransportFee = model.TransportFee;
            // dbStudentFeeDetails[0].AnnualFunctionFee = model.AnnualFunctionFee;
            dbStudentFeeDetails[0].CashPaidAmount = model.CashPaidAmount;
            dbStudentFeeDetails[0].BankId = model.BankId;
            dbStudentFeeDetails[0].ChequeDate = model.ChequeDate;
            dbStudentFeeDetails[0].ChequeNumber = model.ChequeNumber;
            dbStudentFeeDetails[0].ChequePaidAmount = model.ChequePaidAmount;
            dbStudentFeeDetails[0].ChequeStatus = model.ChequeStatus;
            dbStudentFeeDetails[0].PayForTheMonth = model.PayForTheMonth;
            dbStudentFeeDetails[0].PendingFee = model.PendingFee;
            dbStudentFeeDetails[0].DiscountAmount = model.DiscountAmount;
            dbStudentFeeDetails[0].DiscountRemarks = model.DiscountRemarks;
            dbStudentFeeDetails[0].CollectedById = model.CollectedById;
            dbStudentFeeDetails[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            model.StudentFeeDetailId.TryValidate();
            IQueryable<API.LABURNUM.COM.StudentFeeDetail> iQuery = this._laburnum.StudentFeeDetails.Where(x => x.StudentFeeDetailId == model.StudentFeeDetailId && x.IsActive == true);
            List<API.LABURNUM.COM.StudentFeeDetail> dbStudentFeeDetails = iQuery.ToList();
            if (dbStudentFeeDetails.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbStudentFeeDetails.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbStudentFeeDetails[0].IsActive = model.IsActive;
            dbStudentFeeDetails[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.StudentFeeDetail> GetStudentFeeDetailByAdvanceSearch(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            IQueryable<API.LABURNUM.COM.StudentFeeDetail> iQuery = null;
            if (model.StudentFeeDetailId > 0)
            {
                iQuery = this._laburnum.StudentFeeDetails.Where(x => x.StudentFeeDetailId == model.StudentFeeDetailId && x.IsActive == true);
            }
            //Search By Academic Year Id.
            if (iQuery != null) { if (model.AcademicYearId > 0) { iQuery = iQuery.Where(x => x.AcademicYearId == model.AcademicYearId && x.IsActive == true); } }
            else { if (model.AcademicYearId > 0) { iQuery = this._laburnum.StudentFeeDetails.Where(x => x.AcademicYearId == model.AcademicYearId && x.IsActive == true); } }
            //Search By StudentId.
            if (iQuery != null) { if (model.StudentId > 0) { iQuery = iQuery.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            else { if (model.StudentId > 0) { iQuery = this._laburnum.StudentFeeDetails.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            //Search By ClassId.
            if (iQuery != null) { if (model.ClassId > 0) { iQuery = iQuery.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            else { if (model.ClassId > 0) { iQuery = this._laburnum.StudentFeeDetails.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            //Search By SectionId.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.StudentFeeDetails.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Paid Month.
            if (iQuery != null) { if (model.PayForTheMonth > 0) { iQuery = iQuery.Where(x => x.PayForTheMonth == model.PayForTheMonth && x.IsActive == true); } }
            else { if (model.PayForTheMonth > 0) { iQuery = this._laburnum.StudentFeeDetails.Where(x => x.PayForTheMonth == model.PayForTheMonth && x.IsActive == true); } }
            //Search By Cheque Status id.
            if (iQuery != null) { if (model.ChequeStatus > 0) { iQuery = iQuery.Where(x => x.ChequeStatus == model.ChequeStatus && x.IsActive == true); } }
            else { if (model.ChequeStatus > 0) { iQuery = this._laburnum.StudentFeeDetails.Where(x => x.ChequeStatus == model.ChequeStatus && x.IsActive == true); } }
            //Search By Collected By id.
            if (iQuery != null) { if (model.CollectedById > 0) { iQuery = iQuery.Where(x => x.CollectedById == model.CollectedById && x.IsActive == true); } }
            else { if (model.CollectedById > 0) { iQuery = this._laburnum.StudentFeeDetails.Where(x => x.CollectedById == model.CollectedById && x.IsActive == true); } }
            //Search By Bank id.
            if (iQuery != null) { if (model.BankId > 0) { iQuery = iQuery.Where(x => x.BankId == model.BankId && x.IsActive == true); } }
            else { if (model.BankId > 0) { iQuery = this._laburnum.StudentFeeDetails.Where(x => x.BankId == model.BankId && x.IsActive == true); } }
            //Search By Cheque No.
            if (iQuery != null) { if (model.ChequeNumber != null) { iQuery = iQuery.Where(x => x.ChequeNumber.Equals(model.ChequeNumber) && x.IsActive == true); } }
            else { if (model.ChequeNumber != null) { iQuery = this._laburnum.StudentFeeDetails.Where(x => x.ChequeNumber.Equals(model.ChequeNumber) && x.IsActive == true); } }

            //Search By Cheque Date.
            //if (iQuery != null)
            //{
            //    if (model.ChequeDate.GetValueOrDefault().Year != 0001)
            //    {
            //        if (model.ChequeDate.GetValueOrDefault().Year != 0001) { model.ChequeSearchEndDate = model.ChequeDate.GetValueOrDefault().AddDays(1).AddSeconds(-1); }
            //        iQuery = iQuery.Where(x => x.ChequeDate.GetValueOrDefault() >= model.ChequeDate.GetValueOrDefault() && x.ChequeDate.GetValueOrDefault() <= model.ChequeSearchEndDate && x.IsActive == true);
            //    }
            //}
            //else
            //{
            //    if (model.ChequeDate.GetValueOrDefault().Year != 0001)
            //    {
            //        if (model.ChequeDate.GetValueOrDefault().Year != 0001) { model.ChequeSearchEndDate = model.ChequeDate.GetValueOrDefault().AddDays(1).AddSeconds(-1); }
            //        iQuery = this._laburnum.StudentFeeDetails.Where(x => x.ChequeDate.GetValueOrDefault() >= model.ChequeDate.GetValueOrDefault() && x.ChequeDate.GetValueOrDefault() <= model.ChequeSearchEndDate && x.IsActive == true);
            //    }
            //}

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

                    iQuery = this._laburnum.StudentFeeDetails.Where(x => x.CreatedOn >= model.StartDate && x.CreatedOn <= model.EndDate && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.StudentFeeDetail> dbStudentFeeDetails = iQuery.OrderByDescending(x => x.StudentFeeDetailId).ToList();
            return dbStudentFeeDetails;
        }

        //public List<API.LABURNUM.COM.StudentFeeDetail> GetStudentFeeDetailByStudentFeeId(long studentFeeId)
        //{
        //    DTO.LABURNUM.COM.StudentFeeDetailModel model = new DTO.LABURNUM.COM.StudentFeeDetailModel() { StudentFeeId = studentFeeId };
        //    List<API.LABURNUM.COM.StudentFeeDetail> dbStudentFeeDetails = GetStudentFeeDetailByAdvanceSearch(model);
        //    //if (dbStudentFeeDetails.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
        //    return dbStudentFeeDetails;
        //}

        public bool IsFeeDue(long stundentId, long classId, long sectionId, int month)
        {
            List<API.LABURNUM.COM.StudentFeeDetail> dbstudentFeeDetails = GetStudentFeeDetailByAdvanceSearch(new DTO.LABURNUM.COM.StudentFeeDetailModel() { StudentId = stundentId, ClassId = classId, SectionId = sectionId, PayForTheMonth = month });
            if (dbstudentFeeDetails.Count > 0) { return false; }
            else
            {
                return true;
            }
        }

        public API.LABURNUM.COM.StudentFeeDetail GetStudentFeeDetailByID(long Id)
        {
            Id.TryValidate();
            IQueryable<API.LABURNUM.COM.StudentFeeDetail> iQuery = this._laburnum.StudentFeeDetails.Where(x => x.StudentFeeDetailId == Id && x.IsActive == true);
            List<API.LABURNUM.COM.StudentFeeDetail> dbStudentFeeDetails = iQuery.ToList();
            if (dbStudentFeeDetails.Count == 0) { throw new Exception(Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbStudentFeeDetails.Count > 1) { throw new Exception(Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            return dbStudentFeeDetails[0];
        }

        public API.LABURNUM.COM.StudentFeeDetail UpdateChequeStatus(long studentFeeDetailId, long chequeStatus, string bounceRemarks)
        {
            studentFeeDetailId.TryValidate();
            IQueryable<API.LABURNUM.COM.StudentFeeDetail> iQuery = this._laburnum.StudentFeeDetails.Where(x => x.StudentFeeDetailId == studentFeeDetailId && x.IsActive == true);
            List<API.LABURNUM.COM.StudentFeeDetail> dbStudentFeeDetails = iQuery.ToList();
            if (dbStudentFeeDetails.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbStudentFeeDetails.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbStudentFeeDetails[0].ChequeStatus = chequeStatus;
            dbStudentFeeDetails[0].ChequeBounceRemarks = bounceRemarks;
            dbStudentFeeDetails[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
            return dbStudentFeeDetails[0];
        }

        //public double GetPendingFee(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        //{
        //    double pendingFee = 0;
        //    List<API.LABURNUM.COM.StudentFeeDetail> dblist = GetStudentFeeDetailByAdvanceSearch(model);
        //    if (dblist.Count > 0)
        //    {
        //        if (dblist[0].ChequeStatus == DTO.LABURNUM.COM.Utility.ChequeStatusMaster.GetChequeStatusMasterId(DTO.LABURNUM.COM.Utility.EnumChequeStatusMaster.BOUNCE)) { pendingFee = pendingFee + dblist[0].ChequePaidAmount.GetValueOrDefault(); }
        //        else { pendingFee = dblist[0].PendingFee.GetValueOrDefault(); }
        //    }
        //    return pendingFee;
        //}

        public API.LABURNUM.COM.StudentFeeDetail GetPendingFee(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            //double pendingFee = 0;
            List<API.LABURNUM.COM.StudentFeeDetail> dblist = GetStudentFeeDetailByAdvanceSearch(model);
            //if (dblist.Count > 0)
            //{
            //    if (dblist[0].ChequeStatus == DTO.LABURNUM.COM.Utility.ChequeStatusMaster.GetChequeStatusMasterId(DTO.LABURNUM.COM.Utility.EnumChequeStatusMaster.BOUNCE)) { pendingFee = pendingFee + dblist[0].ChequePaidAmount.GetValueOrDefault(); }
            //    else { pendingFee = dblist[0].PendingFee.GetValueOrDefault(); }
            //}
            if (dblist.Count == 0) { throw new Exception(Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            return dblist[0];
        }

        public API.LABURNUM.COM.StudentFeeDetail GetFeePaidDetailDuringAdmission(long studentId, long classId, long sectionId, long academicYear)
        {
            List<API.LABURNUM.COM.StudentFeeDetail> model = GetStudentFeeDetailByAdvanceSearch(new DTO.LABURNUM.COM.StudentFeeDetailModel() { AcademicYearId = academicYear, StudentId = studentId, ClassId = classId, SectionId = sectionId });
            List<API.LABURNUM.COM.StudentFeeDetail> dblist = model.Where(x => x.MonthlyFee == 0).ToList();
            if (dblist.Count == 0) { }
            return dblist[0];
        }

        public API.LABURNUM.COM.StudentFeeDetail GetFeePaidDetailDuringMonthlyFeePayment(long studentId, long classId, long sectionId, long academicYear)
        {
            List<API.LABURNUM.COM.StudentFeeDetail> model = GetStudentFeeDetailByAdvanceSearch(new DTO.LABURNUM.COM.StudentFeeDetailModel() { AcademicYearId = academicYear, StudentId = studentId, ClassId = classId, SectionId = sectionId });
            List<API.LABURNUM.COM.StudentFeeDetail> dblist = model.ToList();
            if (dblist.Count == 0) { }
            return dblist[1];
        }


    }
}