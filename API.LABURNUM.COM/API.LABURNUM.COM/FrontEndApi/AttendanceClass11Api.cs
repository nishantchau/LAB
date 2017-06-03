using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;
using System.Globalization;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class AttendanceClass11Api
    {
        private LaburnumEntities _laburnum;

        public AttendanceClass11Api()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddAttendanceClass11(DTO.LABURNUM.COM.AttendanceClass11Model model)
        {
            API.LABURNUM.COM.AttendanceClass11 apiAClass11 = new AttendanceClass11()
            {
                StudentId = model.StudentId,
                ClassId = model.ClassId,
                SectionId = model.SectionId,
                MorningAttendanceDate = model.MorningAttendanceDate,
                IsPresentAfterLuch = model.IsPresentAfterLuch,
                IsPresentInMorning = model.IsPresentInMorning,
                CreatedOn = System.DateTime.Now,
                IsActive = true,
                FacultyId = model.FacultyId
            };
            this._laburnum.AttendanceClass11.Add(apiAClass11);
            this._laburnum.SaveChanges();
            return apiAClass11.AttendanceClass11Id;
        }

        private long AddValidation(DTO.LABURNUM.COM.AttendanceClass11Model model)
        {
            model.TryValidate();
            return AddAttendanceClass11(model);
        }

        public long Add(DTO.LABURNUM.COM.AttendanceClass11Model model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.AttendanceClass11Model model)
        {
            model.AttendanceClass11Id.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClass11> iQuery = this._laburnum.AttendanceClass11.Where(x => x.AttendanceClass11Id == model.AttendanceClass11Id && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClass11> dbAttendanceClass11 = iQuery.ToList();
            if (dbAttendanceClass11.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClass11.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClass11[0].IsPresentAfterLuch = model.IsPresentAfterLuch;
            dbAttendanceClass11[0].LunchAttendanceDate = System.DateTime.Now;
            dbAttendanceClass11[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.AttendanceClass11Model model)
        {
            model.AttendanceClass11Id.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClass11> iQuery = this._laburnum.AttendanceClass11.Where(x => x.AttendanceClass11Id == model.AttendanceClass11Id && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClass11> dbAttendanceClass11 = iQuery.ToList();
            if (dbAttendanceClass11.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClass11.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClass11[0].IsActive = model.IsActive;
            dbAttendanceClass11[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.AttendanceClass11> GetAttendanceClass11ByAdvanceSearch(DTO.LABURNUM.COM.AttendanceClass11Model model)
        {
            IQueryable<API.LABURNUM.COM.AttendanceClass11> iQuery = null;

            if (model.AttendanceClass11Id > 0) { iQuery = this._laburnum.AttendanceClass11.Where(x => x.AttendanceClass11Id == model.AttendanceClass11Id && x.IsActive == true); }
            //Search By Class Id.
            if (iQuery != null) { if (model.ClassId > 0) { iQuery = iQuery.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            else { if (model.ClassId > 0) { iQuery = this._laburnum.AttendanceClass11.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClass11.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClass11.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Student Id.
            if (iQuery != null) { if (model.StudentId > 0) { iQuery = iQuery.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            else { if (model.StudentId > 0) { iQuery = this._laburnum.AttendanceClass11.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            //Search By IsPresentInMorning.
            if (iQuery != null) { if (model.IsPresentInMorning) { iQuery = iQuery.Where(x => x.IsPresentInMorning == model.IsPresentInMorning && x.IsActive == true); } }
            else { if (model.IsPresentInMorning) { iQuery = this._laburnum.AttendanceClass11.Where(x => x.IsPresentInMorning == model.IsPresentInMorning && x.IsActive == true); } }
            //Search By IsPresentAfterLuch.
            if (iQuery != null) { if (model.IsPresentAfterLuch) { iQuery = iQuery.Where(x => x.IsPresentAfterLuch == model.IsPresentAfterLuch && x.IsActive == true); } }
            else { if (model.IsPresentAfterLuch) { iQuery = this._laburnum.AttendanceClass11.Where(x => x.IsPresentAfterLuch == model.IsPresentAfterLuch && x.IsActive == true); } }
            //Search By Date Range.
            if (iQuery != null)
            {
                if (model.StartDate.Year != 0001)
                {
                    model.StartDate = new Component.Utility().GetDate(model.StartDate);
                }
                if (model.EndDate.Year != 0001)
                {
                    model.EndDate = new Component.Utility().GetDate(model.EndDate).AddDays(1).AddSeconds(-1);
                }
                if (model.EndDate.Year == 0001) { model.EndDate = model.StartDate.AddDays(1).AddSeconds(-1); }

                if (model.StartDate.Year != 0001)
                {
                    iQuery = iQuery.Where(x => x.CreatedOn >= model.StartDate && x.CreatedOn <= model.EndDate && x.IsActive == true);
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
                    model.EndDate = new Component.Utility().GetDate(model.EndDate).AddDays(1).AddSeconds(-1);
                }
                if (model.EndDate.Year == 0001) { model.EndDate = model.StartDate.AddDays(1).AddSeconds(-1); }

                if (model.StartDate.Year != 0001)
                {
                    iQuery = this._laburnum.AttendanceClass11.Where(x => x.CreatedOn >= model.StartDate && x.CreatedOn <= model.EndDate && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.AttendanceClass11> dbAttendanceClass1 = iQuery.ToList();
            return dbAttendanceClass1;
        }
    }
}