using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class ClassSubjectFacultyTableController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.ClassSubjectFacultyTableApi().Add(model);

            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.ClassSubjectFacultyTableApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.ClassSubjectFacultyTableApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel> SearchActiveClassSubjectFaculties(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new ClassSubjectFacultyTableHelper(new FrontEndApi.ClassSubjectFacultyTableApi().GetActiveClassSubjectFacultyTables()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel> SearchInActiveClassSubjectFaculties(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new ClassSubjectFacultyTableHelper(new FrontEndApi.ClassSubjectFacultyTableApi().GetInActiveClassSubjectFacultyTables()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel> SearchAllClassSubjectFaculties(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new ClassSubjectFacultyTableHelper(new FrontEndApi.ClassSubjectFacultyTableApi().GetAllClassSubjectFacultyTables()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel> SearchClassSubjectFacultyByAdvanceSearch(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new ClassSubjectFacultyTableHelper(new FrontEndApi.ClassSubjectFacultyTableApi().GetClassSubjectFacultyTableByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}