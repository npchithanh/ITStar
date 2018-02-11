using DAL;
using System.Web.Mvc;

namespace WebAppTest.Controllers
{
    public class BaseController : Controller
    {
        protected static AppProvider app = new AppProvider();
    }
}