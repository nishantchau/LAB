﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class ClassSubjectFacultyTableModel
    {
        public ClassSubjectFacultyTableModel()
        {
            this.ApiClientModel = new ApiClientModel();
            this.Classes = new List<ClassModel>();
            this.Sections = new List<SectionModel>();
            this.Subjects = new List<SubjectModel>();
            this.Faculties = new List<FacultyModel>();
        }
        public long ClassSubjectFacultyTableId { get; set; }
        public long ClassId { get; set; }
        public long? SubjectId { get; set; }
        public long FacultyId { get; set; }
        public long SectionId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public ApiClientModel ApiClientModel { get; set; }
        public List<DTO.LABURNUM.COM.ClassModel> Classes { get; set; }
        public List<DTO.LABURNUM.COM.SectionModel> Sections { get; set; }
        public List<DTO.LABURNUM.COM.SubjectModel> Subjects { get; set; }
        public List<DTO.LABURNUM.COM.FacultyModel> Faculties { get; set; }

        public string ClassName { get; set; }
        public string SubjectName { get; set; }
        public string FacultyName { get; set; }
        public string SectionName { get; set; }
        public string FacultyContact { get; set; }
        public string FacultyEmail { get; set; }
    }
}
