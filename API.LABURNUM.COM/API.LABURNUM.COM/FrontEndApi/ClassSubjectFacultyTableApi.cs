using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class ClassSubjectFacultyTableApi
    {
        private LaburnumEntities _laburnum;

        public ClassSubjectFacultyTableApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddClassSubjectFacultyTable(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            API.LABURNUM.COM.ClassSubjectFacultyTable apiClassSubjectFacultyTable = new ClassSubjectFacultyTable()
            {
                ClassId = model.ClassId,
                SubjectId = model.SubjectId,
                FacultyId = model.FacultyId,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.ClassSubjectFacultyTables.Add(apiClassSubjectFacultyTable);
            this._laburnum.SaveChanges();
            return apiClassSubjectFacultyTable.ClassSubjectFacultyTableId;
        }

        //private long AddValidation(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        //{
        //    model.BusStartFrom.TryValidate();
        //    model.ClassSubjectFacultyTableNumber.TryValidate();
        //    model.BusEndAt.TryValidate();
        //    return AddClassSubjectFacultyTable(model);
        //}

        //public long Add(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        //{
        //    return AddValidation(model);
        //}

        //public void Update(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        //{
        //    model.ClassSubjectFacultyTableId.TryValidate();
        //    IQueryable<API.LABURNUM.COM.ClassSubjectFacultyTable> iQuery = this._laburnum.ClassSubjectFacultyTables.Where(x => x.ClassSubjectFacultyTableId == model.ClassSubjectFacultyTableId && x.IsActive == true);
        //    List<API.LABURNUM.COM.ClassSubjectFacultyTable> dbRoutes = iQuery.ToList();
        //    if (dbRoutes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
        //    if (dbRoutes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
        //    dbRoutes[0].BusStartFrom = model.BusStartFrom;
        //    dbRoutes[0].BusEndAt = model.BusEndAt;
        //    dbRoutes[0].ClassSubjectFacultyTableNumber = model.ClassSubjectFacultyTableNumber;
        //    dbRoutes[0].TranportCharges = model.TranportCharges;
        //    dbRoutes[0].LastUpdate = System.DateTime.Now;
        //    this._laburnum.SaveChanges();
        //}

        //public void UpdateIsActive(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        //{
        //    model.ClassSubjectFacultyTableId.TryValidate();
        //    IQueryable<API.LABURNUM.COM.ClassSubjectFacultyTable> iQuery = this._laburnum.ClassSubjectFacultyTables.Where(x => x.ClassSubjectFacultyTableId == model.ClassSubjectFacultyTableId && x.IsActive == true);
        //    List<API.LABURNUM.COM.ClassSubjectFacultyTable> dbRoutes = iQuery.ToList();
        //    if (dbRoutes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
        //    if (dbRoutes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
        //    dbRoutes[0].IsActive = model.IsActive;
        //    dbRoutes[0].LastUpdate = System.DateTime.Now;
        //    this._laburnum.SaveChanges();
        //}

        //public List<API.LABURNUM.COM.ClassSubjectFacultyTable> GetActiveClassSubjectFacultyTables()
        //{
        //    return this._laburnum.ClassSubjectFacultyTables.Where(x => x.IsActive == true).ToList();
        //}

        //public List<API.LABURNUM.COM.ClassSubjectFacultyTable> GetInActiveClassSubjectFacultyTables()
        //{
        //    return this._laburnum.ClassSubjectFacultyTables.Where(x => x.IsActive == false).ToList();
        //}

        //public List<API.LABURNUM.COM.ClassSubjectFacultyTable> GetAllClassSubjectFacultyTables()
        //{
        //    return this._laburnum.ClassSubjectFacultyTables.ToList();
        //}

        //public List<API.LABURNUM.COM.ClassSubjectFacultyTable> GetClassSubjectFacultyTableByAdvanceSearch(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        //{
        //    IQueryable<API.LABURNUM.COM.ClassSubjectFacultyTable> iQuery = null;

        //    //Search Bus Route Id.
        //    if (model.ClassSubjectFacultyTableId > 0)
        //    {
        //        iQuery = this._laburnum.ClassSubjectFacultyTables.Where(x => x.ClassSubjectFacultyTableId == model.ClassSubjectFacultyTableId && x.IsActive == true);
        //    }

        //    //Search Bus Number.
        //    if (iQuery != null)
        //    {
        //        if (model.ClassSubjectFacultyTableNumber != null)
        //        {
        //            iQuery = iQuery.Where(x => x.ClassSubjectFacultyTableNumber.Trim().ToLower().Equals(model.ClassSubjectFacultyTableNumber.Trim().ToLower()) && x.IsActive == true);
        //        }
        //    }
        //    else
        //    {
        //        if (model.ClassSubjectFacultyTableNumber != null)
        //        {
        //            iQuery = this._laburnum.ClassSubjectFacultyTables.Where(x => x.ClassSubjectFacultyTableNumber.Trim().ToLower().Equals(model.ClassSubjectFacultyTableNumber.Trim().ToLower()) && x.IsActive == true);
        //        }
        //    }

        //    //Search Bus Start From.
        //    if (iQuery != null)
        //    {
        //        if (model.BusStartFrom != null)
        //        {
        //            iQuery = iQuery.Where(x => x.BusStartFrom.Trim().ToLower().Contains(model.BusStartFrom.Trim().ToLower()) && x.IsActive == true);
        //        }
        //    }
        //    else
        //    {
        //        if (model.BusStartFrom != null)
        //        {
        //            iQuery = this._laburnum.ClassSubjectFacultyTables.Where(x => x.BusStartFrom.Trim().ToLower().Contains(model.BusStartFrom.Trim().ToLower()) && x.IsActive == true);
        //        }
        //    }

        //    //Search Bus End At.
        //    if (iQuery != null)
        //    {
        //        if (model.BusEndAt != null)
        //        {
        //            iQuery = iQuery.Where(x => x.BusEndAt.Trim().ToLower().Contains(model.BusEndAt.Trim().ToLower()) && x.IsActive == true);
        //        }
        //    }
        //    else
        //    {
        //        if (model.BusEndAt != null)
        //        {
        //            iQuery = this._laburnum.ClassSubjectFacultyTables.Where(x => x.BusEndAt.Trim().ToLower().Contains(model.BusEndAt.Trim().ToLower()) && x.IsActive == true);
        //        }
        //    }

        //    List<API.LABURNUM.COM.ClassSubjectFacultyTable> dbClassSubjectFacultyTable = iQuery.ToList();
        //    return dbClassSubjectFacultyTable;
        //}
    }
}