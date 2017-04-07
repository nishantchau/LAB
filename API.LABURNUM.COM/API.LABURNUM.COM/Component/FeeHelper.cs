using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class FeeHelper
    {
        private List<API.LABURNUM.COM.Fee> Fees;

        public FeeHelper()
        {
            this.Fees = new List<API.LABURNUM.COM.Fee>();
        }

        public FeeHelper(List<API.LABURNUM.COM.Fee> fees)
        {
            if (fees == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.Fees = fees;
        }

        public FeeHelper(API.LABURNUM.COM.Fee fee)
        {
            if (fee == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.Fees = new List<API.LABURNUM.COM.Fee>();
            this.Fees.Add(fee);
        }

        public List<DTO.LABURNUM.COM.FeeModel> Map()
        {
            if (this.Fees == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.FeeModel> dtoFees = new List<DTO.LABURNUM.COM.FeeModel>();
            foreach (API.LABURNUM.COM.Fee item in this.Fees)
            {
                dtoFees.Add(MapCore(item));
            }
            return dtoFees;
        }

        public DTO.LABURNUM.COM.FeeModel MapSingle()
        {
            if (this.Fees == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.Fees.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.Fees[0]);
        }

        private DTO.LABURNUM.COM.FeeModel MapCore(API.LABURNUM.COM.Fee fee)
        {

            DTO.LABURNUM.COM.FeeModel dtoFee = new DTO.LABURNUM.COM.FeeModel()
            {
                FeeId = fee.FeeId,
                AdmissionTypeId = fee.AdmissionTypeId,
                AnnualCharges = fee.AnnualCharges,
                DevelopementCharges = fee.DevelopementCharges,
                AdmissionFee = fee.AdmissionFee,
                ExamFee = fee.ExamFee,
                SecurityFee = fee.SecurityFee,
                MonthlyFee = fee.MonthlyFee,
                SportsFee = fee.SportsFee,
                ClassId = fee.ClassId,
                CreatedOn = fee.CreatedOn,
                IsActive = fee.IsActive,
                LastUpdated = fee.LastUpdated,
                AdmissionType = fee.AdmissionType.Name,
                ClassName = fee.Class.ClassName
            };
            return dtoFee;
        }
    }
}