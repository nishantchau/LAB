using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class AlbumModel
    {
        public AlbumModel()
        {
            this.ApiClientModel = new ApiClientModel();
            this.AlbumDetails = new List<AlbumDetailModel>();
        }

        public long AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string AlbumCoverImage { get; set; }
        public long AddedById { get; set; }
        public Nullable<long> UpdatedById { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public DTO.LABURNUM.COM.ApiClientModel ApiClientModel { get; set; }
        public List<DTO.LABURNUM.COM.AlbumDetailModel> AlbumDetails { get; set; }

        public string AddedByName { get; set; }
        public string UpdatedByName { get; set; }
    }
}
