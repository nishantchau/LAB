using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class UserTypeApi
    {
        private LaburnumEntities _laburnum;

        public UserTypeApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        public List<API.LABURNUM.COM.UserType> GetActiveUserTypes()
        {
            return this._laburnum.UserTypes.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.UserType> GetInActiveUserTypes()
        {
            return this._laburnum.UserTypes.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.UserType> GetAllUserTypes()
        {
            return this._laburnum.UserTypes.ToList();
        }
    }
}