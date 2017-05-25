using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class AlbumApi
    {
        private LaburnumEntities _laburnum;

        public AlbumApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddAlbum(DTO.LABURNUM.COM.AlbumModel model)
        {
            API.LABURNUM.COM.Album apiAlbum = new Album()
            {
                AlbumName = model.AlbumName,
                AddedById = model.AddedById,
                AlbumCoverImage = model.AlbumCoverImage,
                AlbumDetails = GetApiAlbumDetails(model.AlbumDetails),
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.Albums.Add(apiAlbum);
            this._laburnum.SaveChanges();
            return apiAlbum.AlbumId;
        }

        public List<API.LABURNUM.COM.AlbumDetail> GetApiAlbumDetails(List<DTO.LABURNUM.COM.AlbumDetailModel> dblist)
        {
            List<API.LABURNUM.COM.AlbumDetail> apiAlbumDetails = new List<AlbumDetail>();
            foreach (DTO.LABURNUM.COM.AlbumDetailModel item in dblist)
            {
                if (item.Attachment != null)
                {
                    apiAlbumDetails.Add(new AlbumDetail() { Attachment = item.Attachment, IsActive = true, CreatedOn = System.DateTime.Now });
                }
            }
            return apiAlbumDetails;
        }

        private long AddValidation(DTO.LABURNUM.COM.AlbumModel model)
        {
            model.AlbumName.TryValidate();
            model.AddedById.TryValidate();
            return AddAlbum(model);
        }

        public long Add(DTO.LABURNUM.COM.AlbumModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.AlbumModel model)
        {
            model.AlbumId.TryValidate();
            List<API.LABURNUM.COM.Album> dbAlbums = this._laburnum.Albums.Where(x => x.AlbumId == model.AlbumId && x.IsActive == true).ToList();
            if (dbAlbums.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAlbums.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAlbums[0].AlbumCoverImage = model.AlbumCoverImage;
            dbAlbums[0].AlbumName = model.AlbumName;
            dbAlbums[0].UpdatedById = model.UpdatedById;
            dbAlbums[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
            UpdateAlbumDetails(model.AlbumId, model.AlbumDetails);
        }

        private void UpdateAlbumDetails(long albumId, List<DTO.LABURNUM.COM.AlbumDetailModel> dblist)
        {
            foreach (DTO.LABURNUM.COM.AlbumDetailModel item in dblist)
            {
                if (item.AlbumDetailId > 0)
                {
                    item.AlbumId = albumId;
                    new FrontEndApi.AlbumDetailApi().Update(item);
                }
                else
                {
                    if (item.Attachment != null)
                    {
                        item.AlbumId = albumId;
                        new FrontEndApi.AlbumDetailApi().Add(item);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.AlbumModel model)
        {
            model.AlbumId.TryValidate();
            List<API.LABURNUM.COM.Album> dbAlbums = this._laburnum.Albums.Where(x => x.AlbumId == model.AlbumId && x.IsActive == true).ToList();
            if (dbAlbums.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAlbums.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAlbums[0].IsActive = model.IsActive;
            dbAlbums[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.Album> GetAlbumByAdvanceSearch(DTO.LABURNUM.COM.AlbumModel model)
        {
            IQueryable<API.LABURNUM.COM.Album> iQuery = null;
            //Search By Album ID.
            if (model.AlbumId > 0)
            {
                iQuery = this._laburnum.Albums.Where(x => x.AlbumId == model.AlbumId && x.IsActive == true);
            }
            //Search By Album Name.
            if (iQuery != null) { if (model.AlbumName != null) { iQuery = iQuery.Where(x => x.AlbumName.Contains(model.AlbumName) && x.IsActive == true); } }
            else { if (model.AlbumName != null) { iQuery = this._laburnum.Albums.Where(x => x.AlbumName.Contains(model.AlbumName) && x.IsActive == true); } }

            //Search By Added By Id.
            if (iQuery != null) { if (model.AddedById > 0) { iQuery = iQuery.Where(x => x.AddedById == model.AddedById && x.IsActive == true); } }
            else { if (model.AddedById > 0) { iQuery = this._laburnum.Albums.Where(x => x.AddedById == model.AddedById && x.IsActive == true); } }

            //Search By Updated By Id.
            if (iQuery != null) { if (model.UpdatedById > 0) { iQuery = iQuery.Where(x => x.UpdatedById == model.UpdatedById && x.IsActive == true); } }
            else { if (model.UpdatedById > 0) { iQuery = this._laburnum.Albums.Where(x => x.UpdatedById == model.UpdatedById && x.IsActive == true); } }

            List<API.LABURNUM.COM.Album> dbAlbums = iQuery.ToList();
            return dbAlbums;
        }

        public List<API.LABURNUM.COM.Album> GetActiveAlbums()
        {
            List<API.LABURNUM.COM.Album> dbAlbums = this._laburnum.Albums.Where(x => x.IsActive == true).ToList();
            return dbAlbums;
        }

        public List<API.LABURNUM.COM.Album> GetInActiveAlbums()
        {
            return this._laburnum.Albums.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.Album> GetAllAlbums()
        {
            return this._laburnum.Albums.ToList();
        }
    }
}