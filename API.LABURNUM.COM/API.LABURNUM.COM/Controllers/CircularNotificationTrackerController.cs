using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class CircularNotificationTrackerController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.CircularNotificationTrackerModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.CircularNotificationTrackerApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.CircularNotificationTrackerModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.CircularNotificationTrackerApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.CircularNotificationTrackerModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.CircularNotificationTrackerApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.CircularNotificationTrackerModel> SearchActiveClasses(DTO.LABURNUM.COM.CircularNotificationTrackerModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CircularNotificationTrackerHelper(new FrontEndApi.CircularNotificationTrackerApi().GetActiveCircularNotificationTrackers()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CircularNotificationTrackerModel> SearchInActiveClasses(DTO.LABURNUM.COM.CircularNotificationTrackerModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CircularNotificationTrackerHelper(new FrontEndApi.CircularNotificationTrackerApi().GetInActiveCircularNotificationTrackers()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CircularNotificationTrackerModel> SearchAllClasses(DTO.LABURNUM.COM.CircularNotificationTrackerModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CircularNotificationTrackerHelper(new FrontEndApi.CircularNotificationTrackerApi().GetAllCircularNotificationTrackers()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CircularNotificationTrackerModel> SearchClassByAdvanceSearch(DTO.LABURNUM.COM.CircularNotificationTrackerModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CircularNotificationTrackerHelper(new FrontEndApi.CircularNotificationTrackerApi().GetCircularNotificationTrackerByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}