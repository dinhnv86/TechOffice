﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
