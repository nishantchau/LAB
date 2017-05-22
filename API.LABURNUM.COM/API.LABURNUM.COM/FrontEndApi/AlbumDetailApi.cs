using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class AlbumDetailApi
    {
        private LaburnumEntities _laburnum;

        public AlbumDetailApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddAlbumDetail(DTO.LABURNUM.COM.AlbumDetailModel model)
        {
            API.LABURNUM.COM.AlbumDetail apiAlbumDetail = new AlbumDetail()
            {
                Attachment = model.Attachment,
                AlbumId = model.AlbumId,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.AlbumDetails.Add(apiAlbumDetail);
            this._laburnum.SaveChanges();
            return apiAlbumDetail.AlbumDetailId;
        }

        private long AddValidation(DTO.LABURNUM.COM.AlbumDetailModel model)
        {
            model.Attachment.TryValidate();
            return AddAlbumDetail(model);
        }

        public long Add(DTO.LABURNUM.COM.AlbumDetailModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.AlbumDetailModel model)
        {
            model.AlbumDetailId.TryValidate();
            List<API.LABURNUM.COM.AlbumDetail> dbAlbumDetails = this._laburnum.AlbumDetails.Where(x => x.AlbumDetailId == model.AlbumDetailId && x.IsActive == true).ToList();
            if (dbAlbumDetails.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAlbumDetails.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAlbumDetails[0].Attachment = model.Attachment;
            dbAlbumDetails[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.AlbumDetailModel model)
        {
            model.AlbumDetailId.TryValidate();
            List<API.LABURNUM.COM.AlbumDetail> dbAlbumDetails = this._laburnum.AlbumDetails.Where(x => x.AlbumDetailId == model.AlbumDetailId && x.IsActive == true).ToList();
            if (dbAlbumDetails.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAlbumDetails.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAlbumDetails[0].IsActive = model.IsActive;
            dbAlbumDetails[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.AlbumDetail> GetAlbumDetailByAdvanceSearch(DTO.LABURNUM.COM.AlbumDetailModel model)
        {
            IQueryable<API.LABURNUM.COM.AlbumDetail> iQuery = null;
            //Search By AlbumDetail ID.
            if (model.AlbumDetailId > 0)
            {
                iQuery = this._laburnum.AlbumDetails.Where(x => x.AlbumDetailId == model.AlbumDetailId && x.IsActive == true);
            }
            //Search By AlbumId.
            if (iQuery != null) { if (model.AlbumId > 0) { iQuery = iQuery.Where(x => x.AlbumId == model.AlbumId && x.IsActive == true); } }
            else { if (model.AlbumId > 0) { iQuery = this._laburnum.AlbumDetails.Where(x => x.AlbumId == model.AlbumId && x.IsActive == true); } }

            List<API.LABURNUM.COM.AlbumDetail> dbAlbumDetails = iQuery.ToList();
            return dbAlbumDetails;
        }

        public List<API.LABURNUM.COM.AlbumDetail> GetActiveAlbumDetails()
        {
            return this._laburnum.AlbumDetails.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.AlbumDetail> GetInActiveAlbumDetails()
        {
            return this._laburnum.AlbumDetails.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.AlbumDetail> GetAllAlbumDetails()
        {
            return this._laburnum.AlbumDetails.ToList();
        }
    }
}