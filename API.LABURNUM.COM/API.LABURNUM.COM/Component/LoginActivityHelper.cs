using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class LoginActivityHelper
    {
        private List<API.LABURNUM.COM.LoginActivity> Classes;

        public LoginActivityHelper()
        {
            this.Classes = new List<API.LABURNUM.COM.LoginActivity>();
        }

        public LoginActivityHelper(List<API.LABURNUM.COM.LoginActivity> loginActivities)
        {
            if (loginActivities == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.Classes = loginActivities;
        }

        public LoginActivityHelper(API.LABURNUM.COM.LoginActivity loginActivity)
        {
            if (loginActivity == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.Classes = new List<API.LABURNUM.COM.LoginActivity>();
            this.Classes.Add(loginActivity);
        }

        public List<DTO.LABURNUM.COM.LoginActivityModel> Map()
        {
            if (this.Classes == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.LoginActivityModel> dtoLoginActivities = new List<DTO.LABURNUM.COM.LoginActivityModel>();
            foreach (API.LABURNUM.COM.LoginActivity item in this.Classes)
            {
                dtoLoginActivities.Add(MapCore(item));
            }
            return dtoLoginActivities;
        }

        public DTO.LABURNUM.COM.LoginActivityModel MapSingle()
        {
            if (this.Classes == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.Classes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.Classes[0]);
        }

        private DTO.LABURNUM.COM.LoginActivityModel MapCore(API.LABURNUM.COM.LoginActivity apiLoginActivity)
        {

            DTO.LABURNUM.COM.LoginActivityModel dtoClass = new DTO.LABURNUM.COM.LoginActivityModel()
            {
                LoginActivityId = apiLoginActivity.LoginActivityId,
                UserTypeId = apiLoginActivity.UserTypeId,
                UserTypeText = apiLoginActivity.UserType.Text,
                LoginAt = apiLoginActivity.LoginAt,
                LogoutAt = apiLoginActivity.LogoutAt,
                CreatedOn = apiLoginActivity.CreatedOn,
                IsActive = apiLoginActivity.IsActive,
                LastUpdated = apiLoginActivity.LastUpdated,
                ClientId = apiLoginActivity.ClientId,
                ClientName = apiLoginActivity.ApiClient.ClientName,
                StudentId = apiLoginActivity.StudentId
            };

            dtoClass.UserName = GetUserName(apiLoginActivity);
            return dtoClass;
        }

        private string GetUserName(API.LABURNUM.COM.LoginActivity apiLoginActivity)
        {
            string userName = null;
            API.LABURNUM.COM.Student apistudent =new FrontEndApi.StudentApi().GetStudentByStudentId(apiLoginActivity.StudentId);
            switch (apiLoginActivity.UserTypeId)
            {
                case 4:
                    //userName = apiLoginActivity.Student.FatherName;
                    userName = apistudent.FatherName;
                    break;
                case 5:
                    userName = apistudent.FirstName + " " + apistudent.MiddleName + " " + apistudent.LastName;
                    break;
                default:
                    userName = new FrontEndApi.FacultyApi().GetFacultyById(apiLoginActivity.StudentId).FacultyName;
                    break;
            }
            return userName;
        }
    }
}