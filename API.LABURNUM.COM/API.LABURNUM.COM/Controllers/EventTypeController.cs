using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class EventTypeController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.EventTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.EventTypeApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.EventTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.EventTypeApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.EventTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.EventTypeApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.EventTypeModel> SearchActiveEventTypes(DTO.LABURNUM.COM.EventTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new EventTypeHelper(new FrontEndApi.EventTypeApi().GetActiveEventTypes()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.EventTypeModel> SearchInActiveEventTypes(DTO.LABURNUM.COM.EventTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new EventTypeHelper(new FrontEndApi.EventTypeApi().GetInActiveEventTypes()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.EventTypeModel> SearchAllEventTypes(DTO.LABURNUM.COM.EventTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new EventTypeHelper(new FrontEndApi.EventTypeApi().GetAllEventTypes()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.EventTypeModel> SearchEventTypeByAdvanceSearch(DTO.LABURNUM.COM.EventTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new EventTypeHelper(new FrontEndApi.EventTypeApi().GetEventTypeByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}