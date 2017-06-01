using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class DashBoardModel
    {
        public string SMSBalance { get; set; }
        public int PresentStudent { get; set; }
        public int AbsentStudent { get; set; }
        public bool Status { get; set; }
        public bool IsPresentInMorning { get; set; }
        public bool IsPresentAfterLunch { get; set; }
    }
}
