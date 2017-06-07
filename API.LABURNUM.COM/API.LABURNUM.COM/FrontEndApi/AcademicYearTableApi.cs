using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class AcademicYearTableApi
    {
        private LaburnumEntities _laburnum;

        public AcademicYearTableApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddAcademicYearType(DTO.LABURNUM.COM.AcademicYearTableModel model)
        {
            API.LABURNUM.COM.AcademicYearTable AcademicYearType = new AcademicYearTable()
            {
                AcademicYear = model.AcademicYear,
                StartYear = model.StartYear,
                EndYear = model.EndYear,
                CreatedOn = new Component.Utility().GetISTDateTime(),
                IsActive = true
            };
            this._laburnum.AcademicYearTables.Add(AcademicYearType);
            this._laburnum.SaveChanges();
            return AcademicYearType.AcademicYearTableId;
        }

        private long AddValidation(DTO.LABURNUM.COM.AcademicYearTableModel model)
        {
            model.StartYear.TryValidate();
            model.EndYear.TryValidate();
            return AddAcademicYearType(model);
        }

        public long Add(DTO.LABURNUM.COM.AcademicYearTableModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.AcademicYearTableModel model)
        {
            model.AcademicYearTableId.TryValidate();
            IQueryable<API.LABURNUM.COM.AcademicYearTable> iQuery = this._laburnum.AcademicYearTables.Where(x => x.AcademicYearTableId == model.AcademicYearTableId && x.IsActive == true);
            List<API.LABURNUM.COM.AcademicYearTable> dbAcademicYearTypes = iQuery.ToList();
            if (dbAcademicYearTypes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAcademicYearTypes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAcademicYearTypes[0].StartYear = model.StartYear;
            dbAcademicYearTypes[0].EndYear = model.EndYear;
            dbAcademicYearTypes[0].AcademicYear = model.AcademicYear;
            dbAcademicYearTypes[0].LastUpdated = new Component.Utility().GetISTDateTime();
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.AcademicYearTableModel model)
        {
            model.AcademicYearTableId.TryValidate();
            IQueryable<API.LABURNUM.COM.AcademicYearTable> iQuery = this._laburnum.AcademicYearTables.Where(x => x.AcademicYearTableId == model.AcademicYearTableId && x.IsActive == true);
            List<API.LABURNUM.COM.AcademicYearTable> dbAcademicYearTypes = iQuery.ToList();
            if (dbAcademicYearTypes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAcademicYearTypes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbAcademicYearTypes[0].IsActive = model.IsActive;
            dbAcademicYearTypes[0].LastUpdated = new Component.Utility().GetISTDateTime();
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.AcademicYearTable> GetActiveAcademicYearTypes()
        {
            return this._laburnum.AcademicYearTables.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.AcademicYearTable> GetInActiveAcademicYearTypes()
        {
            return this._laburnum.AcademicYearTables.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.AcademicYearTable> GetAllAcademicYearTypes()
        {
            return this._laburnum.AcademicYearTables.ToList();
        }

        public List<API.LABURNUM.COM.AcademicYearTable> GetAcademicYearTypeByAdvanceSearch(DTO.LABURNUM.COM.AcademicYearTableModel model)
        {
            IQueryable<API.LABURNUM.COM.AcademicYearTable> iQuery = null;
            if (model.AcademicYearTableId > 0)
            {
                iQuery = this._laburnum.AcademicYearTables.Where(x => x.AcademicYearTableId == model.AcademicYearTableId && x.IsActive == true);
            }
            //Search By Start Year.
            if (iQuery != null)
            {
                if (model.StartYear > 0)
                {
                    iQuery = iQuery.Where(x => x.StartYear == model.StartYear && x.IsActive == true);
                }
            }
            else
            {
                if (model.StartYear > 0)
                {
                    iQuery = this._laburnum.AcademicYearTables.Where(x => x.StartYear == model.StartYear && x.IsActive == true);
                }
            }
            //Search By End Year.
            if (iQuery != null)
            {
                if (model.EndYear > 0)
                {
                    iQuery = iQuery.Where(x => x.EndYear == model.EndYear && x.IsActive == true);
                }
            }
            else
            {
                if (model.EndYear > 0)
                {
                    iQuery = this._laburnum.AcademicYearTables.Where(x => x.EndYear == model.EndYear && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.AcademicYearTable> dbAcademicYears = iQuery.ToList();
            return dbAcademicYears;
        }

        public API.LABURNUM.COM.AcademicYearTable GetAcademicYearByYear(int year)
        {
            IQueryable<API.LABURNUM.COM.AcademicYearTable> iQuery = this._laburnum.AcademicYearTables.Where(x => (x.StartYear == year && x.EndYear >= year) && x.IsActive == true);
            List<API.LABURNUM.COM.AcademicYearTable> dbAcademicYears = iQuery.ToList();
            if (dbAcademicYears.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbAcademicYears.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            return dbAcademicYears[0];
        }
    }
}