﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;
using System.Globalization;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class AttendanceClassLKGApi
    {
        private LaburnumEntities _laburnum;

        public AttendanceClassLKGApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddAttendanceClassLKG(DTO.LABURNUM.COM.AttendanceClassLKGModel model)
        {
            API.LABURNUM.COM.AttendanceClassLKG apiAClass1 = new AttendanceClassLKG()
            {
                StudentId = model.StudentId,
                ClassId = model.ClassId,
                SectionId = model.SectionId,
                MorningAttendanceDate = model.MorningAttendanceDate,
                IsPresentAfterLuch = model.IsPresentAfterLuch,
                IsPresentInMorning = model.IsPresentInMorning,
                CreatedOn = new Component.Utility().GetISTDateTime(),
                FacultyId = model.FacultyId,
                IsActive = true
            };
            this._laburnum.AttendanceClassLKGs.Add(apiAClass1);
            this._laburnum.SaveChanges();
            return apiAClass1.AttendanceClassLKGId;
        }

        private long AddValidation(DTO.LABURNUM.COM.AttendanceClassLKGModel model)
        {
            model.TryValidate();
            return AddAttendanceClassLKG(model);
        }

        public long Add(DTO.LABURNUM.COM.AttendanceClassLKGModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.AttendanceClassLKGModel model)
        {
            model.AttendanceClassLKGId.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClassLKG> iQuery = this._laburnum.AttendanceClassLKGs.Where(x => x.AttendanceClassLKGId == model.AttendanceClassLKGId && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClassLKG> dbAttendanceClassLKG = iQuery.ToList();
            if (dbAttendanceClassLKG.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClassLKG.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClassLKG[0].IsPresentAfterLuch = model.IsPresentAfterLuch;
            dbAttendanceClassLKG[0].LunchAttendanceDate = new Component.Utility().GetISTDateTime();
            dbAttendanceClassLKG[0].LastUpdated = new Component.Utility().GetISTDateTime();
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.AttendanceClassLKGModel model)
        {
            model.AttendanceClassLKGId.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClassLKG> iQuery = this._laburnum.AttendanceClassLKGs.Where(x => x.AttendanceClassLKGId == model.AttendanceClassLKGId && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClassLKG> dbAttendanceClassLKG = iQuery.ToList();
            if (dbAttendanceClassLKG.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClassLKG.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClassLKG[0].IsActive = model.IsActive;
            dbAttendanceClassLKG[0].LastUpdated = new Component.Utility().GetISTDateTime();
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.AttendanceClassLKG> GetAttendanceClassLKGByAdvanceSearch(DTO.LABURNUM.COM.AttendanceClassLKGModel model)
        {
            IQueryable<API.LABURNUM.COM.AttendanceClassLKG> iQuery = null;

            if (model.AttendanceClassLKGId > 0) { iQuery = this._laburnum.AttendanceClassLKGs.Where(x => x.AttendanceClassLKGId == model.AttendanceClassLKGId && x.IsActive == true); }
            //Search By Class Id.
            if (iQuery != null) { if (model.ClassId > 0) { iQuery = iQuery.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            else { if (model.ClassId > 0) { iQuery = this._laburnum.AttendanceClassLKGs.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClassLKGs.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClassLKGs.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Student Id.
            if (iQuery != null) { if (model.StudentId > 0) { iQuery = iQuery.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            else { if (model.StudentId > 0) { iQuery = this._laburnum.AttendanceClassLKGs.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            //Search By IsPresentInMorning.
            if (iQuery != null) { if (model.IsPresentInMorning) { iQuery = iQuery.Where(x => x.IsPresentInMorning == model.IsPresentInMorning && x.IsActive == true); } }
            else { if (model.IsPresentInMorning) { iQuery = this._laburnum.AttendanceClassLKGs.Where(x => x.IsPresentInMorning == model.IsPresentInMorning && x.IsActive == true); } }
            //Search By IsPresentAfterLuch.
            if (iQuery != null) { if (model.IsPresentAfterLuch) { iQuery = iQuery.Where(x => x.IsPresentAfterLuch == model.IsPresentAfterLuch && x.IsActive == true); } }
            else { if (model.IsPresentAfterLuch) { iQuery = this._laburnum.AttendanceClassLKGs.Where(x => x.IsPresentAfterLuch == model.IsPresentAfterLuch && x.IsActive == true); } }
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
                    iQuery = this._laburnum.AttendanceClassLKGs.Where(x => x.CreatedOn >= model.StartDate && x.CreatedOn <= model.EndDate && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.AttendanceClassLKG> dbAttendanceClassLKG = iQuery.ToList();
            return dbAttendanceClassLKG;
        }
    }
}