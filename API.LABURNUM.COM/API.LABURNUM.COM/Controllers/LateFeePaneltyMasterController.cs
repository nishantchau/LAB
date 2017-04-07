using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class LateFeePaneltyMasterController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.LateFeePaneltyMasterModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.LateFeePaneltyMasterApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.LateFeePaneltyMasterModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.LateFeePaneltyMasterApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.LateFeePaneltyMasterModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.LateFeePaneltyMasterApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.LateFeePaneltyMasterModel> SearchActiveLateFeePaneltyMasters(DTO.LABURNUM.COM.LateFeePaneltyMasterModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new LateFeePaneltyMasterHelper(new FrontEndApi.LateFeePaneltyMasterApi().GetActiveLateFeePaneltyMaster()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.LateFeePaneltyMasterModel> SearchInActiveLateFeePaneltyMasters(DTO.LABURNUM.COM.LateFeePaneltyMasterModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new LateFeePaneltyMasterHelper(new FrontEndApi.LateFeePaneltyMasterApi().GetInActiveLateFeePaneltyMaster()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.LateFeePaneltyMasterModel> SearchAllLateFeePaneltyMasters(DTO.LABURNUM.COM.LateFeePaneltyMasterModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new LateFeePaneltyMasterHelper(new FrontEndApi.LateFeePaneltyMasterApi().GetAllLateFeePaneltyMaster()).Map();
            }
            else { return null; }
        }

        public DTO.LABURNUM.COM.LateFeePaneltyMasterModel SearchLateFeePaneltyMasterById(DTO.LABURNUM.COM.LateFeePaneltyMasterModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new LateFeePaneltyMasterHelper(new FrontEndApi.LateFeePaneltyMasterApi().GetLateFeePaneltyMasterById(model.LateFeePaneltyMasterId)).MapSingle();
            }
            else { return null; }
        }
    }
}