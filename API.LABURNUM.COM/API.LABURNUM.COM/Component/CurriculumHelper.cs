using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class CurriculumHelper
    {
        private List<API.LABURNUM.COM.Curriculum> Curriculums;

        public CurriculumHelper()
        {
            this.Curriculums = new List<API.LABURNUM.COM.Curriculum>();
        }

        public CurriculumHelper(List<API.LABURNUM.COM.Curriculum> Curriculums)
        {
            if (Curriculums == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.Curriculums = Curriculums;
        }

        public CurriculumHelper(API.LABURNUM.COM.Curriculum Curriculum)
        {
            if (Curriculum == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.Curriculums = new List<API.LABURNUM.COM.Curriculum>();
            this.Curriculums.Add(Curriculum);
        }

        public List<DTO.LABURNUM.COM.CurriculumModel> Map()
        {
            if (this.Curriculums == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.CurriculumModel> dtoCurriculums = new List<DTO.LABURNUM.COM.CurriculumModel>();
            foreach (API.LABURNUM.COM.Curriculum item in this.Curriculums)
            {
                dtoCurriculums.Add(MapCore(item));
            }
            return dtoCurriculums;
        }

        public DTO.LABURNUM.COM.CurriculumModel MapSingle()
        {
            if (this.Curriculums == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.Curriculums.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.Curriculums[0]);
        }

        private DTO.LABURNUM.COM.CurriculumModel MapCore(API.LABURNUM.COM.Curriculum Curriculum)
        {
            DTO.LABURNUM.COM.CurriculumModel dtoClass = new DTO.LABURNUM.COM.CurriculumModel()
            {
                CurriculumId = Curriculum.CurriculumId,
                AcademicYearId = Curriculum.AcademicYearId,
                ClassId = Curriculum.ClassId,
                AddedById = Curriculum.AddedById,
                AddedByName = Curriculum.Faculty.FacultyName,
                UpdatedByName = Curriculum.UpdatedById != null ? Curriculum.Faculty1.FacultyName : "",
                MonthId = Curriculum.MonthId,
                CurriculumDetails = new CurriculumDetailHelper(Curriculum.CurriculumDetails.Where(x => x.IsActive == true).ToList()).Map(),
                AcademicYearText = Curriculum.AcademicYearTable.StartYear + "-" + Curriculum.AcademicYearTable.EndYear,
                MonthName = Curriculum.MonthId != null ? Curriculum.Month.MonthName : "",
                ClassName = Curriculum.Class.ClassName,
                CreatedOn = Curriculum.CreatedOn,
                IsActive = Curriculum.IsActive,
                LastUpdated = Curriculum.LastUpdated,
            };
            return dtoClass;
        }
    }
}