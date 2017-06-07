using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class CircularHelper
    {
        private List<API.LABURNUM.COM.Circular> Circulars;

        public CircularHelper()
        {
            this.Circulars = new List<API.LABURNUM.COM.Circular>();
        }

        public CircularHelper(List<API.LABURNUM.COM.Circular> circular)
        {
            if (circular == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.Circulars = circular;
        }

        public CircularHelper(API.LABURNUM.COM.Circular circular)
        {
            if (circular == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.Circulars = new List<API.LABURNUM.COM.Circular>();
            this.Circulars.Add(circular);
        }

        public List<DTO.LABURNUM.COM.CircularModel> Map()
        {
            if (this.Circulars == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.CircularModel> dtoClasses = new List<DTO.LABURNUM.COM.CircularModel>();
            foreach (API.LABURNUM.COM.Circular item in this.Circulars)
            {
                dtoClasses.Add(MapCore(item));
            }
            return dtoClasses;
        }

        public DTO.LABURNUM.COM.CircularModel MapSingle()
        {
            if (this.Circulars == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.Circulars.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.Circulars[0]);
        }

        private DTO.LABURNUM.COM.CircularModel MapCore(API.LABURNUM.COM.Circular apicircular)
        {

            DTO.LABURNUM.COM.CircularModel dtoClass = new DTO.LABURNUM.COM.CircularModel()
            {
                CircularId = apicircular.CircularId,
                Attachment = apicircular.Attachment,
                ClassIds = apicircular.ClassIds,
                Details = apicircular.Details,
                ExpiryOn = apicircular.ExpiryOn,
                IsForAdmin = apicircular.IsForAdmin,
                IsForFaculty = apicircular.IsForFaculty,
                IsForParents = apicircular.IsForParents,
                IsForStudent = apicircular.IsForStudent,
                PublishedOn = apicircular.PublishedOn,
                Subject = apicircular.Subject,
                CreatedOn = apicircular.CreatedOn,
                IsActive = apicircular.IsActive,
                LastUpdated = apicircular.LastUpdated,
                IsEditable = IsCircularEditable(apicircular.PublishedOn)
            };
            return dtoClass;
        }

        private bool IsCircularEditable(DateTime publishedon)
        {
            if (new Component.Utility().GetISTDateTime().Date >= publishedon.Date)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}