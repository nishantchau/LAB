using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class UserTypeController : ApiController
    {
        public List<DTO.LABURNUM.COM.UserTypeModel> SearchActiveUserTypes(DTO.LABURNUM.COM.UserTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new UserTypeHelper(new FrontEndApi.UserTypeApi().GetActiveUserTypes()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.UserTypeModel> SearchInActiveUserTypes(DTO.LABURNUM.COM.UserTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new UserTypeHelper(new FrontEndApi.UserTypeApi().GetInActiveUserTypes()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.UserTypeModel> SearchAllUserTypes(DTO.LABURNUM.COM.UserTypeModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new UserTypeHelper(new FrontEndApi.UserTypeApi().GetAllUserTypes()).Map();
            }
            else { return null; }
        }
    }
}