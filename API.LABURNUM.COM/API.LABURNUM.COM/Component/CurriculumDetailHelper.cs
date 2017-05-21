using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class CurriculumDetailHelper
    {
        private List<API.LABURNUM.COM.CurriculumDetail> CurriculumDetails;

        public CurriculumDetailHelper()
        {
            this.CurriculumDetails = new List<API.LABURNUM.COM.CurriculumDetail>();
        }

        public CurriculumDetailHelper(List<API.LABURNUM.COM.CurriculumDetail> curriculumDetails)
        {
            if (curriculumDetails == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.CurriculumDetails = curriculumDetails;
        }

        public CurriculumDetailHelper(API.LABURNUM.COM.CurriculumDetail curriculumDetail)
        {
            if (curriculumDetail == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.CurriculumDetails = new List<API.LABURNUM.COM.CurriculumDetail>();
            this.CurriculumDetails.Add(curriculumDetail);
        }

        public List<DTO.LABURNUM.COM.CurriculumDetailModel> Map()
        {
            if (this.CurriculumDetails == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.CurriculumDetailModel> dtoCurriculums = new List<DTO.LABURNUM.COM.CurriculumDetailModel>();
            foreach (API.LABURNUM.COM.CurriculumDetail item in this.CurriculumDetails)
            {
                dtoCurriculums.Add(MapCore(item));
            }
            return dtoCurriculums;
        }

        public DTO.LABURNUM.COM.CurriculumDetailModel MapSingle()
        {
            if (this.CurriculumDetails == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.CurriculumDetails.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.CurriculumDetails[0]);
        }

        private DTO.LABURNUM.COM.CurriculumDetailModel MapCore(API.LABURNUM.COM.CurriculumDetail curriculumDetail)
        {
            DTO.LABURNUM.COM.CurriculumDetailModel dtoCurriculumDetail = new DTO.LABURNUM.COM.CurriculumDetailModel()
            {
                CurriculumId = curriculumDetail.CurriculumId,
                SubjectId = curriculumDetail.SubjectId,
                CurriculumDetailId = curriculumDetail.CurriculumDetailId,
                Syllabus = curriculumDetail.Syllabus,
                Activity = curriculumDetail.Activity,
                SubjectName = curriculumDetail.Subject.SubjectName,
                CreatedOn = curriculumDetail.CreatedOn,
                IsActive = curriculumDetail.IsActive,
                LastUpdated = curriculumDetail.LastUpdated
            };
            return dtoCurriculumDetail;
        }
    }
}