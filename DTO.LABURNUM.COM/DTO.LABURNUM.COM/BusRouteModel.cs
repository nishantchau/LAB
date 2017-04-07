using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class BusRouteModel
    {
        public BusRouteModel()
        {
            this.ApiClientModel = new ApiClientModel();
        }
        public long BusRouteId { get; set; }
        public string BusRouteNumber { get; set; }
        public string BusStartFrom { get; set; }
        public string BusEndAt { get; set; }
        public double TranportCharges { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }

        public string StartPointEndPoint { get; set; }

        public ApiClientModel ApiClientModel { get; set; }
    }
}
