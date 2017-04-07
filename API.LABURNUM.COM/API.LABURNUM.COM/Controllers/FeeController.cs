using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class FeeController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.FeeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.FeeApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.FeeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.FeeApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.FeeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.FeeApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.FeeModel> SearchFeeByAdvanceSearch(DTO.LABURNUM.COM.FeeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FeeHelper(new FrontEndApi.FeeApi().GetFeeByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.FeeModel> SearchAllActiveFee(DTO.LABURNUM.COM.FeeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FeeHelper(new FrontEndApi.FeeApi().GetAllActiveFees()).Map();
            }
            else { return null; }
        }
    }
}