using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class SubjectController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.SubjectModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.SubjectApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.SubjectModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.SubjectApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.SubjectModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.SubjectApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.SubjectModel> SearchActiveSubjectes(DTO.LABURNUM.COM.SubjectModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new SubjectHelper(new FrontEndApi.SubjectApi().GetActiveSubject()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.SubjectModel> SearchInActiveSubjectes(DTO.LABURNUM.COM.SubjectModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new SubjectHelper(new FrontEndApi.SubjectApi().GetInActiveSubject()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.SubjectModel> SearchAllSubjectes(DTO.LABURNUM.COM.SubjectModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new SubjectHelper(new FrontEndApi.SubjectApi().GetAllSubject()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.SubjectModel> SearchSubjectByAdvanceSearch(DTO.LABURNUM.COM.SubjectModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new SubjectHelper(new FrontEndApi.SubjectApi().GetSubjectByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}