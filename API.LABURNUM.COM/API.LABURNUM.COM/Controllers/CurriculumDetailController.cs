using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class CurriculumDetailController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.CurriculumDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.CurriculumDetailApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.CurriculumDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.CurriculumDetailApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.CurriculumDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.CurriculumDetailApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.CurriculumDetailModel> SearchActiveCurriculumDetails(DTO.LABURNUM.COM.CurriculumDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CurriculumDetailHelper(new FrontEndApi.CurriculumDetailApi().GetActiveCurriculumDetails()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CurriculumDetailModel> SearchInActiveCurriculumDetails(DTO.LABURNUM.COM.CurriculumDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CurriculumDetailHelper(new FrontEndApi.CurriculumDetailApi().GetInActiveCurriculumDetails()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CurriculumDetailModel> SearchAllCurriculumDetails(DTO.LABURNUM.COM.CurriculumDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CurriculumDetailHelper(new FrontEndApi.CurriculumDetailApi().GetAllCurriculumDetails()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.CurriculumDetailModel> SearchCurriculumDetailByAdvanceSearch(DTO.LABURNUM.COM.CurriculumDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new CurriculumDetailHelper(new FrontEndApi.CurriculumDetailApi().GetCurriculumDetailByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}