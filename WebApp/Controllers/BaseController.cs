using DAL;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        protected static AppProvider app = new AppProvider();
        
    }
}