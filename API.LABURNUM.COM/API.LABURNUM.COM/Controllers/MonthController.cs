using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class MonthController : ApiController
    {
        public List<DTO.LABURNUM.COM.MonthModel> SearchActiveMonths(DTO.LABURNUM.COM.MonthModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new MonthHelper(new FrontEndApi.MonthApi().GetActiveMonths()).Map();
            }
            else { return null; }
        }
    }
}