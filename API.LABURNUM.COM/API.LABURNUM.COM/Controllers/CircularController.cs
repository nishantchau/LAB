using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class CircularController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.CircularModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                long circularid = new FrontEndApi.CircularApi().Add(model);
                if (model.IsPublishNow) { new FrontEndApi.CircularNotificationTableApi().Add(new DTO.LABURNUM.COM.CircularNotificationTableModel() { CircularId = circularid, IsForAdmin = model.IsForAdmin, IsForFaculty = model.IsForFaculty, IsForParents = model.IsForParents, IsForStudent = model.IsForStudent }); }
                return circularid;
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.CircularModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.CircularApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.CircularModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.CircularApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.CircularModel> SearchActiveCirculars(DTO.LABURNUM.COM.CircularModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CircularHelper(new FrontEndApi.CircularApi().GetActiveCirculars()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CircularModel> SearchInActiveCirculars(DTO.LABURNUM.COM.CircularModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CircularHelper(new FrontEndApi.CircularApi().GetInActiveCirculars()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CircularModel> SearchAllCirculars(DTO.LABURNUM.COM.CircularModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CircularHelper(new FrontEndApi.CircularApi().GetAllCirculars()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CircularModel> SearchCircularByAdvanceSearch(DTO.LABURNUM.COM.CircularModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CircularHelper(new FrontEndApi.CircularApi().GetCircularByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}