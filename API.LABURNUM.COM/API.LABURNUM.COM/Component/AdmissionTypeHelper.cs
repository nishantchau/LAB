using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AdmissionTypeHelper
    {
        private List<API.LABURNUM.COM.AdmissionType> AdmissionTypes;

        public AdmissionTypeHelper()
        {
            this.AdmissionTypes = new List<API.LABURNUM.COM.AdmissionType>();
        }

        public AdmissionTypeHelper(List<API.LABURNUM.COM.AdmissionType> admissionTypes)
        {
            if (admissionTypes == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AdmissionTypes = admissionTypes;
        }


        public AdmissionTypeHelper(API.LABURNUM.COM.AdmissionType AdmissionType)
        {
            if (AdmissionType == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AdmissionTypes = new List<API.LABURNUM.COM.AdmissionType>();
            this.AdmissionTypes.Add(AdmissionType);
        }


        public List<DTO.LABURNUM.COM.AdmissionTypeModel> Map()
        {
            if (this.AdmissionTypes == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AdmissionTypeModel> dtoAdmissionTypes = new List<DTO.LABURNUM.COM.AdmissionTypeModel>();
            foreach (API.LABURNUM.COM.AdmissionType item in this.AdmissionTypes)
            {
                dtoAdmissionTypes.Add(MapCore(item));
            }
            return dtoAdmissionTypes;
        }

        public DTO.LABURNUM.COM.AdmissionTypeModel MapSingle()
        {
            if (this.AdmissionTypes == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AdmissionTypes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AdmissionTypes[0]);
        }

        private DTO.LABURNUM.COM.AdmissionTypeModel MapCore(API.LABURNUM.COM.AdmissionType admissionType)
        {

            DTO.LABURNUM.COM.AdmissionTypeModel dtoClass = new DTO.LABURNUM.COM.AdmissionTypeModel()
            {
                AdmissionTypeId = admissionType.AdmissionTypeId,
                Name = admissionType.Name,
                CreatedOn = admissionType.CreatedOn,
                IsActive = admissionType.IsActive,
                LastUpdated = admissionType.LastUpdated
            };
            return dtoClass;
        }
    }
}