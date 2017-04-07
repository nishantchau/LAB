using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class AttendanceClass8Controller : ApiController
    {
        public long Add(DTO.LABURNUM.COM.AttendanceClass8Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.AttendanceClass8Api().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.AttendanceClass8Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AttendanceClass8Api().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.AttendanceClass8Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AttendanceClass8Api().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.AttendanceClass8Model> SearchAttendanceClass8ByAdvanceSearch(DTO.LABURNUM.COM.AttendanceClass8Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AttendanceClass8Helper(new FrontEndApi.AttendanceClass8Api().GetAttendanceClass8ByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}