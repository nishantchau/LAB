using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class SectionModel
    {
        public SectionModel()
        {
            this.ApiClientModel = new ApiClientModel();
            this.Classes = new List<ClassModel>();
        }

        public long SectionId { get; set; }
        public string SectionName { get; set; }
        public long ClassId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public DTO.LABURNUM.COM.ApiClientModel ApiClientModel { get; set; }
        public List<DTO.LABURNUM.COM.ClassModel> Classes { get; set; }
        public string ClassName { get; set; }
    }
}
