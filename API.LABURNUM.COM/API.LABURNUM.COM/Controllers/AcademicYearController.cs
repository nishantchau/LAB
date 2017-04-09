using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class AcademicYearController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.AcademicYearTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.AcademicYearTableApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.AcademicYearTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AcademicYearTableApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.AcademicYearTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AcademicYearTableApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.AcademicYearTableModel> SearchActiveAcademicYears(DTO.LABURNUM.COM.AcademicYearTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AcademicYearTableHelper(new FrontEndApi.AcademicYearTableApi().GetActiveAcademicYearTypes()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.AcademicYearTableModel> SearchInActiveAcademicYears(DTO.LABURNUM.COM.AcademicYearTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AcademicYearTableHelper(new FrontEndApi.AcademicYearTableApi().GetInActiveAcademicYearTypes()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.AcademicYearTableModel> SearchAllAcademicYears(DTO.LABURNUM.COM.AcademicYearTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AcademicYearTableHelper(new FrontEndApi.AcademicYearTableApi().GetAllAcademicYearTypes()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.AcademicYearTableModel> SearchAcademicYearByAdvanceSearch(DTO.LABURNUM.COM.AcademicYearTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AcademicYearTableHelper(new FrontEndApi.AcademicYearTableApi().GetAcademicYearTypeByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }

    }
}