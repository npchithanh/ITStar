using System.Web.Mvc;

namespace WebAppTest.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            //app.Brand.Add(new DTO.Brand { Name = "DELL" });
            //app.Product.Add(new DTO.Product { BrandId = 1744266147, CategoryId = 31426961, Name = "May tinh DELL Vostro", Price = 300000, Title = "Ko biet" });

            /*app.Attachment.Add(new DTO.Attachment
            {
                 
            });*/
            //app.AttachmentType.Add(new DTO.AttachmentType { Name = "Category" });
            
            /*DTO.Attachment obj = new DTO.Attachment { AttachmentTypeId = 1105091368, Url = "abc.png" };
            app.Attachment.Add(obj);
            int ret = obj.Id;
            */

            return View();
        }
    }
}