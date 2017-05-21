using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class CurriculumDetailModel
    {
        public CurriculumDetailModel()
        {
            this.ApiClientModel = new ApiClientModel();
        }

        public long CurriculumDetailId { get; set; }
        public long CurriculumId { get; set; }
        public long SubjectId { get; set; }
        public string Syllabus { get; set; }
        public string Activity { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public ApiClientModel ApiClientModel { get; set; }

        public string SubjectName { get; set; }
    }
}
