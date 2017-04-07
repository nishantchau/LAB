using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class CircularNotificationTrackerModel
    {
        public CircularNotificationTrackerModel()
        {
            this.ApiClientModel = new ApiClientModel();
        }
        public long CircularNotificationTrackerId { get; set; }
        public long CircularId { get; set; }
        public System.DateTime ReadOn { get; set; }
        public long UserId { get; set; }
        public long UserTypeId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ApiClientModel ApiClientModel { get; set; }
    }
}
