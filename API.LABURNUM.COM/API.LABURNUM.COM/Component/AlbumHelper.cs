using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AlbumHelper
    {
        private List<API.LABURNUM.COM.Album> Albums;

        public AlbumHelper()
        {
            this.Albums = new List<API.LABURNUM.COM.Album>();
        }

        public AlbumHelper(List<API.LABURNUM.COM.Album> albums)
        {
            if (albums == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.Albums = albums;
        }

        public AlbumHelper(API.LABURNUM.COM.Album album)
        {
            if (album == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.Albums = new List<API.LABURNUM.COM.Album>();
            this.Albums.Add(album);
        }

        public List<DTO.LABURNUM.COM.AlbumModel> Map()
        {
            if (this.Albums == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AlbumModel> dtoAlbums = new List<DTO.LABURNUM.COM.AlbumModel>();
            foreach (API.LABURNUM.COM.Album item in this.Albums)
            {
                dtoAlbums.Add(MapCore(item));
            }
            return dtoAlbums;
        }

        public DTO.LABURNUM.COM.AlbumModel MapSingle()
        {
            if (this.Albums == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.Albums.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.Albums[0]);
        }

        private DTO.LABURNUM.COM.AlbumModel MapCore(API.LABURNUM.COM.Album apiAlbum)
        {

            DTO.LABURNUM.COM.AlbumModel dtoClass = new DTO.LABURNUM.COM.AlbumModel()
            {
                AlbumId = apiAlbum.AlbumId,
                AlbumName = apiAlbum.AlbumName,
                AlbumCoverImage = apiAlbum.AlbumCoverImage,
                AddedById = apiAlbum.AddedById,
                UpdatedById = apiAlbum.UpdatedById,
                UpdatedByName = apiAlbum.UpdatedById != null ? apiAlbum.Faculty1.FacultyName : "",
                AddedByName = apiAlbum.Faculty.FacultyName,
                AlbumDetails = new AlbumDetailHelper(apiAlbum.AlbumDetails.Where(x => x.IsActive == true).ToList()).Map(),
                CreatedOn = apiAlbum.CreatedOn,
                IsActive = apiAlbum.IsActive,
                LastUpdated = apiAlbum.LastUpdated
            };
            return dtoClass;
        }
    }
}