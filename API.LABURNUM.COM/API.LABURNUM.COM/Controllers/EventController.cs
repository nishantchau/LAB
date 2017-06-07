using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class EventController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.EventModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                model.AcademicYearId = new FrontEndApi.AcademicYearTableApi().GetAcademicYearByYear(new Component.Utility().GetISTDateTime().Year).AcademicYearTableId;
                return new FrontEndApi.EventApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.EventModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.EventApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.EventModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.EventApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.EventModel> SearchActiveEvents(DTO.LABURNUM.COM.EventModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new EventHelper(new FrontEndApi.EventApi().GetActiveEvents()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.EventModel> SearchInActiveEvents(DTO.LABURNUM.COM.EventModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new EventHelper(new FrontEndApi.EventApi().GetInActiveEvents()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.EventModel> SearchAllEvents(DTO.LABURNUM.COM.EventModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new EventHelper(new FrontEndApi.EventApi().GetAllEvents()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.EventModel> SearchEventByAdvanceSearch(DTO.LABURNUM.COM.EventModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new EventHelper(new FrontEndApi.EventApi().GetEventByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.EventModel> SearchEventForSite(DTO.LABURNUM.COM.EventModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                model.AcademicYearId = new FrontEndApi.AcademicYearTableApi().GetAcademicYearByYear(new Component.Utility().GetISTDateTime().Year).AcademicYearTableId;
                return new EventHelper(new FrontEndApi.EventApi().GetEventByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}