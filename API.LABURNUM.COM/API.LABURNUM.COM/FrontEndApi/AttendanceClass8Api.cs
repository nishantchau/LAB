﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;
using System.Globalization;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class AttendanceClass8Api
    {
        private LaburnumEntities _laburnum;

        public AttendanceClass8Api()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddAttendanceClass8(DTO.LABURNUM.COM.AttendanceClass8Model model)
        {
            API.LABURNUM.COM.AttendanceClass8 apiAClass1 = new AttendanceClass8()
            {
                StudentId = model.StudentId,
                ClassId = model.ClassId,
                SectionId = model.SectionId,
                Date = model.Date,
                IsPresent = model.IsPresent,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.AttendanceClass8.Add(apiAClass1);
            this._laburnum.SaveChanges();
            return apiAClass1.AttendanceClass8Id;
        }

        private long AddValidation(DTO.LABURNUM.COM.AttendanceClass8Model model)
        {
            model.TryValidate();
            return AddAttendanceClass8(model);
        }

        public long Add(DTO.LABURNUM.COM.AttendanceClass8Model model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.AttendanceClass8Model model)
        {
            model.AttendanceClass8Id.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClass8> iQuery = this._laburnum.AttendanceClass8.Where(x => x.AttendanceClass8Id == model.AttendanceClass8Id && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClass8> dbAttendanceClass8 = iQuery.ToList();
            if (dbAttendanceClass8.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClass8.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClass8[0].IsPresent = model.IsPresent;
            dbAttendanceClass8[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.AttendanceClass8Model model)
        {
            model.AttendanceClass8Id.TryValidate();
            IQueryable<API.LABURNUM.COM.AttendanceClass8> iQuery = this._laburnum.AttendanceClass8.Where(x => x.AttendanceClass8Id == model.AttendanceClass8Id && x.IsActive == true);
            List<API.LABURNUM.COM.AttendanceClass8> dbAttendanceClass8 = iQuery.ToList();
            if (dbAttendanceClass8.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAttendanceClass8.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAttendanceClass8[0].IsActive = model.IsActive;
            dbAttendanceClass8[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.AttendanceClass8> GetAttendanceClass8ByAdvanceSearch(DTO.LABURNUM.COM.AttendanceClass8Model model)
        {
            IQueryable<API.LABURNUM.COM.AttendanceClass8> iQuery = null;

            if (model.AttendanceClass8Id > 0) { iQuery = this._laburnum.AttendanceClass8.Where(x => x.AttendanceClass8Id == model.AttendanceClass8Id && x.IsActive == true); }
            //Search By Class Id.
            if (iQuery != null) { if (model.ClassId > 0) { iQuery = iQuery.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            else { if (model.ClassId > 0) { iQuery = this._laburnum.AttendanceClass8.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClass8.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Section Id.
            if (iQuery != null) { if (model.SectionId > 0) { iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            else { if (model.SectionId > 0) { iQuery = this._laburnum.AttendanceClass8.Where(x => x.SectionId == model.SectionId && x.IsActive == true); } }
            //Search By Student Id.
            if (iQuery != null) { if (model.StudentId > 0) { iQuery = iQuery.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            else { if (model.StudentId > 0) { iQuery = this._laburnum.AttendanceClass8.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            //Search By Present.
            if (iQuery != null) { if (model.IsPresent) { iQuery = iQuery.Where(x => x.IsPresent == model.IsPresent && x.IsActive == true); } }
            else { if (model.IsPresent) { iQuery = this._laburnum.AttendanceClass8.Where(x => x.IsPresent == model.IsPresent && x.IsActive == true); } }
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
                    iQuery = iQuery.Where(x => x.Date >= model.StartDate && x.Date <= model.EndDate && x.IsActive == true);
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
                    iQuery = iQuery.Where(x => x.Date >= model.StartDate && x.Date <= model.EndDate && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.AttendanceClass8> dbAttendanceClass8 = iQuery.ToList();
            return dbAttendanceClass8;
        }
    }
}