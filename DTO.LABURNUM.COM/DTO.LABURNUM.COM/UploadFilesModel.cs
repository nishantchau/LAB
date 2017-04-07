using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class UploadFilesModel
    {
        public UploadFilesModel()
        {
            this.ApiClientModel = new ApiClientModel();
        }
        public string Name { get; set; }
        public int Length { get; set; }
        public string Type { get; set; }
        public string SaveFileName { get; set; }

        public ApiClientModel ApiClientModel { get; set; }
    }
}
