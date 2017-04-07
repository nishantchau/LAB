using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class AttendanceClass6Controller : ApiController
    {
        public long Add(DTO.LABURNUM.COM.AttendanceClass6Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.AttendanceClass6Api().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.AttendanceClass6Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AttendanceClass6Api().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.AttendanceClass6Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AttendanceClass6Api().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.AttendanceClass6Model> SearchAttendanceClass6ByAdvanceSearch(DTO.LABURNUM.COM.AttendanceClass6Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AttendanceClass6Helper(new FrontEndApi.AttendanceClass6Api().GetAttendanceClass6ByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}