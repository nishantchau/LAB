using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class CurriculumDetailApi
    {
        private LaburnumEntities _laburnum;

        public CurriculumDetailApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddCurriculumDetail(DTO.LABURNUM.COM.CurriculumDetailModel model)
        {
            API.LABURNUM.COM.CurriculumDetail CurriculumDetail = new CurriculumDetail()
            {
                CurriculumId = model.CurriculumId,
                SubjectId = model.SubjectId,
                Syllabus = model.Syllabus,
                Activity = model.Activity,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.CurriculumDetails.Add(CurriculumDetail);
            this._laburnum.SaveChanges();
            return CurriculumDetail.CurriculumDetailId;
        }

        private long AddValidation(DTO.LABURNUM.COM.CurriculumDetailModel model)
        {
            model.CurriculumId.TryValidate();
            model.SubjectId.TryValidate();
            model.Syllabus.TryValidate();
            return AddCurriculumDetail(model);
        }

        public long Add(DTO.LABURNUM.COM.CurriculumDetailModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.CurriculumDetailModel model)
        {
            model.CurriculumDetailId.TryValidate();
            IQueryable<API.LABURNUM.COM.CurriculumDetail> iQuery = this._laburnum.CurriculumDetails.Where(x => x.CurriculumDetailId == model.CurriculumDetailId && x.IsActive == true);
            List<API.LABURNUM.COM.CurriculumDetail> dbCurriculumDetails = iQuery.ToList();
            if (dbCurriculumDetails.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbCurriculumDetails.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbCurriculumDetails[0].CurriculumId = model.CurriculumId;
            dbCurriculumDetails[0].SubjectId = model.SubjectId;
            dbCurriculumDetails[0].Syllabus = model.Syllabus;
            dbCurriculumDetails[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.CurriculumDetailModel model)
        {
            model.CurriculumDetailId.TryValidate();
            IQueryable<API.LABURNUM.COM.CurriculumDetail> iQuery = this._laburnum.CurriculumDetails.Where(x => x.CurriculumDetailId == model.CurriculumDetailId && x.IsActive == true);
            List<API.LABURNUM.COM.CurriculumDetail> dbCurriculumDetails = iQuery.ToList();
            if (dbCurriculumDetails.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbCurriculumDetails.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbCurriculumDetails[0].IsActive = model.IsActive;
            dbCurriculumDetails[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.CurriculumDetail> GetActiveCurriculumDetails()
        {
            return this._laburnum.CurriculumDetails.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.CurriculumDetail> GetInActiveCurriculumDetails()
        {
            return this._laburnum.CurriculumDetails.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.CurriculumDetail> GetAllCurriculumDetails()
        {
            return this._laburnum.CurriculumDetails.ToList();
        }

        public List<API.LABURNUM.COM.CurriculumDetail> GetCurriculumDetailByAdvanceSearch(DTO.LABURNUM.COM.CurriculumDetailModel model)
        {
            IQueryable<API.LABURNUM.COM.CurriculumDetail> iQuery = null;

            //Search By Curriculum Detail Id.
            if (model.CurriculumDetailId > 0)
            {
                iQuery = this._laburnum.CurriculumDetails.Where(x => x.CurriculumDetailId == model.CurriculumDetailId && x.IsActive == true);
            }

            //Search By CurriculumId.
            if (iQuery != null)
            {
                if (model.CurriculumId > 0)
                {
                    iQuery = iQuery.Where(x => x.CurriculumId == model.CurriculumId && x.IsActive == true);
                }
            }
            else
            {
                if (model.CurriculumId > 0)
                {
                    iQuery = this._laburnum.CurriculumDetails.Where(x => x.CurriculumId == model.CurriculumId && x.IsActive == true);
                }
            }

            //Search By Subject Id.
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
                    iQuery = this._laburnum.CurriculumDetails.Where(x => x.SubjectId == model.SubjectId && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.CurriculumDetail> dbCurriculumDetails = iQuery.ToList();
            return dbCurriculumDetails;
        }

        public API.LABURNUM.COM.CurriculumDetail GetCurriculumDetailById(long id)
        {
            List<API.LABURNUM.COM.CurriculumDetail> dbList = this._laburnum.CurriculumDetails.Where(x => x.CurriculumDetailId == id && x.IsActive == true).ToList();
            if (dbList.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbList.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            return dbList[0];
        }
    }
}