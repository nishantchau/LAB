using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class EventModel
    {
        public EventModel()
        {
            this.ApiClientModel = new ApiClientModel();
            this.EventTypes = new List<EventTypeModel>();
        }

        public long EventId { get; set; }
        public long EventTypeId { get; set; }
        public long AcademicYearId { get; set; }
        public string EventName { get; set; }
        public string Classes { get; set; }
        public System.DateTime EventDate { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public ApiClientModel ApiClientModel { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventTypeText { get; set; }
        public string AcademicYearText { get; set; }

        public List<DTO.LABURNUM.COM.EventTypeModel> EventTypes { get; set; }
    }
}
