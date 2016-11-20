using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using Ninject;
using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AnThinhPhat.WebUI.Controllers
{
    public class FileController : OfficeController
    {
        [Inject]
        public ITapTinYKienCoQuanRepository TapTinYKienCoQuanRepository { get; set; }

        [Inject]
        public ITacNghiepTinhHinhThucHienRepository TacNghiepTinhHinhThucHienRepository { get; set; }

        [HttpGet]
        public FilePathResult DownloadFile(string path, string file)
        {
            string folder = Path.Combine(Server.MapPath(TechOfficeConfig.FOLDER_UPLOAD), path, file);
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
        public ContentResult FilesAttach(string guid)
        {
            try
            {
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                    if (hpf.ContentLength == 0)
                        continue;

                    SaveFilesTacNghiep(hpf, guid);
                }

                // Returns json
                var json = GetPathFiles(guid);

                return Content(json, "application/html");
            }
            catch (Exception ex)
            {
                LogService.Error(ex.Message, ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Content("ERROR", "application/html");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id Noi dung y kien cua cac co quan</param>
        /// <param name="tacNghiepId">Id tac nghiep</param>
        /// <param name="coQuanId">Id Co quan</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ContentResult FilesAttachNoiDungYKien(int id, int tacNghiepId, int coQuanId)
        {
            //Create folder YKienCoQuan
            string folder = EnsureFolderTacNghiepWithCoQuan(tacNghiepId, id);

            try
            {
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                    if (hpf.ContentLength == 0)
                        continue;

                    SaveFilesCoQuan(hpf, folder);

                    TapTinYKienCoQuanRepository.Add(new Entities.Results.TapTinYKienCoQuanResult
                    {
                        YKienCoQuanId = id,
                        UserUploadId = UserId,
                        CreatedBy = UserName,
                        Url = Path.Combine(folder, Path.GetFileName(hpf.FileName)),
                    });
                }

                ExecuteTryLogException(() =>
                {
                    //Update Status MucDoHoanThanh
                    TacNghiepTinhHinhThucHienRepository.UpdateIncrementMucDoHoanThanh(tacNghiepId, coQuanId, UserName, Utilities.Enums.EnumMucDoHoanThanh.DANGTHUCHIEN);
                });

                // Returns json
                string json = GetPathFiles(folder);

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

        private void SaveFilesCoQuan(HttpPostedFileBase file, string path)
        {
            string savedFileName = Path.Combine(path, Path.GetFileName(file.FileName));
            try
            {
                file.SaveAs(savedFileName); // Save the file
                //Upload Db
            }
            catch (Exception ex)
            {
                LogService.Error(string.Format("Has error in while save file {0}", file.FileName), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id co quan</param>
        /// <returns></returns>
        private string EnsureFolderTacNghiepWithCoQuan(int tacNghiepId, int coQuanId)
        {
            string folderTN = EnsureFolderTacNghiep(tacNghiepId);

            string folderCQ = Path.Combine(folderTN, coQuanId.ToString().PadLeft(TechOfficeConfig.LENGTHFOLDER, TechOfficeConfig.PADDING_CHAR));
            EnsureFolder(folderCQ);

            return folderCQ;
        }

        private string EnsureFolderTemp(string guid)
        {
            try
            {
                //1. Get folder upload
                string folderUpload = Server.MapPath(TechOfficeConfig.FOLDER_UPLOAD);
                EnsureFolder(folderUpload);

                string folderTemp = Path.Combine(folderUpload, guid);
                EnsureFolder(folderTemp);

                return folderTemp;
            }
            catch (Exception ex)
            {
                LogService.Error("Has error in while create new Temp folder upload", ex);
                throw;
            }
        }

        private string EnsureFolderTacNghiep(int tacNghiepId)
        {
            string folderParentTN = Server.MapPath(TechOfficeConfig.FOLDER_UPLOAD_TACNGHIEP);
            EnsureFolder(folderParentTN);

            string folderTN = Path.Combine(folderParentTN, tacNghiepId.ToString().PadLeft(TechOfficeConfig.LENGTHFOLDER, TechOfficeConfig.PADDING_CHAR));
            EnsureFolder(folderTN);

            return folderTN;
        }

        private string GetPathFiles(string path)
        {
            var files = Directory.GetFiles(Path.Combine(Server.MapPath(TechOfficeConfig.FOLDER_UPLOAD), path));
            string json = string.Empty;
            foreach (string file in files)
            {
                json += "<a href=" + Url.Action("DownloadFile", new { path = path, file = Path.GetFileName(file) }) + ">" + Path.GetFileName(file) + "</a>" + "<br/>";
            }
            return json;
        }

        private void EnsureFolder(string folder)
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
        }

    }
}
