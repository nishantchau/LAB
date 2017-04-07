using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class AttendanceClassLKGController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.AttendanceClassLKGModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.AttendanceClassLKGApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.AttendanceClassLKGModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AttendanceClassLKGApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.AttendanceClassLKGModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AttendanceClassLKGApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.AttendanceClassLKGModel> SearchAttendanceClassLKGByAdvanceSearch(DTO.LABURNUM.COM.AttendanceClassLKGModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AttendanceClassLKGHelper(new FrontEndApi.AttendanceClassLKGApi().GetAttendanceClassLKGByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}