using System.Web.Mvc;

namespace AnThinhPhat.WebUI.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        [ActionName("NotFound")]
        public ActionResult Error404()
        {
            return View();
        }

        [ActionName("NotFound405")]
        public ActionResult Error405()
        {
            return View();
        }

        [ActionName("InternalServer")]
        public ActionResult Error500()
        {
            return View();
        }

        [ActionName("Unauthorized")]
        public ActionResult Error401()
        {
            return View();
        }

        [ActionName("ForbidenAccess")]
        public ActionResult Error403()
        {
            return View();
        }
    }
}