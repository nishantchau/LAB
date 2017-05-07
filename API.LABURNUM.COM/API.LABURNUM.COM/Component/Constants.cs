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
            public static string SOMETHING_GOES_WRONG = "SomeThing Goes Wrong Please Try Again Later";
        }

        public static class URL
        {
            public static string WEBSITEURL = System.Configuration.ConfigurationManager.AppSettings["WEBSITEURL"];
            public static string WEBSITEURLWITHOUTSLASH = System.Configuration.ConfigurationManager.AppSettings["WEBSITEURLWITHOUTSLASH"];
            public static string WEBAPIURLWITHOUTSLASH = System.Configuration.ConfigurationManager.AppSettings["WEBAPIURLWITHOUTSLASH"];
        }

        public static class SMTP
        {
            public static string SMTPHOST = System.Configuration.ConfigurationManager.AppSettings["SMTPHOST"];
            public static string SMTPEMAIL = System.Configuration.ConfigurationManager.AppSettings["SMTPEMAIL"];
            public static string SMTPPASSWORD = System.Configuration.ConfigurationManager.AppSettings["SMTPPASSWORD"];
            public static int SMTPPORT = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["SMTPPORT"]);
        }

        public static class MAIL
        {
            public static string ADMINMAIL = System.Configuration.ConfigurationManager.AppSettings["ADMINMAIL"];
            public static string MAILSENTFROM = System.Configuration.ConfigurationManager.AppSettings["MAILSENTFROM"];
        }

        public static class MAILSUBJECT
        {
            public static string REGISTRATIONSUBJECT = "Thank you for Registration at Laburnum Public School";
            public static string ADMISSIONSUBJECT = "Thank you for Admission at Laburnum Public School";
            
        }

        public static class KEYS
        {
            public static string SALTKEY = System.Configuration.ConfigurationManager.AppSettings["SALTKEY"];
            public static string SHAREDKEY = System.Configuration.ConfigurationManager.AppSettings["SHAREDKEY"];
        }

        public static class SMSAPI
        {
            public static string SMSAPIURL = System.Configuration.ConfigurationManager.AppSettings["SMSAPIURL"];
            public static string SENDERID = System.Configuration.ConfigurationManager.AppSettings["SENDERID"];
            public static string SMSUSERNAME = System.Configuration.ConfigurationManager.AppSettings["SMSUSERNAME"];
            public static string SMSPASSWORD = System.Configuration.ConfigurationManager.AppSettings["SMSPASSWORD"];
            public static string PRESENTSMSMSG = System.Configuration.ConfigurationManager.AppSettings["PRESENTSMSMSG"];
            public static string ABSENTSMSMSG = System.Configuration.ConfigurationManager.AppSettings["ABSENTSMSMSG"];
        }
    }
}