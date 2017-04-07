using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class ApiClientApi
    {
        private LaburnumEntities _laburnum;

        public ApiClientApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        public Boolean IsClientValid(string username, string password)
        {
            IQueryable<API.LABURNUM.COM.ApiClient> iQuery = this._laburnum.ApiClients.Where(x => x.UserName.Trim().Equals(username.Trim()) && x.Password.Trim().Equals(password.Trim()) && x.IsActive == true);
            List<API.LABURNUM.COM.ApiClient> dbClients = iQuery.ToList();
            if (dbClients.Count == 0) { return false; }
            if (dbClients.Count > 1) { return false; }
            return true;
        }

        public long GetClientId(string username, string password)
        {
            IQueryable<API.LABURNUM.COM.ApiClient> iQuery = this._laburnum.ApiClients.Where(x => x.UserName.Trim().Equals(username.Trim()) && x.Password.Trim().Equals(password.Trim()) && x.IsActive == true);
            List<API.LABURNUM.COM.ApiClient> dbClients = iQuery.ToList();
            if (dbClients.Count == 0) { return -1; }
            if (dbClients.Count > 1) { return -1; }
            return dbClients[0].ApiClientId;
        }
    }
}