using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class SubjectApi
    {
        private LaburnumEntities _laburnum;

        public SubjectApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddSubject(DTO.LABURNUM.COM.SubjectModel model)
        {
            API.LABURNUM.COM.Subject apiSubject = new Subject()
            {
                SubjectName = model.SubjectName,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.Subjects.Add(apiSubject);
            this._laburnum.SaveChanges();
            return apiSubject.SubjectId;
        }

        private long AddValidation(DTO.LABURNUM.COM.SubjectModel model)
        {
            model.SubjectName.TryValidate();
            return AddSubject(model);
        }

        public long Add(DTO.LABURNUM.COM.SubjectModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.SubjectModel model)
        {
            model.SubjectId.TryValidate();
            IQueryable<API.LABURNUM.COM.Subject> iQuery = this._laburnum.Subjects.Where(x => x.SubjectId == model.SubjectId && x.IsActive == true);
            List<API.LABURNUM.COM.Subject> dbSubjectes = iQuery.ToList();
            if (dbSubjectes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbSubjectes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbSubjectes[0].SubjectName = model.SubjectName;
            dbSubjectes[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.SubjectModel model)
        {
            model.SubjectId.TryValidate();
            IQueryable<API.LABURNUM.COM.Subject> iQuery = this._laburnum.Subjects.Where(x => x.SubjectId == model.SubjectId && x.IsActive == true);
            List<API.LABURNUM.COM.Subject> dbSubjectes = iQuery.ToList();
            if (dbSubjectes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbSubjectes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbSubjectes[0].IsActive = model.IsActive;
            dbSubjectes[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.Subject> GetActiveSubject()
        {
            return this._laburnum.Subjects.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.Subject> GetInActiveSubject()
        {
            return this._laburnum.Subjects.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.Subject> GetAllSubject()
        {
            return this._laburnum.Subjects.ToList();
        }

        public List<API.LABURNUM.COM.Subject> GetSubjectByAdvanceSearch(DTO.LABURNUM.COM.SubjectModel model)
        {
            IQueryable<API.LABURNUM.COM.Subject> iQuery = null;
            if (model.SubjectId > 0)
            {
                iQuery = this._laburnum.Subjects.Where(x => x.SubjectId == model.SubjectId && x.IsActive == true);
            }
            if (iQuery != null)
            {
                if (model.SubjectName != null)
                {
                    iQuery = iQuery.Where(x => x.SubjectName.Trim().ToLower().Equals(model.SubjectName.Trim().ToLower()) && x.IsActive == true);
                }
            }
            else
            {
                if (model.SubjectName != null)
                {
                    iQuery = this._laburnum.Subjects.Where(x => x.SubjectName.Trim().ToLower().Equals(model.SubjectName.Trim().ToLower()) && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.Subject> dbSubjectes = iQuery.ToList();
            return dbSubjectes;
        }
    }
}