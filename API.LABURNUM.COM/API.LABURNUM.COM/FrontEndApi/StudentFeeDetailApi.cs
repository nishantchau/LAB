using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

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
            API.LABURNUM.COM.StudentFeeDetail apiStudentFeeDetail = new StudentFeeDetail()
            {
                StudentId = model.StudentId,
                ClassId = model.ClassId,
                SectionId = model.SectionId,
                MonthlyFee = model.MonthlyFee,
                AnnualFunctionFee = model.AnnualFunctionFee,
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
            dbStudentFeeDetails[0].AnnualFunctionFee = model.AnnualFunctionFee;
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

            List<API.LABURNUM.COM.StudentFeeDetail> dbStudentFeeDetails = iQuery.OrderBy(x => x.StudentFeeDetailId).ToList();
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
    }
}