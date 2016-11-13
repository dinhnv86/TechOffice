using AnThinhPhat.Utilities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;

namespace AnThinhPhat.WebUI.Controllers
{
    public class FileController : OfficeController
    {
        [HttpGet]
        public FilePathResult DownloadFile(string path, string file)
        {
            string folder = System.IO.Path.Combine(Server.MapPath("~/Uploads"), path, file);
            return File(folder, System.Net.Mime.MediaTypeNames.Application.Octet, file);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="type">
        /// 1: TacNghiep
        /// 2: VanBan
        /// 3: ThuTuc</param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult FilesAttach(string guid, string type)
        {
            try
            {
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                    if (hpf.ContentLength == 0)
                        continue;

                    if (type == "1")
                    {
                        SaveFilesTacNghiep(hpf, guid);
                        continue;
                    }
                }

                // Returns json
                var json = GetPathFilesTemp(guid);

                return Content(json, "application/html");
            }
            catch (Exception ex)
            {
                LogService.Error(ex.Message, ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Content("ERROR", "application/html");
            }
        }

        private void SaveFilesTacNghiep(HttpPostedFileBase file, string guid)
        {
            var folderTemp = EnsureFolderTemp(guid);
            string savedFileName = Path.Combine(folderTemp, Path.GetFileName(file.FileName));
            try
            {
                file.SaveAs(savedFileName); // Save the file
            }
            catch (Exception ex)
            {
                LogService.Error(string.Format("Has error in while save file {0}", file.FileName), ex);
            }
        }

        private string EnsureFolderTemp(string guid)
        {
            try
            {
                //1. Get folder upload
                string folderUpload = Server.MapPath("~/Uploads");
                if (!Directory.Exists(folderUpload))
                    Directory.CreateDirectory(folderUpload);

                string folderTemp = Path.Combine(folderUpload, guid);
                if (!Directory.Exists(folderTemp))
                    Directory.CreateDirectory(folderTemp);

                return folderTemp;
            }
            catch (Exception ex)
            {
                LogService.Error("Has error in while create new Temp folder upload", ex);
                throw;
            }
        }

        private void EnsureFolderTacNghiep()
        {

        }

        private string GetPathFilesTemp(string guid)
        {
            var files = Directory.GetFiles(Path.Combine(Server.MapPath("~/Uploads"), guid));
            string json = string.Empty;
            foreach (string file in files)
            {
                json += "<a href=" + Url.Action("DownloadFile", new { path = guid, file = Path.GetFileName(file) }) + ">" + Path.GetFileName(file) + "</a>" + "<br/>";
            }
            return json;
        }
    }
}
