using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class FeeApi
    {
        private LaburnumEntities _laburnum;

        public FeeApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddFee(DTO.LABURNUM.COM.FeeModel model)
        {
            API.LABURNUM.COM.Fee apifee = new Fee()
            {
                ClassId = model.ClassId,
                AdmissionTypeId = model.AdmissionTypeId,
                AdmissionFee = model.AdmissionFee,
                AnnualCharges = model.AnnualCharges,
                DevelopementCharges = model.DevelopementCharges,
                ExamFee = model.ExamFee,
                SecurityFee = model.SecurityFee,
                MonthlyFee = model.MonthlyFee,
                SportsFee = model.SportsFee,
                CreatedOn = new Component.Utility().GetISTDateTime(),
                IsActive = true
            };
            this._laburnum.Fees.Add(apifee);
            this._laburnum.SaveChanges();
            return apifee.FeeId;
        }

        private long AddValidation(DTO.LABURNUM.COM.FeeModel model)
        {
            model.TryValidate();
            return AddFee(model);
        }

        public long Add(DTO.LABURNUM.COM.FeeModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.FeeModel model)
        {
            model.FeeId.TryValidate();
            IQueryable<API.LABURNUM.COM.Fee> iQuery = this._laburnum.Fees.Where(x => x.FeeId == model.FeeId && x.IsActive == true);
            List<API.LABURNUM.COM.Fee> dbFees = iQuery.ToList();
            if (dbFees.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbFees.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbFees[0].AdmissionTypeId = model.AdmissionTypeId;
            dbFees[0].AdmissionFee = model.AdmissionFee;
            dbFees[0].AnnualCharges = model.AnnualCharges;
            dbFees[0].ClassId = model.ClassId;
            dbFees[0].DevelopementCharges = model.DevelopementCharges;
            dbFees[0].ExamFee = model.ExamFee;
            dbFees[0].SportsFee = model.SportsFee;
            dbFees[0].SecurityFee = model.SecurityFee;
            dbFees[0].MonthlyFee = model.MonthlyFee;
            dbFees[0].LastUpdated = new Component.Utility().GetISTDateTime();
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.FeeModel model)
        {
            model.FeeId.TryValidate();
            IQueryable<API.LABURNUM.COM.Fee> iQuery = this._laburnum.Fees.Where(x => x.FeeId == model.FeeId && x.IsActive == true);
            List<API.LABURNUM.COM.Fee> dbFees = iQuery.ToList();
            if (dbFees.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbFees.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbFees[0].IsActive = model.IsActive;
            dbFees[0].LastUpdated = new Component.Utility().GetISTDateTime();
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.Fee> GetFeeByAdvanceSearch(DTO.LABURNUM.COM.FeeModel model)
        {
            IQueryable<API.LABURNUM.COM.Fee> iQuery = null;
            if (model.FeeId > 0)
            {
                iQuery = this._laburnum.Fees.Where(x => x.FeeId == model.FeeId && x.IsActive == true);
            }
            //if (iQuery != null) { if (model.ClassId > 0) { iQuery = iQuery.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            //else { if (model.ClassId > 0) { iQuery = this._laburnum.Fees.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }

            if (iQuery != null) { if (model.AdmissionTypeId > 0) { iQuery = iQuery.Where(x => x.AdmissionTypeId == model.AdmissionTypeId && x.IsActive == true); } }
            else { if (model.AdmissionTypeId > 0) { iQuery = this._laburnum.Fees.Where(x => x.AdmissionTypeId == model.AdmissionTypeId && x.IsActive == true); } }

            if (iQuery != null) { if (model.ClassId > 0) { iQuery = iQuery.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            else { if (model.ClassId > 0) { iQuery = this._laburnum.Fees.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }

            List<API.LABURNUM.COM.Fee> dbFees = iQuery.ToList();
            return dbFees;
        }

        public List<API.LABURNUM.COM.Fee> GetAllActiveFees()
        {
            IQueryable<API.LABURNUM.COM.Fee> iQuery = this._laburnum.Fees.Where(x => x.IsActive == true);
            List<API.LABURNUM.COM.Fee> dbFees = iQuery.ToList();
            return dbFees;
        }
    }
}