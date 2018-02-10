using DTO;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web;

namespace WebApp.Controllers
{

    public class HomeController : BaseController
    {
        [Authorized(Roles = "admin")]
        // GET: Home
        public ActionResult Index(HttpPostedFileBase file)
        {
            file.ContentType
            return View();
        }
        [ChildActionOnly]
        public ActionResult Menu()
        {
            List<Category> list = app.Category.GetCategories();
            IDictionary<int?, Category> tree = new Dictionary<int?, Category>();
            foreach (Category item in list)
            {
                if (item.ParentId == null)
                {
                    tree.Add(item.Id, item);
                }
            }
            foreach (Category item in list)
            {
                if (item.ParentId != null && tree.ContainsKey(item.ParentId))
                {
                    if (tree[item.ParentId].Categories == null)
                    {
                        tree[item.ParentId].Categories = new List<Category>();
                    }
                    tree[item.ParentId].Categories.Add(item);
                }
            }
            return PartialView(tree.Values);
        }
    }
}