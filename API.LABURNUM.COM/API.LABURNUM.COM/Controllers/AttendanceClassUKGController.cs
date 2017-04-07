using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class AttendanceClassUKGController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.AttendanceClassUKGModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.AttendanceClassUKGApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.AttendanceClassUKGModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AttendanceClassUKGApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.AttendanceClassUKGModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AttendanceClassUKGApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.AttendanceClassUKGModel> SearchAttendanceClassUKGByAdvanceSearch(DTO.LABURNUM.COM.AttendanceClassUKGModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AttendanceClassUKGHelper(new FrontEndApi.AttendanceClassUKGApi().GetAttendanceClassUKGByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}