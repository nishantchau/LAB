using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class CurriculumApi
    {
        private LaburnumEntities _laburnum;

        public CurriculumApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddCurriculum(DTO.LABURNUM.COM.CurriculumModel model)
        {
            API.LABURNUM.COM.Curriculum curriculum = new Curriculum()
            {
                AcademicYearId = model.AcademicYearId,
                MonthId = model.MonthId,
                ClassId = model.ClassId,
                AddedById = model.AddedById,
                CurriculumDetails = GetCurriculumDetailApi(model.CurriculumDetails),
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.Curricula.Add(curriculum);
            this._laburnum.SaveChanges();
            return curriculum.CurriculumId;
        }

        private List<API.LABURNUM.COM.CurriculumDetail> GetCurriculumDetailApi(List<DTO.LABURNUM.COM.CurriculumDetailModel> dbCurriculumDetails)
        {
            List<API.LABURNUM.COM.CurriculumDetail> apiCurriculumDetails = new List<CurriculumDetail>();

            foreach (DTO.LABURNUM.COM.CurriculumDetailModel item in dbCurriculumDetails)
            {
                if (item.SubjectId > 0)
                {
                    apiCurriculumDetails.Add(new CurriculumDetail()
                    {
                        SubjectId = item.SubjectId,
                        Syllabus = item.Syllabus,
                        Activity = item.Activity,
                        IsActive = true,
                        CreatedOn = System.DateTime.Now,
                    });
                }
            }

            return apiCurriculumDetails;
        }

        private long AddValidation(DTO.LABURNUM.COM.CurriculumModel model)
        {

            return AddCurriculum(model);
        }

        public long Add(DTO.LABURNUM.COM.CurriculumModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.CurriculumModel model)
        {
            model.CurriculumId.TryValidate();
            IQueryable<API.LABURNUM.COM.Curriculum> iQuery = this._laburnum.Curricula.Where(x => x.CurriculumId == model.CurriculumId && x.IsActive == true);
            List<API.LABURNUM.COM.Curriculum> dbCurriculums = iQuery.ToList();
            if (dbCurriculums.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbCurriculums.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbCurriculums[0].ClassId = model.ClassId;
            dbCurriculums[0].MonthId = model.MonthId;
            dbCurriculums[0].AcademicYearId = model.AcademicYearId;
            dbCurriculums[0].UpdatedById = model.UpdatedById;
            dbCurriculums[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
            UpdateCurriculumDetails(model.CurriculumId, model.CurriculumDetails);
        }

        private void UpdateCurriculumDetails(long curriculumId, List<DTO.LABURNUM.COM.CurriculumDetailModel> dblist)
        {
            foreach (DTO.LABURNUM.COM.CurriculumDetailModel item in dblist)
            {
                if (item.CurriculumDetailId > 0)
                {
                    item.CurriculumId = curriculumId;
                    new FrontEndApi.CurriculumDetailApi().Update(item);
                }
                else
                {
                    if (item.SubjectId > 0)
                    {
                        item.CurriculumId = curriculumId;
                        new FrontEndApi.CurriculumDetailApi().Add(item);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.CurriculumModel model)
        {
            model.CurriculumId.TryValidate();
            IQueryable<API.LABURNUM.COM.Curriculum> iQuery = this._laburnum.Curricula.Where(x => x.CurriculumId == model.CurriculumId && x.IsActive == true);
            List<API.LABURNUM.COM.Curriculum> dbCurriculums = iQuery.ToList();
            if (dbCurriculums.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbCurriculums.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbCurriculums[0].IsActive = model.IsActive;
            dbCurriculums[0].UpdatedById = model.UpdatedById;
            dbCurriculums[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.Curriculum> GetActiveCurriculums()
        {
            return this._laburnum.Curricula.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.Curriculum> GetInActiveCurriculums()
        {
            return this._laburnum.Curricula.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.Curriculum> GetAllCurriculums()
        {
            return this._laburnum.Curricula.ToList();
        }

        public List<API.LABURNUM.COM.Curriculum> GetCurriculumByAdvanceSearch(DTO.LABURNUM.COM.CurriculumModel model)
        {
            IQueryable<API.LABURNUM.COM.Curriculum> iQuery = null;
            if (model.CurriculumId > 0)
            {
                iQuery = this._laburnum.Curricula.Where(x => x.CurriculumId == model.CurriculumId && x.IsActive == true);
            }
            //Search By AcademicYearId.
            if (iQuery != null)
            {
                if (model.AcademicYearId > 0)
                {
                    iQuery = iQuery.Where(x => x.AcademicYearId == model.AcademicYearId && x.IsActive == true);
                }
            }
            else
            {
                if (model.AcademicYearId > 0)
                {
                    iQuery = this._laburnum.Curricula.Where(x => x.AcademicYearId == model.AcademicYearId && x.IsActive == true);
                }
            }
            //Search By ClassId.
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
                    iQuery = this._laburnum.Curricula.Where(x => x.ClassId == model.ClassId && x.IsActive == true);
                }
            }

            //Search By MonthId.
            if (iQuery != null)
            {
                if (model.MonthId > 0)
                {
                    iQuery = iQuery.Where(x => x.MonthId == model.MonthId && x.IsActive == true);
                }
            }
            else
            {
                if (model.MonthId > 0)
                {
                    iQuery = this._laburnum.Curricula.Where(x => x.MonthId == model.MonthId && x.IsActive == true);
                }
            }

            //Search By AddedById.
            if (iQuery != null)
            {
                if (model.AddedById > 0)
                {
                    iQuery = iQuery.Where(x => x.AddedById == model.AddedById && x.IsActive == true);
                }
            }
            else
            {
                if (model.AddedById > 0)
                {
                    iQuery = this._laburnum.Curricula.Where(x => x.AddedById == model.AddedById && x.IsActive == true);
                }
            }

            //Search By UpdatedById.
            if (iQuery != null)
            {
                if (model.UpdatedById > 0)
                {
                    iQuery = iQuery.Where(x => x.UpdatedById == model.UpdatedById && x.IsActive == true);
                }
            }
            else
            {
                if (model.AddedById > 0)
                {
                    iQuery = this._laburnum.Curricula.Where(x => x.UpdatedById == model.UpdatedById && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.Curriculum> dbCurriculums = iQuery.ToList();
            return dbCurriculums;
        }
    }
}