using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class Constants
    {
        public static class ERRORMESSAGES
        {
            public static string NO_RECORD_FOUND = "No Record Found.";
            public static string MORE_THAN_ONE_RECORDFOUND = "More Than One Record Found.";
            public static string PARAMETER_LIST_CANNOT_BE_NULL = "Parameter List Cannot Be Null";
            public static string PARAMETER_CANNOT_BE_NULL = "Parameter Cannot Be Null";
        }

        public static class URL
        {
            public static string WEBSITEURL = System.Configuration.ConfigurationManager.AppSettings["WEBSITEURL"];
            public static string WEBSITEURLWITHOUTSLASH = System.Configuration.ConfigurationManager.AppSettings["WEBSITEURLWITHOUTSLASH"];
        }

        public static class SMTP
        {
            public static string SMTPHOST = System.Configuration.ConfigurationManager.AppSettings["SMTPHOST"];
            public static string SMTPEMAIL = System.Configuration.ConfigurationManager.AppSettings["SMTPEMAIL"];
            public static string SMTPPASSWORD = System.Configuration.ConfigurationManager.AppSettings["SMTPPASSWORD"];
            public static int SMTPPORT = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["SMTPPORT"]);
        }

        public static class KEYS
        {
            public static string SALTKEY = System.Configuration.ConfigurationManager.AppSettings["SALTKEY"];
            public static string SHAREDKEY = System.Configuration.ConfigurationManager.AppSettings["SHAREDKEY"];
        }
    }
}