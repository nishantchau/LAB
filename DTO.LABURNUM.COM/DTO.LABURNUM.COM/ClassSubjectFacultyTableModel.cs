using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class ClassSubjectFacultyTableModel
    {
        public long ClassSubjectFacultyTableId { get; set; }
        public long ClassId { get; set; }
        public long SubjectId { get; set; }
        public long FacultyId { get; set; }
        public long SectionId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    }
}
