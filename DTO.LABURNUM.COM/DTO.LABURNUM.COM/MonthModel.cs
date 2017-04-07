using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class MonthModel
    {
        public MonthModel()
        {
            this.ApiClientModel = new ApiClientModel();
        }
        public long MonthId { get; set; }
        public string MonthName { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public ApiClientModel ApiClientModel { get; set; }
    }
}
