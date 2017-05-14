using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class Constants
    {
        public static string SessionName = "TMS_Session";

        public static class URL
        {
            public static string WEBAPIURL = System.Configuration.ConfigurationManager.AppSettings["WEBAPIURL"];
            public static string WEBSITEURL = System.Configuration.ConfigurationManager.AppSettings["WEBSITEURL"];
            public static string WEBSITEURLWITHOUTSLASH = System.Configuration.ConfigurationManager.AppSettings["WEBSITEURLWITHOUTSLASH"];
        }

        public static class APIACCESS
        {
            public static string APIUSERNAME = System.Configuration.ConfigurationManager.AppSettings["APIUSERNAME"];
            public static string APIPASSWORD = System.Configuration.ConfigurationManager.AppSettings["APIPASSWORD"];
            public static int HTTPTIME = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["HTTPTIME"]);
        }
        public static class ERRORMESSAGES
        {
            public static string NO_RECORD_FOUND = "No Record Found.";
            public static string MORE_THAN_ONE_RECORDFOUND = "More Than One Record Found.";
            public static string ACCESS_DENIED = "Access Denied.";
        }

        public static class KEYS
        {
            public static string SALTKEY = System.Configuration.ConfigurationManager.AppSettings["SALTKEY"];
            public static string SHAREDKEY = System.Configuration.ConfigurationManager.AppSettings["SHAREDKEY"];
        }

        public static class DEFAULTVALUE
        {
            public static int ANNUALFUNCTIONFEEPAYABLEMONTH = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["ANNUALFUNCTIONFEEPAYMONTH"]);
            public static int CHEQUEBOUNCEPANELTY = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["CHEQUEBOUNCEPANELTY"]);
            public static double ANNUALFUNCTIONFEE = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["ANNUALFUNCTIONFEE"]);
            
        }

        public static class Cookies
        {
            public static class UserCookie
            {
                public static string NAME = System.Configuration.ConfigurationManager.AppSettings["LABURNUMCOOKIENAME"];
                public static int EXPIRINGINDAYS = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["COOKIEEXPIREINDAYS"]);
                public static string LOGINACTIVITYID = "LoginActivityId";
            }
        }
    }
}