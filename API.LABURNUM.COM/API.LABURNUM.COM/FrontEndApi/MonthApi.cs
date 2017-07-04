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

        public API.LABURNUM.COM.Month GetMonthById(long id)
        {
            List<API.LABURNUM.COM.Month> dbList = this._laburnum.Months.Where(x => x.MonthId == id && x.IsActive == true).ToList();
            if (dbList.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbList.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            return dbList[0];
        }
    }
}