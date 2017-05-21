using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class CurriculumController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.CurriculumModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.CurriculumApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.CurriculumModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.CurriculumApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.CurriculumModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.CurriculumApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.CurriculumModel> SearchActiveCurriculums(DTO.LABURNUM.COM.CurriculumModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CurriculumHelper(new FrontEndApi.CurriculumApi().GetActiveCurriculums()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CurriculumModel> SearchInActiveCurriculums(DTO.LABURNUM.COM.CurriculumModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CurriculumHelper(new FrontEndApi.CurriculumApi().GetInActiveCurriculums()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CurriculumModel> SearchAllCurriculums(DTO.LABURNUM.COM.CurriculumModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CurriculumHelper(new FrontEndApi.CurriculumApi().GetAllCurriculums()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CurriculumModel> SearchCurriculumByAdvanceSearch(DTO.LABURNUM.COM.CurriculumModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CurriculumHelper(new FrontEndApi.CurriculumApi().GetCurriculumByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}