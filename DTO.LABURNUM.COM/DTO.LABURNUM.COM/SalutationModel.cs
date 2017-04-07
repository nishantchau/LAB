using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class SalutationModel
    {
        public SalutationModel()
        {
            this.ApiClientModel = new ApiClientModel();
        }

        public long SalutationId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public DTO.LABURNUM.COM.ApiClientModel ApiClientModel { get; set; }
    }
}
