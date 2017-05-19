using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class LoginActivityController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.LoginActivityModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.LoginActivityApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.LoginActivityModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.LoginActivityApi().Update(model);
            }
        }

        public List<DTO.LABURNUM.COM.LoginActivityModel> SearchLoginActivityByAdvanceSearch(DTO.LABURNUM.COM.LoginActivityModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new LoginActivityHelper(new FrontEndApi.LoginActivityApi().GetLoginActivityByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}