using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class AlbumController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.AlbumModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.AlbumApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.AlbumModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AlbumApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.AlbumModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.AlbumApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.AlbumModel> SearchActiveAlbums(DTO.LABURNUM.COM.AlbumModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AlbumHelper(new FrontEndApi.AlbumApi().GetActiveAlbums()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.AlbumModel> SearchInActiveAlbums(DTO.LABURNUM.COM.AlbumModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AlbumHelper(new FrontEndApi.AlbumApi().GetInActiveAlbums()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.AlbumModel> SearchAllAlbums(DTO.LABURNUM.COM.AlbumModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AlbumHelper(new FrontEndApi.AlbumApi().GetAllAlbums()).Map();
            }
            else { return null; }
        }

        public List<DTO.LABURNUM.COM.AlbumModel> SearchAlbumByAdvanceSearch(DTO.LABURNUM.COM.AlbumModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new AlbumHelper(new FrontEndApi.AlbumApi().GetAlbumByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}