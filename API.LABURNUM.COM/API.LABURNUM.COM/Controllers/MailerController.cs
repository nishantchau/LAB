using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.LABURNUM.COM.Controllers
{
    public class MailerController : ApiController
    {
        public void SendMail(DTO.LABURNUM.COM.MailerModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                model.Body = new Component.HtmlHelper().RenderViewToString("Mailer", "~/Views/Partial/ContactUsMail.cshtml", model);
                new API.LABURNUM.COM.Component.Mailer().MailSend("", "", model.Body, model.From, model.Subject);
            }
        }
    }
}