using System;
using System.Web;

namespace WebAppTest
{
    public class Cookie
    {
        const string SessionId = "IT_STAR";
        static HttpCookie GetCookie()
        {
            return HttpContext.Current.Request.Cookies[SessionId];
        }
        static void SetCookie(string val)
        {
            HttpCookie cookie = new HttpCookie(SessionId, val);
            cookie.Expires.AddMinutes(64);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static string Key
        {
            get
            {
                HttpCookie cookie = GetCookie();
                return cookie != null ? cookie.Value : null;
            }
            set
            {
                SetCookie(value);
            }
        }
        public static void Remove()
        {
            if (GetCookie() != null)
            {
                HttpContext.Current.Response.Cookies[SessionId].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}