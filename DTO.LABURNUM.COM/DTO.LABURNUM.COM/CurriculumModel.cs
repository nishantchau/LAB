using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class CurriculumModel
    {
        public CurriculumModel()
        {
            this.ApiClientModel = new ApiClientModel();
            this.AcademicYears = new List<AcademicYearTableModel>();
            this.Classes = new List<ClassModel>();
            this.Months = new List<MonthModel>();
            this.CurriculumDetails = new List<CurriculumDetailModel>();
            this.Subjects = new List<SubjectModel>();
        }

        public long CurriculumId { get; set; }
        public long AcademicYearId { get; set; }
        public Nullable<long> MonthId { get; set; }
        public long ClassId { get; set; }
        public long AddedById { get; set; }
        public Nullable<long> UpdatedById { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public ApiClientModel ApiClientModel { get; set; }
        public List<DTO.LABURNUM.COM.AcademicYearTableModel> AcademicYears { get; set; }
        public List<DTO.LABURNUM.COM.ClassModel> Classes { get; set; }
        public List<DTO.LABURNUM.COM.MonthModel> Months { get; set; }
        public List<DTO.LABURNUM.COM.SubjectModel> Subjects { get; set; }
        public List<DTO.LABURNUM.COM.CurriculumDetailModel> CurriculumDetails { get; set; }

        public string AcademicYearText { get; set; }
        public string ClassName { get; set; }
        public string AddedByName { get; set; }
        public string UpdatedByName { get; set; }
        public string MonthName { get; set; }

    }
}
