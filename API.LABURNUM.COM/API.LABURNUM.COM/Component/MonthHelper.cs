using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class MonthHelper
    {
        private List<API.LABURNUM.COM.Month> Months;

        public MonthHelper()
        {
            this.Months = new List<API.LABURNUM.COM.Month>();
        }

        public MonthHelper(List<API.LABURNUM.COM.Month> months)
        {
            if (months == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.Months = months;
        }

        public MonthHelper(API.LABURNUM.COM.Month month)
        {
            if (month == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.Months = new List<API.LABURNUM.COM.Month>();
            this.Months.Add(month);
        }

        public List<DTO.LABURNUM.COM.MonthModel> Map()
        {
            if (this.Months == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.MonthModel> dtoMonths = new List<DTO.LABURNUM.COM.MonthModel>();

            foreach (API.LABURNUM.COM.Month item in this.Months)
            {
                dtoMonths.Add(MapCore(item));
            }
            return dtoMonths;
        }

        public DTO.LABURNUM.COM.MonthModel MapSingle()
        {
            if (this.Months == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.Months.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.Months[0]);
        }

        private DTO.LABURNUM.COM.MonthModel MapCore(API.LABURNUM.COM.Month apimonth)
        {

            DTO.LABURNUM.COM.MonthModel dtoMonth = new DTO.LABURNUM.COM.MonthModel()
            {
                MonthId = apimonth.MonthId,
                MonthName = apimonth.MonthName,
                CreatedOn = apimonth.CreatedOn,
                IsActive = apimonth.IsActive,
                LastUpdated = apimonth.LastUpdated
            };
            return dtoMonth;
        }
    }
}