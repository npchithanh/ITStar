using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApp.Models;
using System.Configuration;
using DTO;
namespace WebApp.Controllers
{
    public class AuthController : BaseController
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
                ViewBag.IDGoogle = ConfigurationManager.AppSettings["idgoogle"];
                ViewBag.ReturnUrl = ReturnUrl;
                return View();
         }
        [HttpPost]
        public ActionResult Login( Account model , string ReturnUrl)
        {
            int ret = app.Acccount.Login(model);
            if (ret == 2)
            {
                DTO.Session session = new DTO.Session { Id = Util.RandomBuilder.RandomString(32), AccountId = model.Id, IP = Request.UserHostAddress, Device = Request.Browser.Platform, Browser = Request.UserAgent };
                app.Session.Add(session);
                Cookie.Key = session.Id;
                return RedirectToAction(string.Empty, "home");
               // return Redirect(ReturnUrl);
            }
            else
            {
                //string[] errors = { "Username not exists", "Login fail" };
                //ModelState.AddModelError("error", errors[ret]);
                ModelState.AddModelError("err", "Tài khoản hoặc mật khẩu không đúng");
            }
            
            return View();
            // app.Session.Add(model.Username,model.Password)


        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            ObjectUser user = (ObjectUser)Session["UserSocial"];
            if(user != null &&  (model.Username.Equals(user.Email)))
            {
                ModelState.AddModelError("err", "Lỗi tài khoản");
                return View(model);
            }
            string Name;
            bool Gender;
            if(user == null)
            {
                Name = model.Username;
                Gender = true;
            }
            else
            {
                Name = user.Name;
                Gender = user.Gender.Equals("male") ? true : false;
            }
            var objects = new Account
            {
                Username = model.Username,
                Password = model.Password,
                FullName = Name,
                Gender = Gender
            };
            bool result = app.Acccount.Add(objects);
            if (result)
            {
                return Redirect("/");
            }
            ModelState.AddModelError("err", "Tài khoản đã tồn tại ");
            return View(model);

         
        }

        private Uri RediredtUri

        {

            get

            {

                var uriBuilder = new UriBuilder(Request.Url);

                uriBuilder.Query = null;

                uriBuilder.Fragment = null;

                uriBuilder.Path = Url.Action("FacebookCallback");

                return uriBuilder.Uri;

            }

        }
        [AllowAnonymous]
        public ActionResult Facebook()

        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["idfacebook"],
                client_secret = ConfigurationManager.AppSettings["secretfacebook"],
                redirect_uri = RediredtUri.AbsoluteUri,
                response_type = "code",
                scope = "email"
            });
            return Redirect(loginUrl.AbsoluteUri);

        }

        public void GoogleLogin(ObjectUser model)
        {
            //Write your code here to access these paramerters
            Session["UserSocial"] = model;
            TempData["email"] = model.Email;
        }


        public ActionResult FacebookCallback(string code)

        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new

            {
                client_id = ConfigurationManager.AppSettings["idfacebook"],
                client_secret = ConfigurationManager.AppSettings["secretfacebook"],
                redirect_uri = RediredtUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;

            Session["AccessToken"] = accessToken;

            fb.AccessToken = accessToken;

            dynamic me = fb.Get("me?fields=link,first_name,currency,last_name,email,gender,locale,timezone,verified,picture,birthday");

            string email = me.email;

            ObjectUser model = new ObjectUser();
            model.Email = me.email;
            model.Name = me.last_name +" "+ me.first_name;
         //   model.DateOfBirth = me.birthday;
            model.Gender = me.gender;
            Session["UserSocial"] = model;
            TempData["email"] = me.email;

            //TempData["first_name"] = me.first_name;

            //TempData["lastname"] = me.last_name;

            //TempData["picture"] = me.picture.data.url;

            FormsAuthentication.SetAuthCookie(email, false);

            return RedirectToAction("Register", "Auth");

        }


        public  ActionResult Detail()
        {
            return View();
        }


        public ActionResult DetailAdmin()
        {
            return View();
        }
    }
}