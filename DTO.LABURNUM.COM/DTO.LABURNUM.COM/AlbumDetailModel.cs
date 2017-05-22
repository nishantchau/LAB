using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class AlbumDetailModel
    {
        public AlbumDetailModel()
        {
            this.ApiClientModel = new ApiClientModel();
        }

        public long AlbumDetailId { get; set; }
        public long AlbumId { get; set; }
        public string Attachment { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public ApiClientModel ApiClientModel { get; set; }

        public string AlbumName { get; set; }
    }
}
