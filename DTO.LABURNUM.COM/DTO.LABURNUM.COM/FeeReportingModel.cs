using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class FeeReportingModel
    {
        public FeeReportingModel()
        {
            this.ApiClientModel = new ApiClientModel();
            this.Classes = new List<ClassModel>();
            this.Sections = new List<SectionModel>();
            this.Students = new List<StudentModel>();
            this.AcademicYears = new List<AcademicYearTableModel>();
        }
        public long StudentId { get; set; }
        public long SectionId { get; set; }
        public long ClassId { get; set; }
        public long AcademicYearId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ApiClientModel ApiClientModel { get; set; }
        public List<DTO.LABURNUM.COM.ClassModel> Classes { get; set; }
        public List<DTO.LABURNUM.COM.SectionModel> Sections { get; set; }
        public List<DTO.LABURNUM.COM.StudentModel> Students { get; set; }
        public List<DTO.LABURNUM.COM.AcademicYearTableModel> AcademicYears { get; set; }
    }
}
