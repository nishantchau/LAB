using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class UserTypeHelper
    {
        private List<API.LABURNUM.COM.UserType> UserTypes;

        public UserTypeHelper()
        {
            this.UserTypes = new List<API.LABURNUM.COM.UserType>();
        }

        public UserTypeHelper(List<API.LABURNUM.COM.UserType> userTypes)
        {
            if (userTypes == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.UserTypes = userTypes;
        }

        public UserTypeHelper(API.LABURNUM.COM.UserType userType)
        {
            if (userType == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.UserTypes = new List<API.LABURNUM.COM.UserType>();
            this.UserTypes.Add(userType);
        }

        public List<DTO.LABURNUM.COM.UserTypeModel> Map()
        {
            if (this.UserTypes == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.UserTypeModel> dtoUserTypes = new List<DTO.LABURNUM.COM.UserTypeModel>();
            foreach (API.LABURNUM.COM.UserType item in this.UserTypes)
            {
                dtoUserTypes.Add(MapCore(item));
            }
            return dtoUserTypes;
        }

        public DTO.LABURNUM.COM.UserTypeModel MapSingle()
        {
            if (this.UserTypes == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.UserTypes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.UserTypes[0]);
        }

        private DTO.LABURNUM.COM.UserTypeModel MapCore(API.LABURNUM.COM.UserType userType)
        {

            DTO.LABURNUM.COM.UserTypeModel dtoUserType = new DTO.LABURNUM.COM.UserTypeModel()
            {
                Text = userType.Text,
                UserTypeId = userType.UserTypeId,
                CreatedOn = userType.CreatedOn,
                IsActive = userType.IsActive,
                LastUpdated = userType.LastUpdated
            };
            return dtoUserType;
        }
    }
}