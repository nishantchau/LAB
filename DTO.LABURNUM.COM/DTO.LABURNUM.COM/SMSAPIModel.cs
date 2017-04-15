using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class SMSAPIModel
    {
        public SMSAPIModel()
        {
            this.ApiClientModel = new ApiClientModel();
        }

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string MobileNumber { get; set; }
        public string Message { get; set; }
        public ApiClientModel ApiClientModel { get; set; }
    }
}
