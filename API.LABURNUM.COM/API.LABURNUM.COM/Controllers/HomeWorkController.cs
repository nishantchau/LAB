using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class HomeWorkController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.HomeWorkApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.HomeWorkApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.HomeWorkApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.HomeWorkModel> SearchActiveHomeWork(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new HomeWorkHelper(new FrontEndApi.HomeWorkApi().GetActiveHomeWork()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.HomeWorkModel> SearchInActiveHomeWork(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new HomeWorkHelper(new FrontEndApi.HomeWorkApi().GetInActiveHomeWork()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.HomeWorkModel> SearchAllHomeWork(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new HomeWorkHelper(new FrontEndApi.HomeWorkApi().GetAllHomeWork()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.HomeWorkModel> SearchHomeWorkByAdvanceSearch(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new HomeWorkHelper(new FrontEndApi.HomeWorkApi().GetHomeWorkByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}