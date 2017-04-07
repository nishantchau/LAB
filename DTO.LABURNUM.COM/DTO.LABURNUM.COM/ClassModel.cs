using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class ClassModel
    {
        public ClassModel()
        {
            this.ApiClientModel = new ApiClientModel();
            this.Sections = new List<SectionModel>();
        }
        public long ClassId { get; set; }
        public string ClassName { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public string EncryptId { get; set; }

        public DTO.LABURNUM.COM.ApiClientModel ApiClientModel { get; set; }
        public List<DTO.LABURNUM.COM.SectionModel> Sections { get; set; }
    }
}
