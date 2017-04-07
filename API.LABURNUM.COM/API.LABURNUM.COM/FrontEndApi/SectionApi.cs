using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class SectionApi
    {
        private LaburnumEntities _laburnum;

        public SectionApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddSection(DTO.LABURNUM.COM.SectionModel model)
        {
            API.LABURNUM.COM.Section apiSection = new Section()
            {
                ClassId = model.ClassId,
                SectionName = model.SectionName,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.Sections.Add(apiSection);
            this._laburnum.SaveChanges();
            return apiSection.SectionId;
        }

        private long AddValidation(DTO.LABURNUM.COM.SectionModel model)
        {
            model.SectionName.TryValidate();
            return AddSection(model);
        }

        public long Add(DTO.LABURNUM.COM.SectionModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.SectionModel model)
        {
            model.SectionId.TryValidate();
            IQueryable<API.LABURNUM.COM.Section> iQuery = this._laburnum.Sections.Where(x => x.SectionId == model.SectionId && x.IsActive == true);
            List<API.LABURNUM.COM.Section> dbSections = iQuery.ToList();
            if (dbSections.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbSections.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbSections[0].ClassId = model.ClassId;
            dbSections[0].SectionName = model.SectionName;
            dbSections[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.SectionModel model)
        {
            model.SectionId.TryValidate();
            IQueryable<API.LABURNUM.COM.Section> iQuery = this._laburnum.Sections.Where(x => x.SectionId == model.SectionId && x.IsActive == true);
            List<API.LABURNUM.COM.Section> dbSections = iQuery.ToList();
            if (dbSections.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbSections.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbSections[0].IsActive = model.IsActive;
            dbSections[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.Section> GetActiveSections()
        {
            return this._laburnum.Sections.Where(x => x.IsActive == true).OrderBy(x => x.ClassId).ToList();
        }

        public List<API.LABURNUM.COM.Section> GetInActiveSections()
        {
            return this._laburnum.Sections.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.Section> GetAllSections()
        {
            return this._laburnum.Sections.OrderBy(x=>x.ClassId).ToList();
        }

        public List<API.LABURNUM.COM.Section> GetSectionByAdvanceSearch(DTO.LABURNUM.COM.SectionModel model)
        {
            IQueryable<API.LABURNUM.COM.Section> iQuery = null;
            if (model.SectionId > 0)
            {
                iQuery = this._laburnum.Sections.Where(x => x.SectionId == model.SectionId && x.IsActive == true);
            }

            if (iQuery != null)
            {
                if (model.ClassId > 0)
                {
                    iQuery = iQuery.Where(x => x.ClassId == model.ClassId && x.IsActive == true);
                }
            }
            else
            {
                if (model.ClassId > 0)
                {
                    iQuery = this._laburnum.Sections.Where(x => x.ClassId == model.ClassId && x.IsActive == true);
                }
            }

            if (iQuery != null)
            {
                if (model.SectionName != null)
                {
                    iQuery = iQuery.Where(x => x.SectionName.Trim().ToLower().Equals(model.SectionName.Trim().ToLower()) && x.IsActive == true);
                }
            }
            else
            {
                if (model.SectionName != null)
                {
                    iQuery = this._laburnum.Sections.Where(x => x.SectionName.Trim().ToLower().Equals(model.SectionName.Trim().ToLower()) && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.Section> dbSections = iQuery.ToList();
            return dbSections;
        }

        public API.LABURNUM.COM.Section GetSectionBySectionId(long sectionId)
        {
            sectionId.TryValidate();
            IQueryable<API.LABURNUM.COM.Section> iQuery = this._laburnum.Sections.Where(x => x.SectionId == sectionId && x.IsActive == true);
            List<API.LABURNUM.COM.Section> dbSections = iQuery.ToList();
            if (dbSections.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbSections.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            return dbSections[0];
        }
    }
}