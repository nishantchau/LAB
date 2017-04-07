using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class ApiResponseModel
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public object Result { get; set; }
    }
}
