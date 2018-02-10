using DAL;
using WebApp.Controllers;

namespace WebApp
{
    public class Identity
    {
        static AppProvider app = new AppProvider();
        public static long Id
        {
            get
            {
                return app.Acccount.GetAccountId(Cookie.Key);
            }
        }
        public static string Username
        {
            get
            {
                return app.Acccount.GetUsername(Cookie.Key);
            }
        }
        public static string FullName
        {
            get
            {
                return app.Acccount.GetFullName(Cookie.Key);
            }
        }
        public static bool IsLogined
        {
            get{
                if (!string.IsNullOrEmpty( Cookie.Key))
                {
                    return app.Session.IsLogined(Cookie.Key);
                }
                return false;
            }
        }
    }
}