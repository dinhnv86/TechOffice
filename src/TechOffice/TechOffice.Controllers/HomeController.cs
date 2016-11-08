using System.Web.Mvc;

namespace AnThinhPhat.WebUI.Controllers
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

        public ActionResult Article()
        {
            return View();
        }
    }
}