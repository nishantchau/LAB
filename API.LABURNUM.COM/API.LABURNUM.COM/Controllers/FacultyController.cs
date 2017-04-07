using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class FacultyController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.FacultyModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.FacultyApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.FacultyModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.FacultyApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.FacultyModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.FacultyApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.FacultyModel> SearchActiveFaculties(DTO.LABURNUM.COM.FacultyModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FacultyHelper(new FrontEndApi.FacultyApi().GetActiveFaculty()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.FacultyModel> SearchInActiveFaculties(DTO.LABURNUM.COM.FacultyModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FacultyHelper(new FrontEndApi.FacultyApi().GetInActiveFaculty()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.FacultyModel> SearchAllFaculties(DTO.LABURNUM.COM.FacultyModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FacultyHelper(new FrontEndApi.FacultyApi().GetAllFaculties()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.FacultyModel> SearchFacultyByAdvanceSearch(DTO.LABURNUM.COM.FacultyModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FacultyHelper(new FrontEndApi.FacultyApi().GetFacultyByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }

        public DTO.LABURNUM.COM.FacultyModel FacultyLogin(DTO.LABURNUM.COM.FacultyModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FacultyHelper(new FrontEndApi.FacultyApi().FacultyLogin(model.UserName, model.Password)).MapSingle();
            }
            else
            {
                return null;
            }
        }

        public void UpdateProfile(DTO.LABURNUM.COM.FacultyModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.FacultyApi().UpdateProfile(model);
            }
        }
    }
}