using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
   public class LoginTypeModel
    {
       public LoginTypeModel()
       {
           this.ApiClientModel = new ApiClientModel();
       }
       public DTO.LABURNUM.COM.ApiClientModel ApiClientModel { get; set; }
    }
}
