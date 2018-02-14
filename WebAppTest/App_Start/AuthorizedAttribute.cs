using System.Web.Mvc;

namespace WebAppTest
{
    public class AuthorizedAttribute : ActionFilterAttribute
    {
        public string Roles { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (!Identity.IsLogined)
            {
                filterContext.HttpContext.Response.Redirect("/auth/login");
            }
        }
    }
}