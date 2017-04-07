using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class AttendanceClassPreNurseryController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.AttendanceClassPreNurseryModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.AttendanceClassPreNurseryApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.AttendanceClassPreNurseryModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AttendanceClassPreNurseryApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.AttendanceClassPreNurseryModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AttendanceClassPreNurseryApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.AttendanceClassPreNurseryModel> SearchAttendanceClassPreNurseryByAdvanceSearch(DTO.LABURNUM.COM.AttendanceClassPreNurseryModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AttendanceClassPreNurseryHelper(new FrontEndApi.AttendanceClassPreNurseryApi().GetAttendanceClassPreNurseryByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}