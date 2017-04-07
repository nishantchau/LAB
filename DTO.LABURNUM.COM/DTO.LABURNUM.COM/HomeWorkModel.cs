using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class HomeWorkModel
    {
        public HomeWorkModel()
        {
            this.ApiClientModel = new ApiClientModel();
            this.Classes = new List<ClassModel>();
            this.Sections = new List<SectionModel>();
            this.Faculties = new List<FacultyModel>();
            this.Subjects = new List<SubjectModel>();
        }
        public long HomeWorkId { get; set; }
        public long FacultyId { get; set; }
        public long SubjectId { get; set; }
        public long ClassId { get; set; }
        public long SectionId { get; set; }
        public string HomeWorkText { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FacultyName { get; set; }
        public string ClassName { get; set; }
        public string SectionName { get; set; }
        public string SubjectName { get; set; }

        public ApiClientModel ApiClientModel { get; set; }
        public List<DTO.LABURNUM.COM.FacultyModel> Faculties { get; set; }
        public List<DTO.LABURNUM.COM.SubjectModel> Subjects { get; set; }
        public List<DTO.LABURNUM.COM.ClassModel> Classes { get; set; }
        public List<DTO.LABURNUM.COM.SectionModel> Sections { get; set; }
    }
}
