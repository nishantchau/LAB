using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class AttendanceClass6Api
    {
        private LaburnumEntities _laburnum;

        public AttendanceClass6Api()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddAttendanceClass6(DTO.LABURNUM.COM.AttendanceClass6Model model)
        {
            API.LABURNUM.COM.AttendanceClass6 apiAClass1 = new AttendanceClass6()
            {
                StudentId = model.StudentId,
                ClassId = model.ClassId,
                SectionId = model.SectionId,
                Date = model.Date,
                IsPresent = model.IsPresent,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.AttendanceClass6.Add(apiAClass1);
            this._laburnum.SaveChanges();
            return apiAClass1.AttendanceClass6Id;
        }

        private long AddValidation(DTO.LABURNUM.COM.AttendanceClass6Model model)
        {
            model.TryValidate();
            return AddAttendanceClass6(model);
        }

        public long Add(DTO.LABURNUM.COM.AttendanceClass6Model model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.AttendanceClass6Model model)
        {
            model.AttendanceClass6Id.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClass6> iQuery = this._laburnum.AttendanceClass6.Where(x => x.AttendanceClass6Id == model.AttendanceClass6Id && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClass6> dbAttendanceClass6 = iQuery.ToList();
            if (dbAttendanceClass6.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClass6.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClass6[0].IsPresent = model.IsPresent;
            dbAttendanceClass6[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.AttendanceClass6Model model)
        {
            model.AttendanceClass6Id.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClass6> iQuery = this._laburnum.AttendanceClass6.Where(x => x.AttendanceClass6Id == model.AttendanceClass6Id && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClass6> dbAttendanceClass6 = iQuery.ToList();
            if (dbAttendanceClass6.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClass6.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClass6[0].IsActive = model.IsActive;
            dbAttendanceClass6[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.AttendanceClass6> GetAttendanceClass6ByAdvanceSearch(DTO.LABURNUM.COM.AttendanceClass6Model model)
        {
            IQueryable<API.LABURNUM.COM.AttendanceClass6> iQuery = null;

            if (model.AttendanceClass6Id > 0) { iQuery = this._laburnum.AttendanceClass6.Where(x => x.AttendanceClass6Id == model.AttendanceClass6Id && x.IsActive == true); }
            //Search By Class Id.
            if (iQuery != null) { if (model.ClassId > 0) { iQuery = iQuery.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            else { if (model.ClassId > 0) { iQuery = this._laburnum.AttendanceClass6.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClass6.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClass6.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Student Id.
            if (iQuery != null) { if (model.StudentId > 0) { iQuery = iQuery.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            else { if (model.StudentId > 0) { iQuery = this._laburnum.AttendanceClass6.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            //Search By Present.
            if (iQuery != null) { if (model.IsPresent) { iQuery = iQuery.Where(x => x.IsPresent == model.IsPresent && x.IsActive == true); } }
            else { if (model.IsPresent) { iQuery = this._laburnum.AttendanceClass6.Where(x => x.IsPresent == model.IsPresent && x.IsActive == true); } }
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

            List<API.LABURNUM.COM.AttendanceClass6> dbAttendanceClass6 = iQuery.ToList();
            return dbAttendanceClass6;
        }
    }
}