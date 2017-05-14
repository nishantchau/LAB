﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;
using System.Globalization;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class AttendanceClassUKGApi
    {
        private LaburnumEntities _laburnum;

        public AttendanceClassUKGApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddAttendanceClassUKG(DTO.LABURNUM.COM.AttendanceClassUKGModel model)
        {
            API.LABURNUM.COM.AttendanceClassUKG apiAClass1 = new AttendanceClassUKG()
            {
                StudentId = model.StudentId,
                ClassId = model.ClassId,
                SectionId = model.SectionId,
                Date = model.Date,
                IsPresent = model.IsPresent,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.AttendanceClassUKGs.Add(apiAClass1);
            this._laburnum.SaveChanges();
            return apiAClass1.AttendanceClassUKGId;
        }

        private long AddValidation(DTO.LABURNUM.COM.AttendanceClassUKGModel model)
        {
            model.TryValidate();
            return AddAttendanceClassUKG(model);
        }

        public long Add(DTO.LABURNUM.COM.AttendanceClassUKGModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.AttendanceClassUKGModel model)
        {
            model.AttendanceClassUKGId.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClassUKG> iQuery = this._laburnum.AttendanceClassUKGs.Where(x => x.AttendanceClassUKGId == model.AttendanceClassUKGId && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClassUKG> dbAttendanceClassUKG = iQuery.ToList();
            if (dbAttendanceClassUKG.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClassUKG.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClassUKG[0].IsPresent = model.IsPresent;
            dbAttendanceClassUKG[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.AttendanceClassUKGModel model)
        {
            model.AttendanceClassUKGId.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClassUKG> iQuery = this._laburnum.AttendanceClassUKGs.Where(x => x.AttendanceClassUKGId == model.AttendanceClassUKGId && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClassUKG> dbAttendanceClassUKG = iQuery.ToList();
            if (dbAttendanceClassUKG.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClassUKG.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClassUKG[0].IsActive = model.IsActive;
            dbAttendanceClassUKG[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.AttendanceClassUKG> GetAttendanceClassUKGByAdvanceSearch(DTO.LABURNUM.COM.AttendanceClassUKGModel model)
        {
            IQueryable<API.LABURNUM.COM.AttendanceClassUKG> iQuery = null;

            if (model.AttendanceClassUKGId > 0) { iQuery = this._laburnum.AttendanceClassUKGs.Where(x => x.AttendanceClassUKGId == model.AttendanceClassUKGId && x.IsActive == true); }
            //Search By Class Id.
            if (iQuery != null) { if (model.ClassId > 0) { iQuery = iQuery.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            else { if (model.ClassId > 0) { iQuery = this._laburnum.AttendanceClassUKGs.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClassUKGs.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClassUKGs.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Student Id.
            if (iQuery != null) { if (model.StudentId > 0) { iQuery = iQuery.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            else { if (model.StudentId > 0) { iQuery = this._laburnum.AttendanceClassUKGs.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            //Search By Present.
            if (iQuery != null) { if (model.IsPresent) { iQuery = iQuery.Where(x => x.IsPresent == model.IsPresent && x.IsActive == true); } }
            else { if (model.IsPresent) { iQuery = this._laburnum.AttendanceClassUKGs.Where(x => x.IsPresent == model.IsPresent && x.IsActive == true); } }
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
                    iQuery = this._laburnum.AttendanceClassUKGs.Where(x => x.Date >= model.StartDate && x.Date <= model.EndDate && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.AttendanceClassUKG> dbAttendanceClassUKG = iQuery.ToList();
            return dbAttendanceClassUKG;
        }
    }
}