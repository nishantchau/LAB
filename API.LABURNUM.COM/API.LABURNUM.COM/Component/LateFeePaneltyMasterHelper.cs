using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class LateFeePaneltyMasterHelper
    {
        private List<API.LABURNUM.COM.LateFeePaneltyMaster> LateFeePaneltyMasters;

        public LateFeePaneltyMasterHelper()
        {
            this.LateFeePaneltyMasters = new List<API.LABURNUM.COM.LateFeePaneltyMaster>();
        }

        public LateFeePaneltyMasterHelper(List<API.LABURNUM.COM.LateFeePaneltyMaster> lateFeePaneltyMasters)
        {
            if (lateFeePaneltyMasters == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.LateFeePaneltyMasters = lateFeePaneltyMasters;
        }

        public LateFeePaneltyMasterHelper(API.LABURNUM.COM.LateFeePaneltyMaster lateFeePaneltyMaster)
        {
            if (lateFeePaneltyMaster == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.LateFeePaneltyMasters = new List<API.LABURNUM.COM.LateFeePaneltyMaster>();
            this.LateFeePaneltyMasters.Add(lateFeePaneltyMaster);
        }

        public List<DTO.LABURNUM.COM.LateFeePaneltyMasterModel> Map()
        {
            if (this.LateFeePaneltyMasters == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.LateFeePaneltyMasterModel> dtoClasses = new List<DTO.LABURNUM.COM.LateFeePaneltyMasterModel>();
            foreach (API.LABURNUM.COM.LateFeePaneltyMaster item in this.LateFeePaneltyMasters)
            {
                dtoClasses.Add(MapCore(item));
            }
            return dtoClasses;
        }

        public DTO.LABURNUM.COM.LateFeePaneltyMasterModel MapSingle()
        {
            if (this.LateFeePaneltyMasters == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.LateFeePaneltyMasters.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.LateFeePaneltyMasters[0]);
        }

        private DTO.LABURNUM.COM.LateFeePaneltyMasterModel MapCore(API.LABURNUM.COM.LateFeePaneltyMaster apiclass)
        {

            DTO.LABURNUM.COM.LateFeePaneltyMasterModel dtoClass = new DTO.LABURNUM.COM.LateFeePaneltyMasterModel()
            {
                LateFeePaneltyMasterId = apiclass.LateFeePaneltyMasterId,
                DaysAfter = apiclass.DaysAfter,
                Fine = apiclass.Fine,
                CreatedOn = apiclass.CreatedOn,
                IsActive = apiclass.IsActive,
                LastUpdated = apiclass.LastUpdated
            };

            return dtoClass;
        }
    }
}