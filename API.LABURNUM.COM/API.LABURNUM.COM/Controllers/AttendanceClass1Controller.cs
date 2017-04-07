using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class AttendanceClass1Controller : ApiController
    {
        public long Add(DTO.LABURNUM.COM.AttendanceClass1Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.AttendanceClass1Api().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.AttendanceClass1Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AttendanceClass1Api().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.AttendanceClass1Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AttendanceClass1Api().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.AttendanceClass1Model> SearchAttendanceClass1ByAdvanceSearch(DTO.LABURNUM.COM.AttendanceClass1Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AttendanceClass1Helper(new FrontEndApi.AttendanceClass1Api().GetAttendanceClass1ByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}