using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class AttendanceClassPreNurseryApi
    {
        private LaburnumEntities _laburnum;

        public AttendanceClassPreNurseryApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddAttendanceClassPreNursery(DTO.LABURNUM.COM.AttendanceClassPreNurseryModel model)
        {
            API.LABURNUM.COM.AttendanceClassPreNursery apiAClass1 = new AttendanceClassPreNursery()
            {
                StudentId = model.StudentId,
                ClassId = model.ClassId,
                SectionId = model.SectionId,
                Date = model.Date,
                IsPresent = model.IsPresent,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.AttendanceClassPreNurseries.Add(apiAClass1);
            this._laburnum.SaveChanges();
            return apiAClass1.AttendanceClassPreNurseryId;
        }

        private long AddValidation(DTO.LABURNUM.COM.AttendanceClassPreNurseryModel model)
        {
            model.TryValidate();
            return AddAttendanceClassPreNursery(model);
        }

        public long Add(DTO.LABURNUM.COM.AttendanceClassPreNurseryModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.AttendanceClassPreNurseryModel model)
        {
            model.AttendanceClassPreNurseryId.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClassPreNursery> iQuery = this._laburnum.AttendanceClassPreNurseries.Where(x => x.AttendanceClassPreNurseryId == model.AttendanceClassPreNurseryId && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClassPreNursery> dbAttendanceClassPreNursery = iQuery.ToList();
            if (dbAttendanceClassPreNursery.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClassPreNursery.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClassPreNursery[0].IsPresent = model.IsPresent;
            dbAttendanceClassPreNursery[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.AttendanceClassPreNurseryModel model)
        {
            model.AttendanceClassPreNurseryId.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClassPreNursery> iQuery = this._laburnum.AttendanceClassPreNurseries.Where(x => x.AttendanceClassPreNurseryId == model.AttendanceClassPreNurseryId && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClassPreNursery> dbAttendanceClassPreNursery = iQuery.ToList();
            if (dbAttendanceClassPreNursery.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClassPreNursery.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClassPreNursery[0].IsActive = model.IsActive;
            dbAttendanceClassPreNursery[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.AttendanceClassPreNursery> GetAttendanceClassPreNurseryByAdvanceSearch(DTO.LABURNUM.COM.AttendanceClassPreNurseryModel model)
        {
            IQueryable<API.LABURNUM.COM.AttendanceClassPreNursery> iQuery = null;

            if (model.AttendanceClassPreNurseryId > 0) { iQuery = this._laburnum.AttendanceClassPreNurseries.Where(x => x.AttendanceClassPreNurseryId == model.AttendanceClassPreNurseryId && x.IsActive == true); }
            //Search By Class Id.
            if (iQuery != null) { if (model.ClassId > 0) { iQuery = iQuery.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            else { if (model.ClassId > 0) { iQuery = this._laburnum.AttendanceClassPreNurseries.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClassPreNurseries.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClassPreNurseries.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Student Id.
            if (iQuery != null) { if (model.StudentId > 0) { iQuery = iQuery.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            else { if (model.StudentId > 0) { iQuery = this._laburnum.AttendanceClassPreNurseries.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            //Search By Present.
            if (iQuery != null) { if (model.IsPresent) { iQuery = iQuery.Where(x => x.IsPresent == model.IsPresent && x.IsActive == true); } }
            else { if (model.IsPresent) { iQuery = this._laburnum.AttendanceClassPreNurseries.Where(x => x.IsPresent == model.IsPresent && x.IsActive == true); } }
            //Search By Date Range.
            if (iQuery != null)
            {
                if (model.StartDate.Year != 0001)
                {
                    if (model.EndDate.Year == 0001) { model.EndDate = model.EndDate.AddDays(1).AddSeconds(-1); }

                    iQuery = iQuery.Where(x => x.Date >= model.StartDate && x.Date <= model.EndDate && x.IsActive == true);
                }
            }
            else
            {
                if (model.StartDate.Year != 0001)
                {
                    if (model.EndDate.Year == 0001) { model.EndDate = model.EndDate.AddDays(1).AddSeconds(-1); }

                    iQuery = iQuery.Where(x => x.Date >= model.StartDate && x.Date <= model.EndDate && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.AttendanceClassPreNursery> dbAttendanceClassPreNursery = iQuery.ToList();
            return dbAttendanceClassPreNursery;
        }
    }
}