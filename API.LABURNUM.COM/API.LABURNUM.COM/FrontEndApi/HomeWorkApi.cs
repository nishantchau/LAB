using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class HomeWorkApi
    {
        private LaburnumEntities _laburnum;

        public HomeWorkApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddHomeWork(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            API.LABURNUM.COM.HomeWork apiHomeWork = new HomeWork()
            {
                FacultyId = model.FacultyId,
                ClassId = model.ClassId,
                SectionId = model.SectionId,
                SubjectId = model.SubjectId,
                HomeWorkText = model.HomeWorkText,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.HomeWork.Add(apiHomeWork);
            this._laburnum.SaveChanges();
            return apiHomeWork.HomeWorkId;
        }

        private long AddValidation(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            model.FacultyId.TryValidate();
            model.ClassId.TryValidate();
            model.SectionId.TryValidate();
            model.HomeWorkText.TryValidate();
            return AddHomeWork(model);
        }

        public long Add(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            model.HomeWorkId.TryValidate();
            IQueryable<API.LABURNUM.COM.HomeWork> iQuery = this._laburnum.HomeWork.Where(x => x.HomeWorkId == model.HomeWorkId && x.IsActive == true);
            List<API.LABURNUM.COM.HomeWork> dbHomeWorkes = iQuery.ToList();
            if (dbHomeWorkes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbHomeWorkes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbHomeWorkes[0].HomeWorkText = model.HomeWorkText;
            dbHomeWorkes[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            model.HomeWorkId.TryValidate();
            IQueryable<API.LABURNUM.COM.HomeWork> iQuery = this._laburnum.HomeWork.Where(x => x.HomeWorkId == model.HomeWorkId && x.IsActive == true);
            List<API.LABURNUM.COM.HomeWork> dbHomeWorkes = iQuery.ToList();
            if (dbHomeWorkes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbHomeWorkes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbHomeWorkes[0].IsActive = model.IsActive;
            dbHomeWorkes[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.HomeWork> GetActiveHomeWork()
        {
            return this._laburnum.HomeWork.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.HomeWork> GetInActiveHomeWork()
        {
            return this._laburnum.HomeWork.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.HomeWork> GetAllHomeWork()
        {
            return this._laburnum.HomeWork.ToList();
        }

        public List<API.LABURNUM.COM.HomeWork> GetHomeWorkByAdvanceSearch(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            IQueryable<API.LABURNUM.COM.HomeWork> iQuery = null;

            //Search By Home Work Id
            if (model.HomeWorkId > 0)
            {
                iQuery = this._laburnum.HomeWork.Where(x => x.HomeWorkId == model.HomeWorkId && x.IsActive == true);
            }

            //Search By Home Work Text.
            if (iQuery != null)
            {
                if (model.HomeWorkText != null)
                {
                    iQuery = iQuery.Where(x => x.HomeWorkText.Trim().ToLower().Contains(model.HomeWorkText.Trim().ToLower()) && x.IsActive == true);
                }
            }
            else
            {
                if (model.HomeWorkText != null)
                {
                    iQuery = this._laburnum.HomeWork.Where(x => x.HomeWorkText.Trim().ToLower().Contains(model.HomeWorkText.Trim().ToLower()) && x.IsActive == true);
                }
            }

            //Search By FacultyID.
            if (iQuery != null)
            {
                if (model.FacultyId != null)
                {
                    iQuery = iQuery.Where(x => x.FacultyId == model.FacultyId && x.IsActive == true);
                }
            }
            else
            {
                if (model.HomeWorkText != null)
                {
                    iQuery = this._laburnum.HomeWork.Where(x => x.FacultyId == model.FacultyId && x.IsActive == true);
                }
            }

            //Search By ClassId.
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
                    iQuery = this._laburnum.HomeWork.Where(x => x.ClassId == model.ClassId && x.IsActive == true);
                }
            }

            //Search By SectionId.
            if (iQuery != null)
            {
                if (model.SectionId > 0)
                {
                    iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true);
                }
            }
            else
            {
                if (model.SectionId > 0)
                {
                    iQuery = this._laburnum.HomeWork.Where(x => x.SectionId == model.SectionId && x.IsActive == true);
                }
            }

            //Search By SubjectId.
            if (iQuery != null)
            {
                if (model.SubjectId > 0)
                {
                    iQuery = iQuery.Where(x => x.SubjectId == model.SubjectId && x.IsActive == true);
                }
            }
            else
            {
                if (model.SectionId > 0)
                {
                    iQuery = this._laburnum.HomeWork.Where(x => x.SubjectId == model.SubjectId && x.IsActive == true);
                }
            }

            //Search By Date Range.
            if (iQuery != null)
            {
                if (model.StartDate.Year != 0001)
                {
                    if (model.EndDate.Year == 0001) { model.EndDate = model.StartDate.AddDays(1).AddSeconds(-1); }
                    if (model.EndDate.Year != 0001) { model.EndDate = model.EndDate.AddDays(1).AddSeconds(-1); }
                    iQuery = iQuery.Where(x => x.CreatedOn >= model.StartDate && x.CreatedOn <= model.EndDate && x.IsActive == true);
                }
            }
            else
            {
                if (model.StartDate.Year != 0001)
                {
                    if (model.EndDate.Year == 0001) { model.EndDate = model.StartDate.AddDays(1).AddSeconds(-1); }
                    if (model.EndDate.Year != 0001) { model.EndDate = model.EndDate.AddDays(1).AddSeconds(-1); }
                    iQuery = this._laburnum.HomeWork.Where(x => x.CreatedOn >= model.StartDate && x.CreatedOn <= model.EndDate && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.HomeWork> dbHomeWorkes = iQuery.ToList();
            return dbHomeWorkes;
        }
    }
}