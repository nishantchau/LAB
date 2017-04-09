using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class AcademicYearTableModel
    {
        public AcademicYearTableModel()
        {
            this.ApiClientModel = new ApiClientModel();
        }

        public long AcademicYearTableId { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public ApiClientModel ApiClientModel { get; set; }

        public string AcademicYear { get; set; }
    }
}
