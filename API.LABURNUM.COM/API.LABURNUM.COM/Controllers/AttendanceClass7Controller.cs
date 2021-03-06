﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class AttendanceClass7Controller : ApiController
    {
        public long Add(DTO.LABURNUM.COM.AttendanceClass7Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.AttendanceClass7Api().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.AttendanceClass7Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AttendanceClass7Api().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.AttendanceClass7Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AttendanceClass7Api().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.AttendanceClass7Model> SearchAttendanceClass7ByAdvanceSearch(DTO.LABURNUM.COM.AttendanceClass7Model model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AttendanceClass7Helper(new FrontEndApi.AttendanceClass7Api().GetAttendanceClass7ByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}