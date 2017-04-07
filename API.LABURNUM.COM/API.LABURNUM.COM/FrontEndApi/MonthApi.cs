using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class MonthApi
    {
        private LaburnumEntities _laburnum;

        public MonthApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        public List<API.LABURNUM.COM.Month> GetActiveMonths()
        {
            return this._laburnum.Months.Where(x => x.IsActive == true).ToList();
        }
    }
}