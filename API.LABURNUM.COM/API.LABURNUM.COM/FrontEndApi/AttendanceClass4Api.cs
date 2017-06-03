﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;
using System.Globalization;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class AttendanceClass4Api
    {
        private LaburnumEntities _laburnum;

        public AttendanceClass4Api()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddAttendanceClass4(DTO.LABURNUM.COM.AttendanceClass4Model model)
        {
            API.LABURNUM.COM.AttendanceClass4 apiAClass1 = new AttendanceClass4()
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
            this._laburnum.AttendanceClass4.Add(apiAClass1);
            this._laburnum.SaveChanges();
            return apiAClass1.AttendanceClass4Id;
        }

        private long AddValidation(DTO.LABURNUM.COM.AttendanceClass4Model model)
        {
            model.TryValidate();
            return AddAttendanceClass4(model);
        }

        public long Add(DTO.LABURNUM.COM.AttendanceClass4Model model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.AttendanceClass4Model model)
        {
            model.AttendanceClass4Id.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClass4> iQuery = this._laburnum.AttendanceClass4.Where(x => x.AttendanceClass4Id == model.AttendanceClass4Id && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClass4> dbAttendanceClass4 = iQuery.ToList();
            if (dbAttendanceClass4.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClass4.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClass4[0].IsPresentAfterLuch = model.IsPresentAfterLuch;
            dbAttendanceClass4[0].LunchAttendanceDate = System.DateTime.Now;
            dbAttendanceClass4[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.AttendanceClass4Model model)
        {
            model.AttendanceClass4Id.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClass4> iQuery = this._laburnum.AttendanceClass4.Where(x => x.AttendanceClass4Id == model.AttendanceClass4Id && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClass4> dbAttendanceClass4 = iQuery.ToList();
            if (dbAttendanceClass4.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClass4.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClass4[0].IsActive = model.IsActive;
            dbAttendanceClass4[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.AttendanceClass4> GetAttendanceClass4ByAdvanceSearch(DTO.LABURNUM.COM.AttendanceClass4Model model)
        {
            IQueryable<API.LABURNUM.COM.AttendanceClass4> iQuery = null;

            if (model.AttendanceClass4Id > 0) { iQuery = this._laburnum.AttendanceClass4.Where(x => x.AttendanceClass4Id == model.AttendanceClass4Id && x.IsActive == true); }
            //Search By Class Id.
            if (iQuery != null) { if (model.ClassId > 0) { iQuery = iQuery.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            else { if (model.ClassId > 0) { iQuery = this._laburnum.AttendanceClass4.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClass4.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClass4.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Student Id.
            if (iQuery != null) { if (model.StudentId > 0) { iQuery = iQuery.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            else { if (model.StudentId > 0) { iQuery = this._laburnum.AttendanceClass4.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            //Search By IsPresentInMorning.
            if (iQuery != null) { if (model.IsPresentInMorning) { iQuery = iQuery.Where(x => x.IsPresentInMorning == model.IsPresentInMorning && x.IsActive == true); } }
            else { if (model.IsPresentInMorning) { iQuery = this._laburnum.AttendanceClass4.Where(x => x.IsPresentInMorning == model.IsPresentInMorning && x.IsActive == true); } }
            //Search By IsPresentAfterLuch.
            if (iQuery != null) { if (model.IsPresentAfterLuch) { iQuery = iQuery.Where(x => x.IsPresentAfterLuch == model.IsPresentAfterLuch && x.IsActive == true); } }
            else { if (model.IsPresentAfterLuch) { iQuery = this._laburnum.AttendanceClass4.Where(x => x.IsPresentAfterLuch == model.IsPresentAfterLuch && x.IsActive == true); } }
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
                    iQuery = this._laburnum.AttendanceClass4.Where(x => x.CreatedOn >= model.StartDate && x.CreatedOn <= model.EndDate && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.AttendanceClass4> dbAttendanceClass4 = iQuery.ToList();
            return dbAttendanceClass4;
        }
    }
}