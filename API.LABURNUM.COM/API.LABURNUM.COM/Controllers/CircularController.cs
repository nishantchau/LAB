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
                return new FrontEndApi.CircularApi().Add(model);
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

        public List<DTO.LABURNUM.COM.CircularModel> SearchActiveClasses(DTO.LABURNUM.COM.CircularModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CircularHelper(new FrontEndApi.CircularApi().GetActiveCirculars()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CircularModel> SearchInActiveClasses(DTO.LABURNUM.COM.CircularModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CircularHelper(new FrontEndApi.CircularApi().GetInActiveCirculars()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CircularModel> SearchAllClasses(DTO.LABURNUM.COM.CircularModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CircularHelper(new FrontEndApi.CircularApi().GetAllCirculars()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CircularModel> SearchClassByAdvanceSearch(DTO.LABURNUM.COM.CircularModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CircularHelper(new FrontEndApi.CircularApi().GetCircularByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}