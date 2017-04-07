using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class ClassController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.ClassModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.ClassApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.ClassModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.ClassApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.ClassModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.ClassApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.ClassModel> SearchActiveClasses(DTO.LABURNUM.COM.ClassModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new ClassHelper(new FrontEndApi.ClassApi().GetActiveClass()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.ClassModel> SearchInActiveClasses(DTO.LABURNUM.COM.ClassModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new ClassHelper(new FrontEndApi.ClassApi().GetInActiveClass()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.ClassModel> SearchAllClasses(DTO.LABURNUM.COM.ClassModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new ClassHelper(new FrontEndApi.ClassApi().GetAllClass()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.ClassModel> SearchClassByAdvanceSearch(DTO.LABURNUM.COM.ClassModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new ClassHelper(new FrontEndApi.ClassApi().GetClassByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}