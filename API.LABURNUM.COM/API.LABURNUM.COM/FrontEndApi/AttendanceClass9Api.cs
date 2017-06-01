using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;
using System.Globalization;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class AttendanceClass9Api
    {
        private LaburnumEntities _laburnum;

        public AttendanceClass9Api()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddAttendanceClass9(DTO.LABURNUM.COM.AttendanceClass9Model model)
        {
            API.LABURNUM.COM.AttendanceClass9 apiAClass1 = new AttendanceClass9()
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
            this._laburnum.AttendanceClass9.Add(apiAClass1);
            this._laburnum.SaveChanges();
            return apiAClass1.AttendanceClass9Id;
        }

        private long AddValidation(DTO.LABURNUM.COM.AttendanceClass9Model model)
        {
            model.TryValidate();
            return AddAttendanceClass9(model);
        }

        public long Add(DTO.LABURNUM.COM.AttendanceClass9Model model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.AttendanceClass9Model model)
        {
            model.AttendanceClass9Id.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClass9> iQuery = this._laburnum.AttendanceClass9.Where(x => x.AttendanceClass9Id == model.AttendanceClass9Id && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClass9> dbAttendanceClass9 = iQuery.ToList();
            if (dbAttendanceClass9.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClass9.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClass9[0].IsPresentAfterLuch = model.IsPresentAfterLuch;
            dbAttendanceClass9[0].LunchAttendanceDate = model.LunchAttendanceDate;
            dbAttendanceClass9[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.AttendanceClass9Model model)
        {
            model.AttendanceClass9Id.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClass9> iQuery = this._laburnum.AttendanceClass9.Where(x => x.AttendanceClass9Id == model.AttendanceClass9Id && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClass9> dbAttendanceClass9 = iQuery.ToList();
            if (dbAttendanceClass9.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClass9.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClass9[0].IsActive = model.IsActive;
            dbAttendanceClass9[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.AttendanceClass9> GetAttendanceClass9ByAdvanceSearch(DTO.LABURNUM.COM.AttendanceClass9Model model)
        {
            IQueryable<API.LABURNUM.COM.AttendanceClass9> iQuery = null;

            if (model.AttendanceClass9Id > 0) { iQuery = this._laburnum.AttendanceClass9.Where(x => x.AttendanceClass9Id == model.AttendanceClass9Id && x.IsActive == true); }
            //Search By Class Id.
            if (iQuery != null) { if (model.ClassId > 0) { iQuery = iQuery.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            else { if (model.ClassId > 0) { iQuery = this._laburnum.AttendanceClass9.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClass9.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClass9.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Student Id.
            if (iQuery != null) { if (model.StudentId > 0) { iQuery = iQuery.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            else { if (model.StudentId > 0) { iQuery = this._laburnum.AttendanceClass9.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            //Search By IsPresentInMorning.
            if (iQuery != null) { if (model.IsPresentInMorning) { iQuery = iQuery.Where(x => x.IsPresentInMorning == model.IsPresentInMorning && x.IsActive == true); } }
            else { if (model.IsPresentInMorning) { iQuery = this._laburnum.AttendanceClass9.Where(x => x.IsPresentInMorning == model.IsPresentInMorning && x.IsActive == true); } }
            //Search By IsPresentAfterLuch.
            if (iQuery != null) { if (model.IsPresentAfterLuch) { iQuery = iQuery.Where(x => x.IsPresentAfterLuch == model.IsPresentAfterLuch && x.IsActive == true); } }
            else { if (model.IsPresentAfterLuch) { iQuery = this._laburnum.AttendanceClass9.Where(x => x.IsPresentAfterLuch == model.IsPresentAfterLuch && x.IsActive == true); } }
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
                    model.EndDate = new Component.Utility().GetDate(model.EndDate);
                }
                if (model.EndDate.Year == 0001) { model.EndDate = model.StartDate.AddDays(1).AddSeconds(-1); }

                if (model.StartDate.Year != 0001)
                {
                    iQuery = this._laburnum.AttendanceClass9.Where(x => x.CreatedOn >= model.StartDate && x.CreatedOn <= model.EndDate && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.AttendanceClass9> dbAttendanceClass9 = iQuery.ToList();
            return dbAttendanceClass9;
        }
    }
}