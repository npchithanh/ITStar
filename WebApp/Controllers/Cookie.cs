using System;
using System.Web;

namespace WebApp.Controllers
{
    public class Cookie
    {
        const string SessionId = "IT_STAR";
        static HttpCookie GetCookie()
        {
            return HttpContext.Current.Request.Cookies[SessionId];
        }
        public static string Key
        {
            get
            {
                HttpCookie cookie = GetCookie();
                if (cookie != null)
                {
                    return cookie.Value;
                }
                return null;
            }
            set
            {
                HttpCookie cookie = new HttpCookie(SessionId, value);
                cookie.Expires.AddMinutes(64);
                HttpContext.Current.Response.Cookies.Add(cookie);
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