using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class SectionController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.SectionModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.SectionApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.SectionModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.SectionApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.SectionModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.SectionApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.SectionModel> SearchActiveSections(DTO.LABURNUM.COM.SectionModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new SectionHelper(new FrontEndApi.SectionApi().GetActiveSections()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.SectionModel> SearchInActiveSections(DTO.LABURNUM.COM.SectionModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new SectionHelper(new FrontEndApi.SectionApi().GetInActiveSections()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.SectionModel> SearchAllSections(DTO.LABURNUM.COM.SectionModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new SectionHelper(new FrontEndApi.SectionApi().GetAllSections()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.SectionModel> SearchSectionByAdvanceSearch(DTO.LABURNUM.COM.SectionModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new SectionHelper(new FrontEndApi.SectionApi().GetSectionByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }

        public DTO.LABURNUM.COM.SectionModel SearchSectionById(DTO.LABURNUM.COM.SectionModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new SectionHelper(new FrontEndApi.SectionApi().GetSectionBySectionId(model.SectionId)).MapSingle();
            }
            else { return null; }
        }
    }
}