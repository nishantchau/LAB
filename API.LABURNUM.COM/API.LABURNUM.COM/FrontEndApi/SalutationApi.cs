using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class SalutationApi
    {
        private LaburnumEntities _laburnum;

        public SalutationApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddSalutation(DTO.LABURNUM.COM.SalutationModel model)
        {
            API.LABURNUM.COM.Salutation apiSalutation = new Salutation()
            {
                Name = model.Name,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.Salutations.Add(apiSalutation);
            this._laburnum.SaveChanges();
            return apiSalutation.SalutationId;
        }

        private long AddValidation(DTO.LABURNUM.COM.SalutationModel model)
        {
            model.Name.TryValidate();
            return AddSalutation(model);
        }

        public long Add(DTO.LABURNUM.COM.SalutationModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.SalutationModel model)
        {
            model.SalutationId.TryValidate();
            IQueryable<API.LABURNUM.COM.Salutation> iQuery = this._laburnum.Salutations.Where(x => x.SalutationId == model.SalutationId && x.IsActive == true);
            List<API.LABURNUM.COM.Salutation> dbSalutations = iQuery.ToList();
            if (dbSalutations.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbSalutations.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbSalutations[0].Name = model.Name;
            dbSalutations[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.SalutationModel model)
        {
            model.SalutationId.TryValidate();
            IQueryable<API.LABURNUM.COM.Salutation> iQuery = this._laburnum.Salutations.Where(x => x.SalutationId == model.SalutationId && x.IsActive == true);
            List<API.LABURNUM.COM.Salutation> dbSalutations = iQuery.ToList();
            if (dbSalutations.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbSalutations.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbSalutations[0].IsActive = model.IsActive;
            dbSalutations[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.Salutation> GetActiveSalutations()
        {
            return this._laburnum.Salutations.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.Salutation> GetInActiveSalutations()
        {
            return this._laburnum.Salutations.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.Salutation> GetAllSalutations()
        {
            return this._laburnum.Salutations.ToList();
        }

        public List<API.LABURNUM.COM.Salutation> GetSalutationByAdvanceSearch(DTO.LABURNUM.COM.SalutationModel model)
        {
            IQueryable<API.LABURNUM.COM.Salutation> iQuery = null;
            if (model.SalutationId > 0)
            {
                iQuery = this._laburnum.Salutations.Where(x => x.SalutationId == model.SalutationId && x.IsActive == true);
            }
            if (iQuery != null)
            {
                if (model.Name != null)
                {
                    iQuery = iQuery.Where(x => x.Name.Trim().ToLower().Equals(model.Name.Trim().ToLower()) && x.IsActive == true);
                }
            }
            else
            {
                if (model.Name != null)
                {
                    iQuery = this._laburnum.Salutations.Where(x => x.Name.Trim().ToLower().Equals(model.Name.Trim().ToLower()) && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.Salutation> dbSalutations = iQuery.ToList();
            return dbSalutations;
        }
    }
}