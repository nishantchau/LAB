using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.LABURNUM.COM.Controllers
{
    public class PasswordConvertController : ApiController
    {
        public string GeneratePassword(string password)
        {
            return new API.LABURNUM.COM.Component.PasswordConvertor().Password(password);
        }
    }
}