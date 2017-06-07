using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class ClassApi
    {
        private LaburnumEntities _laburnum;

        public ClassApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddClass(DTO.LABURNUM.COM.ClassModel model)
        {
            API.LABURNUM.COM.Class apiclass = new Class()
            {
                ClassName = model.ClassName,
                CreatedOn = new Component.Utility().GetISTDateTime(),
                IsActive = true
            };
            this._laburnum.Classes.Add(apiclass);
            this._laburnum.SaveChanges();
            return apiclass.ClassId;
        }

        private long AddValidation(DTO.LABURNUM.COM.ClassModel model)
        {
            model.ClassName.TryValidate();
            return AddClass(model);
        }

        public long Add(DTO.LABURNUM.COM.ClassModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.ClassModel model)
        {
            model.ClassId.TryValidate();
            IQueryable<API.LABURNUM.COM.Class> iQuery = this._laburnum.Classes.Where(x => x.ClassId == model.ClassId && x.IsActive == true);
            List<API.LABURNUM.COM.Class> dbClasses = iQuery.ToList();
            if (dbClasses.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbClasses.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbClasses[0].ClassName = model.ClassName;
            dbClasses[0].LastUpdated = new Component.Utility().GetISTDateTime();
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.ClassModel model)
        {
            model.ClassId.TryValidate();
            IQueryable<API.LABURNUM.COM.Class> iQuery = this._laburnum.Classes.Where(x => x.ClassId == model.ClassId && x.IsActive == true);
            List<API.LABURNUM.COM.Class> dbClasses = iQuery.ToList();
            if (dbClasses.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbClasses.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbClasses[0].IsActive = model.IsActive;
            dbClasses[0].LastUpdated = new Component.Utility().GetISTDateTime();
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.Class> GetActiveClass()
        {
            return this._laburnum.Classes.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.Class> GetInActiveClass()
        {
            return this._laburnum.Classes.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.Class> GetAllClass()
        {
            return this._laburnum.Classes.ToList();
        }

        public List<API.LABURNUM.COM.Class> GetClassByAdvanceSearch(DTO.LABURNUM.COM.ClassModel model)
        {
            IQueryable<API.LABURNUM.COM.Class> iQuery = null;
            if (model.ClassId > 0)
            {
                iQuery = this._laburnum.Classes.Where(x => x.ClassId == model.ClassId && x.IsActive == true);
            }
            if (iQuery != null)
            {
                if (model.ClassName != null)
                {
                    iQuery = iQuery.Where(x => x.ClassName.Trim().ToLower().Equals(model.ClassName.Trim().ToLower()) && x.IsActive == true);
                }
            }
            else
            {
                if (model.ClassName != null)
                {
                    iQuery = this._laburnum.Classes.Where(x => x.ClassName.Trim().ToLower().Equals(model.ClassName.Trim().ToLower()) && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.Class> dbClasses = iQuery.ToList();
            return dbClasses;
        }
    }
}