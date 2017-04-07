using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class SectionHelper
    {
        private List<API.LABURNUM.COM.Section> Sections;

        public SectionHelper()
        {
            this.Sections = new List<API.LABURNUM.COM.Section>();
        }

        public SectionHelper(List<API.LABURNUM.COM.Section> sections)
        {
            if (sections == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.Sections = sections;
        }

        public SectionHelper(API.LABURNUM.COM.Section section)
        {
            if (section == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.Sections = new List<API.LABURNUM.COM.Section>();
            this.Sections.Add(section);
        }

        public List<DTO.LABURNUM.COM.SectionModel> Map()
        {
            if (this.Sections == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.SectionModel> dtoClasses = new List<DTO.LABURNUM.COM.SectionModel>();
            foreach (API.LABURNUM.COM.Section item in this.Sections)
            {
                dtoClasses.Add(MapCore(item));
            }
            return dtoClasses;
        }

        public DTO.LABURNUM.COM.SectionModel MapSingle()
        {
            if (this.Sections == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.Sections.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.Sections[0]);
        }

        private DTO.LABURNUM.COM.SectionModel MapCore(API.LABURNUM.COM.Section section)
        {

            DTO.LABURNUM.COM.SectionModel dtoSection = new DTO.LABURNUM.COM.SectionModel()
            {
                ClassId = section.ClassId,
                SectionId = section.SectionId,
                SectionName = section.SectionName,
                CreatedOn = section.CreatedOn,
                ClassName = section.Class.ClassName,
                IsActive = section.IsActive,
                LastUpdated = section.LastUpdated
            };
            return dtoSection;
        }
    }
}