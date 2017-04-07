using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class SalutationHelper
    {
        private List<API.LABURNUM.COM.Salutation> Salutations;

        public SalutationHelper()
        {
            this.Salutations = new List<API.LABURNUM.COM.Salutation>();
        }

        public SalutationHelper(List<API.LABURNUM.COM.Salutation> salutations)
        {
            if (salutations == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.Salutations = salutations;
        }

        public SalutationHelper(API.LABURNUM.COM.Salutation salutation)
        {
            if (salutation == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.Salutations = new List<API.LABURNUM.COM.Salutation>();
            this.Salutations.Add(salutation);
        }

        public List<DTO.LABURNUM.COM.SalutationModel> Map()
        {
            if (this.Salutations == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.SalutationModel> dtoSalutations = new List<DTO.LABURNUM.COM.SalutationModel>();
            foreach (API.LABURNUM.COM.Salutation item in this.Salutations)
            {
                dtoSalutations.Add(MapCore(item));
            }
            return dtoSalutations;
        }

        public DTO.LABURNUM.COM.SalutationModel MapSingle()
        {
            if (this.Salutations == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.Salutations.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.Salutations[0]);
        }

        private DTO.LABURNUM.COM.SalutationModel MapCore(API.LABURNUM.COM.Salutation salutation)
        {

            DTO.LABURNUM.COM.SalutationModel dtoClass = new DTO.LABURNUM.COM.SalutationModel()
            {
                SalutationId = salutation.SalutationId,
                Name = salutation.Name,
                CreatedOn = salutation.CreatedOn,
                IsActive = salutation.IsActive,
                LastUpdated = salutation.LastUpdated
            };
            return dtoClass;
        }
    }
}