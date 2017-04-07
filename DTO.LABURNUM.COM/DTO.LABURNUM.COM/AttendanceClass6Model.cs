using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class AttendanceClass6Model
    {
         public AttendanceClass6Model()
        {
            this.ApiClientModel = new ApiClientModel();
        }

        public long AttendanceClass6Id { get; set; }
        public long StudentId { get; set; }
        public long ClassId { get; set; }
        public long SectionId { get; set; }
        public long FacultyId { get; set; }
        public System.DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ApiClientModel ApiClientModel { get; set; }
    }
}
