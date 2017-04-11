using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class LoginModel
    {
        public LoginModel()
        {
            this.ApiClientModel = new ApiClientModel();
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int LoginBy { get; set; }
       
        public DTO.LABURNUM.COM.ApiClientModel ApiClientModel { get; set; }
    }
}
