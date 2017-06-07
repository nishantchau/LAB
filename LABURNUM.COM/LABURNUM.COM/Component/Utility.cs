using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class Utility
    {
        public DateTime GetISTDateTime()
        {
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            return indianTime;
        }

        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    }
}