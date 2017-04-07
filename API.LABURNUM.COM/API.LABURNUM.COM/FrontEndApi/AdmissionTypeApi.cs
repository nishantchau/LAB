using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class AdmissionTypeApi
    {
        private LaburnumEntities _laburnum;

        public AdmissionTypeApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddAdmissionType(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            API.LABURNUM.COM.AdmissionType admissionType = new AdmissionType()
            {
                Name = model.Name,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.AdmissionTypes.Add(admissionType);
            this._laburnum.SaveChanges();
            return admissionType.AdmissionTypeId;
        }

        private long AddValidation(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            model.Name.TryValidate();
            return AddAdmissionType(model);
        }

        public long Add(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            model.AdmissionTypeId.TryValidate();
            IQueryable<API.LABURNUM.COM.AdmissionType> iQuery = this._laburnum.AdmissionTypes.Where(x => x.AdmissionTypeId == model.AdmissionTypeId && x.IsActive == true);
            List<API.LABURNUM.COM.AdmissionType> dbAdmissionTypes = iQuery.ToList();
            if (dbAdmissionTypes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAdmissionTypes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAdmissionTypes[0].Name = model.Name;
            dbAdmissionTypes[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            model.AdmissionTypeId.TryValidate();
            IQueryable<API.LABURNUM.COM.AdmissionType> iQuery = this._laburnum.AdmissionTypes.Where(x => x.AdmissionTypeId == model.AdmissionTypeId && x.IsActive == true);
            List<API.LABURNUM.COM.AdmissionType> dbAdmissionTypes = iQuery.ToList();
            if (dbAdmissionTypes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAdmissionTypes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAdmissionTypes[0].IsActive = model.IsActive;
            dbAdmissionTypes[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.AdmissionType> GetActiveAdmissionTypes()
        {
            return this._laburnum.AdmissionTypes.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.AdmissionType> GetInActiveAdmissionTypes()
        {
            return this._laburnum.AdmissionTypes.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.AdmissionType> GetAllAdmissionTypes()
        {
            return this._laburnum.AdmissionTypes.ToList();
        }

        public List<API.LABURNUM.COM.AdmissionType> GetAdmissionTypeByAdvanceSearch(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            IQueryable<API.LABURNUM.COM.AdmissionType> iQuery = null;
            if (model.AdmissionTypeId > 0)
            {
                iQuery = this._laburnum.AdmissionTypes.Where(x => x.AdmissionTypeId == model.AdmissionTypeId && x.IsActive == true);
            }
            if (iQuery != null)
            {
                if (model.Name != null)
                {
                    iQuery = iQuery.Where(x => x.Name.Trim().ToLower().Equals(model.Name.Trim().ToLower()) && x.IsActive == true);
                }
            }
            else
            {
                if (model.Name != null)
                {
                    iQuery = this._laburnum.AdmissionTypes.Where(x => x.Name.Trim().ToLower().Equals(model.Name.Trim().ToLower()) && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.AdmissionType> dbAdmissionTypes = iQuery.ToList();
            return dbAdmissionTypes;
        }
    }
}