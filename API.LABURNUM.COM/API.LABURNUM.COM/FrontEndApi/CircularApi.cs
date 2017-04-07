using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;
using System.Globalization;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class CircularApi
    {
        private LaburnumEntities _laburnum;

        public CircularApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddCircular(DTO.LABURNUM.COM.CircularModel model)
        {
            API.LABURNUM.COM.Circular apiCircular = new Circular()
            {
                Subject = model.Subject,
                Attachment = model.Attachment,
                ClassIds = model.ClassIds,
                Details = model.Details,
                ExpiryOn = model.ExpiryOn,
                IsForAdmin = model.IsForAdmin,
                IsForFaculty = model.IsForFaculty,
                IsForParents = model.IsForParents,
                IsForStudent = model.IsForStudent,
                LastUpdated = model.LastUpdated,
                PublishedOn = model.PublishedOn,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.Circulars.Add(apiCircular);
            this._laburnum.SaveChanges();
            return apiCircular.CircularId;
        }

        private long AddValidation(DTO.LABURNUM.COM.CircularModel model)
        {
            model.Subject.TryValidate();
            model.Details.TryValidate();
            return AddCircular(model);
        }

        public long Add(DTO.LABURNUM.COM.CircularModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.CircularModel model)
        {
            model.CircularId.TryValidate();
            IQueryable<API.LABURNUM.COM.Circular> iQuery = this._laburnum.Circulars.Where(x => x.CircularId == model.CircularId && x.IsActive == true);
            List<API.LABURNUM.COM.Circular> dbRoutes = iQuery.ToList();
            if (dbRoutes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbRoutes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbRoutes[0].Subject = model.Subject;
            dbRoutes[0].Attachment = model.Attachment;
            dbRoutes[0].ClassIds = model.ClassIds;
            dbRoutes[0].Details = model.Details;
            dbRoutes[0].ExpiryOn = model.ExpiryOn;
            dbRoutes[0].IsForAdmin = model.IsForAdmin;
            dbRoutes[0].IsForFaculty = model.IsForFaculty;
            dbRoutes[0].IsForParents = model.IsForParents;
            dbRoutes[0].IsForStudent = model.IsForStudent;
            dbRoutes[0].PublishedOn = model.PublishedOn;
            dbRoutes[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.CircularModel model)
        {
            model.CircularId.TryValidate();
            IQueryable<API.LABURNUM.COM.Circular> iQuery = this._laburnum.Circulars.Where(x => x.CircularId == model.CircularId && x.IsActive == true);
            List<API.LABURNUM.COM.Circular> dbRoutes = iQuery.ToList();
            if (dbRoutes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbRoutes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbRoutes[0].IsActive = model.IsActive;
            dbRoutes[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.Circular> GetActiveCirculars()
        {
            return this._laburnum.Circulars.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.Circular> GetInActiveCirculars()
        {
            return this._laburnum.Circulars.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.Circular> GetAllCirculars()
        {
            return this._laburnum.Circulars.ToList();
        }

        public List<API.LABURNUM.COM.Circular> GetCircularByAdvanceSearch(DTO.LABURNUM.COM.CircularModel model)
        {
            IQueryable<API.LABURNUM.COM.Circular> iQuery = null;

            //Search CircularId.
            if (model.CircularId > 0)
            {
                iQuery = this._laburnum.Circulars.Where(x => x.CircularId == model.CircularId && x.IsActive == true);
            }

            //Search For Subject.
            if (iQuery != null)
            {
                if (model.Subject != null)
                {
                    iQuery = iQuery.Where(x => x.Subject.Trim().ToLower().Contains(model.Subject.Trim().ToLower()) && x.IsActive == true);
                }
            }
            else
            {
                if (model.Subject != null)
                {
                    iQuery = this._laburnum.Circulars.Where(x => x.Subject.Trim().ToLower().Contains(model.Subject.Trim().ToLower()) && x.IsActive == true);
                }
            }

            //Search For Admin.
            if (iQuery != null)
            {
                if (model.IsForAdmin == true)
                {
                    iQuery = iQuery.Where(x => x.IsForAdmin == model.IsForAdmin && x.IsActive == true);
                }
            }
            else
            {
                if (model.IsForAdmin == true)
                {
                    iQuery = this._laburnum.Circulars.Where(x => x.IsForAdmin == model.IsForAdmin && x.IsActive == true);
                }
            }

            //Search For IsForFaculty.
            if (iQuery != null)
            {
                if (model.IsForFaculty == true)
                {
                    iQuery = iQuery.Where(x => x.IsForFaculty == model.IsForFaculty && x.IsActive == true);
                }
            }
            else
            {
                if (model.IsForFaculty == true)
                {
                    iQuery = this._laburnum.Circulars.Where(x => x.IsForFaculty == model.IsForFaculty && x.IsActive == true);
                }
            }

            //Search For IsForParents.
            if (iQuery != null)
            {
                if (model.IsForParents == true)
                {
                    iQuery = iQuery.Where(x => x.IsForParents == model.IsForParents && x.IsActive == true);
                }
            }
            else
            {
                if (model.IsForAdmin == true)
                {
                    iQuery = this._laburnum.Circulars.Where(x => x.IsForParents == model.IsForParents && x.IsActive == true);
                }
            }

            //Search For IsForStudent.
            if (iQuery != null)
            {
                if (model.IsForStudent == true)
                {
                    iQuery = iQuery.Where(x => x.IsForStudent == model.IsForStudent && x.IsActive == true);
                }
            }
            else
            {
                if (model.IsForStudent == true)
                {
                    iQuery = this._laburnum.Circulars.Where(x => x.IsForStudent == model.IsForStudent && x.IsActive == true);
                }
            }


            //Search By Date Range.
            if (iQuery != null)
            {
                if (model.StartDate.Year != 0001)
                {
                    string dd = Convert.ToString(model.StartDate.Day);
                    if (dd.Length == 1) { dd = "0" + dd; }
                    string mm = Convert.ToString(model.StartDate.Month);
                    if (mm.Length == 1) { mm = "0" + mm; }
                    string yy = Convert.ToString(model.StartDate.Year);
                    string sdate = dd + "/" + mm + "/" + yy;
                    model.StartDate = DateTime.ParseExact(sdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                if (model.EndDate.Year != 0001)
                {
                    string dd = Convert.ToString(model.EndDate.Day);
                    if (dd.Length == 1) { dd = "0" + dd; }
                    string mm = Convert.ToString(model.StartDate.Month);
                    if (mm.Length == 1) { mm = "0" + mm; }
                    string yy = Convert.ToString(model.StartDate.Year);
                    string sdate = dd + "/" + mm + "/" + yy;
                    model.EndDate = DateTime.ParseExact(sdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                if (model.EndDate.Year == 0001) { model.EndDate = model.StartDate.AddDays(1).AddSeconds(-1); }

                if (model.StartDate.Year != 0001)
                {
                    iQuery = iQuery.Where(x => x.PublishedOn >= model.StartDate && x.PublishedOn <= model.EndDate && x.IsActive == true);

                }
            }
            else
            {
                if (model.StartDate.Year != 0001)
                {
                    string dd = Convert.ToString(model.StartDate.Day);
                    if (dd.Length == 1) { dd = "0" + dd; }
                    string mm = Convert.ToString(model.StartDate.Month);
                    if (mm.Length == 1) { mm = "0" + mm; }
                    string yy = Convert.ToString(model.StartDate.Year);
                    string sdate = dd + "/" + mm + "/" + yy;
                    model.StartDate = DateTime.ParseExact(sdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                if (model.EndDate.Year != 0001)
                {
                    string dd = Convert.ToString(model.EndDate.Day);
                    if (dd.Length == 1) { dd = "0" + dd; }
                    string mm = Convert.ToString(model.StartDate.Month);
                    if (mm.Length == 1) { mm = "0" + mm; }
                    string yy = Convert.ToString(model.StartDate.Year);
                    string sdate = dd + "/" + mm + "/" + yy;
                    model.EndDate = DateTime.ParseExact(sdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                if (model.EndDate.Year == 0001) { model.EndDate = model.StartDate.AddDays(1).AddSeconds(-1); }

                if (model.StartDate.Year != 0001)
                {
                    iQuery = this._laburnum.Circulars.Where(x => x.PublishedOn >= model.StartDate && x.PublishedOn <= model.EndDate && x.IsActive == true);

                }
            }

            List<API.LABURNUM.COM.Circular> dbCircular = iQuery.ToList();
            return dbCircular;
        }
    }
}