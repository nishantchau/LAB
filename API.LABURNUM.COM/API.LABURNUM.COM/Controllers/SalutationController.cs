using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class SalutationController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.SalutationModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.SalutationApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.SalutationModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.SalutationApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.SalutationModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.SalutationApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.SalutationModel> SearchActiveSalutations(DTO.LABURNUM.COM.SalutationModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new SalutationHelper(new FrontEndApi.SalutationApi().GetActiveSalutations()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.SalutationModel> SearchInActiveSalutations(DTO.LABURNUM.COM.SalutationModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new SalutationHelper(new FrontEndApi.SalutationApi().GetInActiveSalutations()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.SalutationModel> SearchAllSalutations(DTO.LABURNUM.COM.SalutationModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new SalutationHelper(new FrontEndApi.SalutationApi().GetAllSalutations()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.SalutationModel> SearchSalutationByAdvanceSearch(DTO.LABURNUM.COM.SalutationModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new SalutationHelper(new FrontEndApi.SalutationApi().GetSalutationByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}