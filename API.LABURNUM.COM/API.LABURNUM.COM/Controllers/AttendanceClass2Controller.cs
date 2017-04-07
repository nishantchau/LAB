using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class AttendanceClass2Controller : ApiController
    {
        public long Add(DTO.LABURNUM.COM.AttendanceClass2Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.AttendanceClass2Api().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.AttendanceClass2Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AttendanceClass2Api().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.AttendanceClass2Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AttendanceClass2Api().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.AttendanceClass2Model> SearchAttendanceClass2ByAdvanceSearch(DTO.LABURNUM.COM.AttendanceClass2Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AttendanceClass2Helper(new FrontEndApi.AttendanceClass2Api().GetAttendanceClass2ByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}