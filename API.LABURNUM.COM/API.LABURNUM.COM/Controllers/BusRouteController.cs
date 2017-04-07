using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class BusRouteController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.BusRouteModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.BusRouteApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.BusRouteModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.BusRouteApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.BusRouteModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.BusRouteApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.BusRouteModel> SearchActiveBusRoutes(DTO.LABURNUM.COM.BusRouteModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new BusRouteHelper(new FrontEndApi.BusRouteApi().GetActiveBusRoutes()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.BusRouteModel> SearchInActiveBusRoutes(DTO.LABURNUM.COM.BusRouteModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new BusRouteHelper(new FrontEndApi.BusRouteApi().GetInActiveBusRoutes()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.BusRouteModel> SearchAllBusRoutes(DTO.LABURNUM.COM.BusRouteModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new BusRouteHelper(new FrontEndApi.BusRouteApi().GetAllBusRoutes()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.BusRouteModel> SearchBusRouteByAdvanceSearch(DTO.LABURNUM.COM.BusRouteModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new BusRouteHelper(new FrontEndApi.BusRouteApi().GetBusRouteByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}