using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class CircularModel
    {
        public CircularModel()
        {
            this.ApiClientModel = new ApiClientModel();
        }
        public long CircularId { get; set; }
        public string Details { get; set; }
        public string Subject { get; set; }
        public string Attachment { get; set; }
        public System.DateTime PublishedOn { get; set; }
        public Nullable<System.DateTime> ExpiryOn { get; set; }
        public string ClassIds { get; set; }
        public bool IsForFaculty { get; set; }
        public bool IsForParents { get; set; }
        public bool IsForStudent { get; set; }
        public bool IsForAdmin { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ApiClientModel ApiClientModel { get; set; }
        public bool IsPublishNow { get; set; }
        public bool IsEditable { get; set; }
    }
}
