using System.Web.Mvc;

namespace TechOffice.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : OfficeController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
