using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.LABURNUM.COM.Controllers
{
    public class MessageController : ApiController
    {
        public string SearchSMSBalance(DTO.LABURNUM.COM.SMSAPIModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new Component.MessageApiHelper().GetSMSBalance();
            }
            else
            {
                return null;
            }
        }

        public string SendSingleSMS(DTO.LABURNUM.COM.SMSAPIModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new Component.MessageApiHelper().SendSingleSMS(model.MobileNumber, model.Message);
            }
            else
            {
                return null;
            }
        }
    }
}