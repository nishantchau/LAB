using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;
using System.Globalization;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class CircularNotificationTableApi
    {
        private LaburnumEntities _laburnum;

        public CircularNotificationTableApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddCircularNotificationTable(DTO.LABURNUM.COM.CircularNotificationTableModel model)
        {
            API.LABURNUM.COM.CircularNotificationTable apiCircularNotificationTable = new CircularNotificationTable()
            {
                CircularId = model.CircularId,
                ClassIds = model.ClassIds,
                IsForAdmin = model.IsForAdmin,
                IsForFaculty = model.IsForFaculty,
                IsForParents = model.IsForParents,
                IsForStudent = model.IsForStudent,
                LastUpdated = model.LastUpdated,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.CircularNotificationTables.Add(apiCircularNotificationTable);
            this._laburnum.SaveChanges();
            return apiCircularNotificationTable.CircularNotificationTableId;
        }

        private long AddValidation(DTO.LABURNUM.COM.CircularNotificationTableModel model)
        {
            model.CircularId.TryValidate();
            return AddCircularNotificationTable(model);
        }

        public long Add(DTO.LABURNUM.COM.CircularNotificationTableModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.CircularNotificationTableModel model)
        {
            model.CircularNotificationTableId.TryValidate();
            IQueryable<API.LABURNUM.COM.CircularNotificationTable> iQuery = this._laburnum.CircularNotificationTables.Where(x => x.CircularNotificationTableId == model.CircularNotificationTableId && x.IsActive == true);
            List<API.LABURNUM.COM.CircularNotificationTable> dbRoutes = iQuery.ToList();
            if (dbRoutes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbRoutes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbRoutes[0].ClassIds = model.ClassIds;
            dbRoutes[0].CircularId = model.CircularId;
            dbRoutes[0].IsForAdmin = model.IsForAdmin;
            dbRoutes[0].IsForFaculty = model.IsForFaculty;
            dbRoutes[0].IsForParents = model.IsForParents;
            dbRoutes[0].IsForStudent = model.IsForStudent;
            dbRoutes[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.CircularNotificationTableModel model)
        {
            model.CircularNotificationTableId.TryValidate();
            IQueryable<API.LABURNUM.COM.CircularNotificationTable> iQuery = this._laburnum.CircularNotificationTables.Where(x => x.CircularNotificationTableId == model.CircularNotificationTableId && x.IsActive == true);
            List<API.LABURNUM.COM.CircularNotificationTable> dbRoutes = iQuery.ToList();
            if (dbRoutes.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbRoutes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbRoutes[0].IsActive = model.IsActive;
            dbRoutes[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.CircularNotificationTable> GetActiveCircularNotificationTables()
        {
            return this._laburnum.CircularNotificationTables.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.CircularNotificationTable> GetInActiveCircularNotificationTables()
        {
            return this._laburnum.CircularNotificationTables.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.CircularNotificationTable> GetAllCircularNotificationTables()
        {
            return this._laburnum.CircularNotificationTables.ToList();
        }

        public List<API.LABURNUM.COM.CircularNotificationTable> GetCircularNotificationTableByAdvanceSearch(DTO.LABURNUM.COM.CircularNotificationTableModel model)
        {
            IQueryable<API.LABURNUM.COM.CircularNotificationTable> iQuery = null;

            //Search CircularNotificationTableId.
            if (model.CircularNotificationTableId > 0)
            {
                iQuery = this._laburnum.CircularNotificationTables.Where(x => x.CircularNotificationTableId == model.CircularNotificationTableId && x.IsActive == true);
            }


            //Search For Admin.
            if (iQuery != null)
            {
                if (model.IsForAdmin == true)
                {
                    iQuery = iQuery.Where(x => x.IsForAdmin == model.IsForAdmin && x.IsActive == true);
                }
            }
            else
            {
                if (model.IsForAdmin == true)
                {
                    iQuery = this._laburnum.CircularNotificationTables.Where(x => x.IsForAdmin == model.IsForAdmin && x.IsActive == true);
                }
            }

            //Search For IsForFaculty.
            if (iQuery != null)
            {
                if (model.IsForFaculty == true)
                {
                    iQuery = iQuery.Where(x => x.IsForFaculty == model.IsForFaculty && x.IsActive == true);
                }
            }
            else
            {
                if (model.IsForFaculty == true)
                {
                    iQuery = this._laburnum.CircularNotificationTables.Where(x => x.IsForFaculty == model.IsForFaculty && x.IsActive == true);
                }
            }

            //Search For IsForParents.
            if (iQuery != null)
            {
                if (model.IsForParents == true)
                {
                    iQuery = iQuery.Where(x => x.IsForParents == model.IsForParents && x.IsActive == true);
                }
            }
            else
            {
                if (model.IsForAdmin == true)
                {
                    iQuery = this._laburnum.CircularNotificationTables.Where(x => x.IsForParents == model.IsForParents && x.IsActive == true);
                }
            }

            //Search For IsForStudent.
            if (iQuery != null)
            {
                if (model.IsForStudent == true)
                {
                    iQuery = iQuery.Where(x => x.IsForStudent == model.IsForStudent && x.IsActive == true);
                }
            }
            else
            {
                if (model.IsForStudent == true)
                {
                    iQuery = this._laburnum.CircularNotificationTables.Where(x => x.IsForStudent == model.IsForStudent && x.IsActive == true);
                }
            }


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
                    iQuery = this._laburnum.CircularNotificationTables.Where(x => x.CreatedOn >= model.StartDate && x.CreatedOn <= model.EndDate && x.IsActive == true);

                }
            }

            List<API.LABURNUM.COM.CircularNotificationTable> dbCircularNotificationTable = iQuery.ToList();
            return dbCircularNotificationTable;
        }
    }
}