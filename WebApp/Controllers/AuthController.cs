using DTO;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AuthController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }
        [Authorized]
        public ActionResult Logout()
        {
            app.Session.Remove(Cookie.Key);
            Cookie.Remove();
            //return RedirectToAction(string.Empty, "home");
            return Redirect("/");
        }

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Account obj)
        {
            int ret = app.Acccount.Login(obj);
            if (ret == 2)
            {
                DTO.Session session = new DTO.Session { Id = Util.RandomBuilder.RandomString(32), AccountId = obj.Id, IP = Request.UserHostAddress, Device = Request.Browser.Platform, Browser = Request.UserAgent };
                app.Session.Add(session);
                Cookie.Key = session.Id;
                //return RedirectToAction(string.Empty, "home");
                return Redirect("/");
            }
            else
            {
                string[] errors = { "Username not exists", "Login fail" };
                ModelState.AddModelError("error", errors[ret]);
            }
            return View(obj);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Account obj)
        {
            if (ModelState.IsValid)
            {
                if (app.Acccount.Add(obj))
                {
                    return RedirectToAction("login");
                }
                else
                {
                    ModelState.AddModelError("Error", "Username exists");
                }
            }
            return View(obj);
        }
    }
}