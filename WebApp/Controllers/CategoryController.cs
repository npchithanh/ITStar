using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail()
        {
            //return View();
            return RedirectToAction(string.Empty, "category");
        }
    }
}