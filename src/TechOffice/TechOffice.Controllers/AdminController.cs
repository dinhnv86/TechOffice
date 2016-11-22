using AnThinhPhat.Utilities;
using System.Web.Mvc;

namespace AnThinhPhat.WebUI.Controllers
{
    [Authorize(Roles = RoleConstant.SUPPER_ADMIN + TechOfficeConfig.SEPARATE_CHAR + RoleConstant.ADMIN)]
    public class AdminController : OfficeController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
