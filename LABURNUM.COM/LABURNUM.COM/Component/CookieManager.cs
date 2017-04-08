using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class CookieManager
    {
        private string CookieName { get; set; }
        private string CookieValue { get; set; }
        private int ExpiringInDays { get; set; }

        public CookieManager(string cookieName)
        {
            this.CookieName = cookieName;
            this.CookieValue = string.Empty;
            this.ExpiringInDays = -1;
            Validate();
        }

        public CookieManager(string cookieName, string cookieValue, int expiringInDays)
        {
            this.CookieName = cookieName;
            this.CookieValue = cookieValue;
            this.ExpiringInDays = expiringInDays;
            Validate();
        }

        private void Validate()
        {
            if (this.CookieName == null) { throw new Exception("Invalid Cookie Name. Cookie Name Cannot Be Null."); }
            if (this.CookieName.Trim().Equals("")) { throw new Exception("Invalid Cookie Name. Cookie Name Cannot Be Blank."); }
        }

        public void SetCookie()
        {
            HttpCookie myCookie = new HttpCookie(this.CookieName);
            myCookie.Values["LoginActivityId"] = this.CookieValue;
            myCookie.Expires = System.DateTime.Now.AddDays(this.ExpiringInDays);
            HttpContext.Current.Response.Cookies.Add(myCookie);
        }

        public string GetLoginActivityId(string cookieName)
        {
            HttpCookie myCookie = HttpContext.Current.Request.Cookies[cookieName];
            if (myCookie != null) { return myCookie.Values[0]; }
            return "";
        }
    }
}