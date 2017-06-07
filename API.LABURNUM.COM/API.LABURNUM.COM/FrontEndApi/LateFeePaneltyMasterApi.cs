using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class LateFeePaneltyMasterApi
    {
        private LaburnumEntities _laburnum;

        public LateFeePaneltyMasterApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddLateFeePaneltyMaster(DTO.LABURNUM.COM.LateFeePaneltyMasterModel model)
        {
            API.LABURNUM.COM.LateFeePaneltyMaster apiLateFeePaneltyMaster = new LateFeePaneltyMaster()
            {
                DaysAfter = model.DaysAfter,
                Fine = model.Fine,
                CreatedOn = new Component.Utility().GetISTDateTime(),
                IsActive = true
            };
            this._laburnum.LateFeePaneltyMasters.Add(apiLateFeePaneltyMaster);
            this._laburnum.SaveChanges();
            return apiLateFeePaneltyMaster.LateFeePaneltyMasterId;
        }

        private long AddValidation(DTO.LABURNUM.COM.LateFeePaneltyMasterModel model)
        {
            model.DaysAfter.TryValidate();
            return AddLateFeePaneltyMaster(model);
        }

        public long Add(DTO.LABURNUM.COM.LateFeePaneltyMasterModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.LateFeePaneltyMasterModel model)
        {
            model.LateFeePaneltyMasterId.TryValidate();
            IQueryable<API.LABURNUM.COM.LateFeePaneltyMaster> iQuery = this._laburnum.LateFeePaneltyMasters.Where(x => x.LateFeePaneltyMasterId == model.LateFeePaneltyMasterId && x.IsActive == true);
            List<API.LABURNUM.COM.LateFeePaneltyMaster> dbLateFeePaneltyMasteres = iQuery.ToList();
            if (dbLateFeePaneltyMasteres.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbLateFeePaneltyMasteres.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbLateFeePaneltyMasteres[0].DaysAfter = model.DaysAfter;
            dbLateFeePaneltyMasteres[0].Fine = model.Fine;
            dbLateFeePaneltyMasteres[0].LastUpdated = new Component.Utility().GetISTDateTime();
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.LateFeePaneltyMasterModel model)
        {
            model.LateFeePaneltyMasterId.TryValidate();
            IQueryable<API.LABURNUM.COM.LateFeePaneltyMaster> iQuery = this._laburnum.LateFeePaneltyMasters.Where(x => x.LateFeePaneltyMasterId == model.LateFeePaneltyMasterId && x.IsActive == true);
            List<API.LABURNUM.COM.LateFeePaneltyMaster> dbLateFeePaneltyMasteres = iQuery.ToList();
            if (dbLateFeePaneltyMasteres.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbLateFeePaneltyMasteres.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbLateFeePaneltyMasteres[0].IsActive = model.IsActive;
            dbLateFeePaneltyMasteres[0].LastUpdated = new Component.Utility().GetISTDateTime();
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.LateFeePaneltyMaster> GetActiveLateFeePaneltyMaster()
        {
            return this._laburnum.LateFeePaneltyMasters.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.LateFeePaneltyMaster> GetInActiveLateFeePaneltyMaster()
        {
            return this._laburnum.LateFeePaneltyMasters.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.LateFeePaneltyMaster> GetAllLateFeePaneltyMaster()
        {
            return this._laburnum.LateFeePaneltyMasters.ToList();
        }

        public API.LABURNUM.COM.LateFeePaneltyMaster GetLateFeePaneltyMasterById(long id)
        {
            id.TryValidate();
            IQueryable<API.LABURNUM.COM.LateFeePaneltyMaster> iQuery = this._laburnum.LateFeePaneltyMasters.Where(x => x.LateFeePaneltyMasterId == id && x.IsActive == true);
            List<API.LABURNUM.COM.LateFeePaneltyMaster> dbLateFeePaneltyMasteres = iQuery.ToList();
            if (dbLateFeePaneltyMasteres.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbLateFeePaneltyMasteres.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            return dbLateFeePaneltyMasteres[0];

        }
    }
}