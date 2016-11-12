using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AnThinhPhat.WebUI.Controllers
{
    public class FileController : OfficeController
    {
        [HttpGet]
        public FilePathResult DownloadFile(int id, string file)
        {
            string folder = System.IO.Path.Combine(Server.MapPath("~/Uploads"), id.ToString().PadLeft(10, '0'), file);
            return File(folder, System.Net.Mime.MediaTypeNames.Application.Octet, file);
        }
    }
}
