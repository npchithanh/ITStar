using DTO;
using System.Web.Mvc;
using Util;

namespace WebAppTest.Controllers
{
    public class CartController : BaseController
    {
        public ActionResult Index()
        {
            return View(app.Cart.GetCart(Identity.Key));
        }
        public ActionResult Create(int id, short quantity = 1)
        {
            if (string.IsNullOrEmpty(Cookie.Key))
            {
                Cookie.Key = RandomBuilder.RandomLong().ToString();
            }
            Cart obj = new Cart
            {
                CartId = Identity.Key,
                ProductId = id,
                Quantity = quantity
            };
            app.Cart.Add(obj);
            return RedirectToAction(string.Empty);
        }
        public ActionResult Edit(int id, short quantity)
        {
            app.Cart.Edit(new Cart { Id = id, Quantity = quantity });
            return RedirectToAction(string.Empty);
        }
        public ActionResult Remove(int id)
        {
            app.Cart.Remove(id);
            return RedirectToAction(string.Empty);
        }
    }
}