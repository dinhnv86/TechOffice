using System.Web.Mvc;

namespace AnThinhPhat.WebUI.Controllers
{
    public class IntroController : OfficeController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chart()
        {
            return View();
        }
    }
}