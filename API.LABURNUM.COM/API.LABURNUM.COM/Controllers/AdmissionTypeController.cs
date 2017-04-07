using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class AdmissionTypeController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.AdmissionTypeApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AdmissionTypeApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AdmissionTypeApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.AdmissionTypeModel> SearchActiveAdmissionTypes(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AdmissionTypeHelper(new FrontEndApi.AdmissionTypeApi().GetActiveAdmissionTypes()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.AdmissionTypeModel> SearchInActiveAdmissionTypes(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AdmissionTypeHelper(new FrontEndApi.AdmissionTypeApi().GetInActiveAdmissionTypes()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.AdmissionTypeModel> SearchAllAdmissionTypes(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AdmissionTypeHelper(new FrontEndApi.AdmissionTypeApi().GetAllAdmissionTypes()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.AdmissionTypeModel> SearchAdmissionTypeByAdvanceSearch(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AdmissionTypeHelper(new FrontEndApi.AdmissionTypeApi().GetAdmissionTypeByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}