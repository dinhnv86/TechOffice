using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AnThinhPhat.WebUI.Controllers
{
    public class CategoryController : OfficeController
    {
        public PartialViewResult MenuVanBan()
        {
            return PartialView("");
        }
    }
}
