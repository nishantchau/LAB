using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

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
                SectionId = model.SectionId,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.ClassSubjectFacultyTables.Add(apiClassSubjectFacultyTable);
            this._laburnum.SaveChanges();
            return apiClassSubjectFacultyTable.ClassSubjectFacultyTableId;
        }

        private long AddValidation(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            model.ClassId.TryValidate();
            model.SubjectId.TryValidate();
            model.FacultyId.TryValidate();
            model.SectionId.TryValidate();
            return AddClassSubjectFacultyTable(model);
        }

        public long Add(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            model.ClassSubjectFacultyTableId.TryValidate();
            IQueryable<API.LABURNUM.COM.ClassSubjectFacultyTable> iQuery = this._laburnum.ClassSubjectFacultyTables.Where(x => x.ClassSubjectFacultyTableId == model.ClassSubjectFacultyTableId && x.IsActive == true);
            List<API.LABURNUM.COM.ClassSubjectFacultyTable> dbRoutes = iQuery.ToList();
            if (dbRoutes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbRoutes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbRoutes[0].ClassId = model.ClassId;
            dbRoutes[0].SubjectId = model.SubjectId;
            dbRoutes[0].FacultyId = model.FacultyId;
            dbRoutes[0].SectionId = model.SectionId;
            dbRoutes[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            model.ClassSubjectFacultyTableId.TryValidate();
            IQueryable<API.LABURNUM.COM.ClassSubjectFacultyTable> iQuery = this._laburnum.ClassSubjectFacultyTables.Where(x => x.ClassSubjectFacultyTableId == model.ClassSubjectFacultyTableId && x.IsActive == true);
            List<API.LABURNUM.COM.ClassSubjectFacultyTable> dbRoutes = iQuery.ToList();
            if (dbRoutes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbRoutes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbRoutes[0].IsActive = model.IsActive;
            dbRoutes[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.ClassSubjectFacultyTable> GetActiveClassSubjectFacultyTables()
        {
            return this._laburnum.ClassSubjectFacultyTables.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.ClassSubjectFacultyTable> GetInActiveClassSubjectFacultyTables()
        {
            return this._laburnum.ClassSubjectFacultyTables.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.ClassSubjectFacultyTable> GetAllClassSubjectFacultyTables()
        {
            return this._laburnum.ClassSubjectFacultyTables.ToList();
        }

        public List<API.LABURNUM.COM.ClassSubjectFacultyTable> GetClassSubjectFacultyTableByAdvanceSearch(DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model)
        {
            IQueryable<API.LABURNUM.COM.ClassSubjectFacultyTable> iQuery = null;

            //Search Bus Route Id.
            if (model.ClassSubjectFacultyTableId > 0)
            {
                iQuery = this._laburnum.ClassSubjectFacultyTables.Where(x => x.ClassSubjectFacultyTableId == model.ClassSubjectFacultyTableId && x.IsActive == true);
            }

            //Search By ClassId
            if (iQuery != null)
            {
                if (model.ClassId > 0)
                {
                    iQuery = iQuery.Where(x => x.ClassId == model.ClassId && x.IsActive == true);
                }
            }
            else
            {
                if (model.ClassId > 0)
                {
                    iQuery = this._laburnum.ClassSubjectFacultyTables.Where(x => x.ClassId == model.ClassId && x.IsActive == true);
                }
            }

            //Search By SectionId
            if (iQuery != null)
            {
                if (model.SectionId > 0)
                {
                    iQuery = iQuery.Where(x => x.SectionId == model.SectionId && x.IsActive == true);
                }
            }
            else
            {
                if (model.SectionId > 0)
                {
                    iQuery = this._laburnum.ClassSubjectFacultyTables.Where(x => x.SectionId == model.SectionId && x.IsActive == true);
                }
            }

            //Search ByFacultyId
            if (iQuery != null)
            {
                if (model.FacultyId > 0)
                {
                    iQuery = iQuery.Where(x => x.FacultyId == model.FacultyId && x.IsActive == true);
                }
            }
            else
            {
                if (model.FacultyId > 0)
                {
                    iQuery = this._laburnum.ClassSubjectFacultyTables.Where(x => x.FacultyId == model.FacultyId && x.IsActive == true);
                }
            }

            //Search By SubjectId.
            if (iQuery != null)
            {
                if (model.SubjectId > 0)
                {
                    iQuery = iQuery.Where(x => x.SubjectId == model.SubjectId && x.IsActive == true);
                }
            }
            else
            {
                if (model.SubjectId > 0)
                {
                    iQuery = this._laburnum.ClassSubjectFacultyTables.Where(x => x.SubjectId == model.SubjectId && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.ClassSubjectFacultyTable> dbClassSubjectFacultyTable = iQuery.ToList();
            return dbClassSubjectFacultyTable;
        }
    }
}