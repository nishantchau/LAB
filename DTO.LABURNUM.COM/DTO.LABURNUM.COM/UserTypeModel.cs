using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class UserTypeModel
    {
        public UserTypeModel()
        {
            this.ApiClientModel = new ApiClientModel();
        }
        public long UserTypeId { get; set; }
        public string Text { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public ApiClientModel ApiClientModel { get; set; }
    }
}
