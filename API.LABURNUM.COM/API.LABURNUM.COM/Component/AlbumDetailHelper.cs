using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AlbumDetailHelper
    {
        private List<API.LABURNUM.COM.AlbumDetail> AlbumDetails;

        public AlbumDetailHelper()
        {
            this.AlbumDetails = new List<API.LABURNUM.COM.AlbumDetail>();
        }

        public AlbumDetailHelper(List<API.LABURNUM.COM.AlbumDetail> albumDetails)
        {
            if (albumDetails == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AlbumDetails = albumDetails;
        }

        public AlbumDetailHelper(API.LABURNUM.COM.AlbumDetail albumDetail)
        {
            if (albumDetail == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AlbumDetails = new List<API.LABURNUM.COM.AlbumDetail>();
            this.AlbumDetails.Add(albumDetail);
        }

        public List<DTO.LABURNUM.COM.AlbumDetailModel> Map()
        {
            if (this.AlbumDetails == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AlbumDetailModel> dtoAlbumDetails = new List<DTO.LABURNUM.COM.AlbumDetailModel>();
            foreach (API.LABURNUM.COM.AlbumDetail item in this.AlbumDetails)
            {
                dtoAlbumDetails.Add(MapCore(item));
            }
            return dtoAlbumDetails;
        }

        public DTO.LABURNUM.COM.AlbumDetailModel MapSingle()
        {
            if (this.AlbumDetails == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AlbumDetails.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AlbumDetails[0]);
        }

        private DTO.LABURNUM.COM.AlbumDetailModel MapCore(API.LABURNUM.COM.AlbumDetail AlbumDetail)
        {

            DTO.LABURNUM.COM.AlbumDetailModel dtoClass = new DTO.LABURNUM.COM.AlbumDetailModel()
            {
                AlbumDetailId = AlbumDetail.AlbumDetailId,
                Attachment = AlbumDetail.Attachment,
                CreatedOn = AlbumDetail.CreatedOn,
                IsActive = AlbumDetail.IsActive,
                LastUpdated = AlbumDetail.LastUpdated
            };
            return dtoClass;
        }
    }
}