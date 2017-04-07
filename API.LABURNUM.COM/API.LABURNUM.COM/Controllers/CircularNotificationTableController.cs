using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class CircularNotificationTableController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.CircularNotificationTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.CircularNotificationTableApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.CircularNotificationTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.CircularNotificationTableApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.CircularNotificationTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.CircularNotificationTableApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.CircularNotificationTableModel> SearchActiveCircularNotificationTable(DTO.LABURNUM.COM.CircularNotificationTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CircularNotificationTableHelper(new FrontEndApi.CircularNotificationTableApi().GetActiveCircularNotificationTables()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CircularNotificationTableModel> SearchInActiveCircularNotificationTable(DTO.LABURNUM.COM.CircularNotificationTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CircularNotificationTableHelper(new FrontEndApi.CircularNotificationTableApi().GetInActiveCircularNotificationTables()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CircularNotificationTableModel> SearchAllCircularNotificationTable(DTO.LABURNUM.COM.CircularNotificationTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CircularNotificationTableHelper(new FrontEndApi.CircularNotificationTableApi().GetAllCircularNotificationTables()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CircularNotificationTableModel> SearchCircularNotificationTableByAdvanceSearch(DTO.LABURNUM.COM.CircularNotificationTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CircularNotificationTableHelper(new FrontEndApi.CircularNotificationTableApi().GetCircularNotificationTableByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}