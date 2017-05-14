using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;
using System.Globalization;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class AttendanceClass5Api
    {
        private LaburnumEntities _laburnum;

        public AttendanceClass5Api()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddAttendanceClass5(DTO.LABURNUM.COM.AttendanceClass5Model model)
        {
            API.LABURNUM.COM.AttendanceClass5 apiAClass1 = new AttendanceClass5()
            {
                StudentId = model.StudentId,
                ClassId = model.ClassId,
                SectionId = model.SectionId,
                Date = model.Date,
                IsPresent = model.IsPresent,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.AttendanceClass5.Add(apiAClass1);
            this._laburnum.SaveChanges();
            return apiAClass1.AttendanceClass5Id;
        }

        private long AddValidation(DTO.LABURNUM.COM.AttendanceClass5Model model)
        {
            model.TryValidate();
            return AddAttendanceClass5(model);
        }

        public long Add(DTO.LABURNUM.COM.AttendanceClass5Model model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.AttendanceClass5Model model)
        {
            model.AttendanceClass5Id.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClass5> iQuery = this._laburnum.AttendanceClass5.Where(x => x.AttendanceClass5Id == model.AttendanceClass5Id && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClass5> dbAttendanceClass5 = iQuery.ToList();
            if (dbAttendanceClass5.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClass5.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClass5[0].IsPresent = model.IsPresent;
            dbAttendanceClass5[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.AttendanceClass5Model model)
        {
            model.AttendanceClass5Id.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClass5> iQuery = this._laburnum.AttendanceClass5.Where(x => x.AttendanceClass5Id == model.AttendanceClass5Id && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClass5> dbAttendanceClass5 = iQuery.ToList();
            if (dbAttendanceClass5.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClass5.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClass5[0].IsActive = model.IsActive;
            dbAttendanceClass5[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.AttendanceClass5> GetAttendanceClass5ByAdvanceSearch(DTO.LABURNUM.COM.AttendanceClass5Model model)
        {
            IQueryable<API.LABURNUM.COM.AttendanceClass5> iQuery = null;

            if (model.AttendanceClass5Id > 0) { iQuery = this._laburnum.AttendanceClass5.Where(x => x.AttendanceClass5Id == model.AttendanceClass5Id && x.IsActive == true); }
            //Search By Class Id.
            if (iQuery != null) { if (model.ClassId > 0) { iQuery = iQuery.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            else { if (model.ClassId > 0) { iQuery = this._laburnum.AttendanceClass5.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClass5.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClass5.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Student Id.
            if (iQuery != null) { if (model.StudentId > 0) { iQuery = iQuery.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            else { if (model.StudentId > 0) { iQuery = this._laburnum.AttendanceClass5.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            //Search By Present.
            if (iQuery != null) { if (model.IsPresent) { iQuery = iQuery.Where(x => x.IsPresent == model.IsPresent && x.IsActive == true); } }
            else { if (model.IsPresent) { iQuery = this._laburnum.AttendanceClass5.Where(x => x.IsPresent == model.IsPresent && x.IsActive == true); } }
            //Search By Date Range.
            if (iQuery != null)
            {
                if (model.StartDate.Year != 0001)
                {
                    model.StartDate = new Component.Utility().GetDate(model.StartDate);
                }
                if (model.EndDate.Year != 0001)
                {
                    model.EndDate = new Component.Utility().GetDate(model.EndDate);
                }
                if (model.EndDate.Year == 0001) { model.EndDate = model.StartDate.AddDays(1).AddSeconds(-1); }

                if (model.StartDate.Year != 0001)
                {
                    iQuery = iQuery.Where(x => x.Date >= model.StartDate && x.Date <= model.EndDate && x.IsActive == true);
                }
            }
            else
            {
                if (model.StartDate.Year != 0001)
                {
                    model.StartDate = new Component.Utility().GetDate(model.StartDate);
                }
                if (model.EndDate.Year != 0001)
                {
                    model.EndDate = new Component.Utility().GetDate(model.EndDate);
                }
                if (model.EndDate.Year == 0001) { model.EndDate = model.StartDate.AddDays(1).AddSeconds(-1); }

                if (model.StartDate.Year != 0001)
                {
                    iQuery = this._laburnum.AttendanceClass5.Where(x => x.Date >= model.StartDate && x.Date <= model.EndDate && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.AttendanceClass5> dbAttendanceClass5 = iQuery.ToList();
            return dbAttendanceClass5;
        }
    }
}