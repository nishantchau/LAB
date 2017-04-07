using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class LoginActivityApi
    {
        private LaburnumEntities _laburnum;

        public LoginActivityApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddLoginActivity(DTO.LABURNUM.COM.LoginActivityModel model)
        {
            API.LABURNUM.COM.LoginActivity apiLoginActivity = new LoginActivity()
            {
                StudentId = model.StudentId,
                UserTypeId = model.UserTypeId,
                LoginAt = System.DateTime.Now,
                ClientId = model.ClientId,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.LoginActivities.Add(apiLoginActivity);
            this._laburnum.SaveChanges();
            return apiLoginActivity.LoginActivityId;
        }

        private long AddValidation(DTO.LABURNUM.COM.LoginActivityModel model)
        {
            model.StudentId.TryValidate();
            model.ClientId.TryValidate();
            return AddLoginActivity(model);
        }

        public long Add(DTO.LABURNUM.COM.LoginActivityModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.LoginActivityModel model)
        {
            model.LoginActivityId.TryValidate();
            IQueryable<API.LABURNUM.COM.LoginActivity> iQuery = this._laburnum.LoginActivities.Where(x => x.LoginActivityId == model.LoginActivityId && x.IsActive == true);
            List<API.LABURNUM.COM.LoginActivity> dbLoginActivities = iQuery.ToList();
            if (dbLoginActivities.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbLoginActivities.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbLoginActivities[0].LogoutAt = System.DateTime.Now;
            dbLoginActivities[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.LoginActivity> GetClassByAdvanceSearch(DTO.LABURNUM.COM.LoginActivityModel model)
        {
            IQueryable<API.LABURNUM.COM.LoginActivity> iQuery = null;

            //Search By LoginActivityId.
            if (model.LoginActivityId > 0)
            {
                iQuery = this._laburnum.LoginActivities.Where(x => x.LoginActivityId == model.LoginActivityId && x.IsActive == true);
            }

            //Search By Student Id.
            if (iQuery != null)
            {
                if (model.StudentId > 0)
                {
                    iQuery = iQuery.Where(x => x.StudentId == model.StudentId && x.IsActive == true);
                }
            }
            else
            {
                if (model.StudentId > 0)
                {
                    iQuery = this._laburnum.LoginActivities.Where(x => x.StudentId == model.StudentId && x.IsActive == true);
                }
            }

            //Search By User Type Id.
            if (iQuery != null)
            {
                if (model.UserTypeId > 0)
                {
                    iQuery = iQuery.Where(x => x.UserTypeId == model.UserTypeId && x.IsActive == true);
                }
            }
            else
            {
                if (model.StudentId > 0)
                {
                    iQuery = this._laburnum.LoginActivities.Where(x => x.UserTypeId == model.UserTypeId && x.IsActive == true);
                }
            }

            //Search By Client Id.
            if (iQuery != null)
            {
                if (model.ClientId > 0)
                {
                    iQuery = iQuery.Where(x => x.ClientId == model.ClientId && x.IsActive == true);
                }
            }
            else
            {
                if (model.StudentId > 0)
                {
                    iQuery = this._laburnum.LoginActivities.Where(x => x.ClientId == model.ClientId && x.IsActive == true);
                }
            }

            //Search By Date Range.
            if (iQuery != null)
            {
                if (model.StartDate.Year != 0001)
                {
                    if (model.EndDate.Year == 0001) { model.EndDate = model.StartDate.AddDays(1).AddSeconds(-1); }

                    iQuery = iQuery.Where(x => x.CreatedOn >= model.StartDate && x.CreatedOn <= model.EndDate && x.IsActive == true);

                }
            }
            else
            {
                if (model.StartDate.Year != 0001)
                {
                    if (model.EndDate.Year == 0001) { model.EndDate = model.StartDate.AddDays(1).AddSeconds(-1); }

                    iQuery = this._laburnum.LoginActivities.Where(x => x.CreatedOn >= model.StartDate && x.CreatedOn <= model.EndDate && x.IsActive == true);

                }
            }

            List<API.LABURNUM.COM.LoginActivity> dbLoginActivities = iQuery.ToList();
            return dbLoginActivities;
        }
    }
}