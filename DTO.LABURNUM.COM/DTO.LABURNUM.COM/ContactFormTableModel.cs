using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class ContactFormTableModel
    {
        public ContactFormTableModel()
        {
            this.ApiClientModel = new ApiClientModel();
        }
        public long ContactFormTableId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Message { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ApiClientModel ApiClientModel { get; set; }
    }
}
