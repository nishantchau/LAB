using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class FacultyModel
    {
        public FacultyModel()
        {
            this.ApiClientModel = new ApiClientModel();
            this.UserTypes = new List<UserTypeModel>();
            this.Classes = new List<ClassModel>();
            this.Sections = new List<SectionModel>();
            this.Subjects = new List<SubjectModel>();
        }

        public long FacultyId { get; set; }
        public string Photo { get; set; }
        public string FacultyName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public long? ClassId { get; set; }
        public long? SectionId { get; set; }
        public bool IsSubjectTeacher { get; set; }
        public long? SubjectId { get; set; }
        public long UserTypeId { get; set; }
        public bool IsClassTeacher { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public string ClassName { get; set; }
        public string SectionName { get; set; }
        public string UserTypeText { get; set; }
        public string SubjectName { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ReNewPassword { get; set; }

        public DTO.LABURNUM.COM.ApiClientModel ApiClientModel { get; set; }
        public List<DTO.LABURNUM.COM.UserTypeModel> UserTypes { get; set; }
        public List<DTO.LABURNUM.COM.ClassModel> Classes { get; set; }
        public List<DTO.LABURNUM.COM.SectionModel> Sections { get; set; }
        public List<DTO.LABURNUM.COM.SubjectModel> Subjects { get; set; }
    }
}
