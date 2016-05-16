using System;
using System.Web;
using System.Web.Mvc;
using TimisComplaints.DataLayer;

namespace TimisComplaints.WebApi.Filters
{
    public class IdentityInjector
    {
        private const string COOKIE_NAME = "TimisCookie";

        /// <summary>
        ///     Add or replace a cookie
        /// </summary>
        /// <param name="value">The cookie value</param>
        /// <param name="expires">When it expires</param>
        public static void SetCookie(string value, DateTime expires)
        {
            var cookie = new HttpCookie(COOKIE_NAME)
            {
                Value = value,
                Expires = expires,
                Path = "/"
            };
            HttpContext.Current.Response.SetCookie(cookie);
        }

        /// <summary>
        ///     Delete a cookie
        /// </summary>
        public static void DeleteCookie()
        {
            var cookie = new HttpCookie(COOKIE_NAME)
            {
                Value = null,
                Expires = DateTime.Now.AddDays(-1),
                Path = "/"
            };
            HttpContext.Current.Response.SetCookie(cookie);
        }

        /// <summary>
        ///     Get the cookie value
        /// </summary>
        /// <returns>The cookie's value</returns>
        public static string GetCookie()
        {
            return HttpContext.Current.Request.Cookies[COOKIE_NAME] != null
                ? HttpContext.Current.Request.Cookies[COOKIE_NAME].Value
                : null;
        }
    }
}