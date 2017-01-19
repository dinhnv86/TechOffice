using System.Linq;
using System.Web.Mvc;
using AnThinhPhat.Entities;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.ViewModel.ThuTuc;
using Ninject;
using PagedList;
using AnThinhPhat.Utilities;
using AnThinhPhat.Entities.Results;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AnThinhPhat.WebUI.Controllers
{
    public class ThuTucController : OfficeController
    {
        [Inject]
        public ILinhVucThuTucRepository LinhVucThuTucRepository { get; set; }

        [Inject]
        public ICoQuanRepository CoQuanRepository { get; set; }

        [Inject]
        public IThuTucRepository ThuTucRepository { get; set; }

        [Inject]
        public ITapTinThuTucRepository FilesRepository { get; set; }

        [HttpGet]
        public ActionResult Index(string thuTucCongViec, int? coQuanId, int? linhVucThuTucId)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var model = CreateVanBanModel(thuTucCongViec, coQuanId, linhVucThuTucId);
                return View(model);
            });
        }

        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            var init = IniViewModel();
            var model = new AddThuTucViewModel
            {
                CoQuanInfos = init.CoQuanInfos,
                LinhVucThuTucInfo = init.LinhVucThuTucInfo,
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Add(AddThuTucViewModel model)
        {
            var dataSave = new ThuTucResult
            {
                NoiDung = model.NoiDung,
                TenThuTuc = model.TenThuTuc,
                NgayBanHanh = model.NgayBanHanh,
                LoaiThuTucId = model.LinhVucThuTucId,
                CoQuanThucHienId = model.CoQuanThucHienId,
                CreatedBy = UserName,
            };

            var result = ThuTucRepository.Add(dataSave);

            if (result == Services.SaveResult.SUCCESS && dataSave.Id > 0)
                SaveFiles(dataSave.Id, model.Files);

            return RedirectToRoute(UrlLink.THUTUC_EDIT, new { tenthutuc = dataSave.TenThuTuc.RejectMarks(), id = dataSave.Id });
        }

        [HttpGet, Authorize]
        public ActionResult Edit(int id)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var data = ThuTucRepository.Single(id);
                var init = IniViewModel();
                var model = new EditThuTucViewModel
                {
                    CoQuanThucHienId = data.CoQuanThucHienId,
                    LinhVucThuTucId = data.LoaiThuTucId,
                    NgayBanHanh = data.NgayBanHanh,
                    NoiDung = data.NoiDung,
                    TenThuTuc = data.TenThuTuc,
                    TapTinThuTucResults = data.Files,
                    CoQuanInfos = init.CoQuanInfos,
                    LinhVucThuTucInfo = init.LinhVucThuTucInfo,
                };
                return View(model);
            });
        }

        [HttpPost, Authorize]
        public ActionResult Edit(int id, EditThuTucViewModel model)
        {
            var data = ThuTucRepository.Single(id);
            data.LoaiThuTucId = model.LinhVucThuTucId;
            data.CoQuanThucHienId = model.CoQuanThucHienId;
            data.NoiDung = model.NoiDung;
            data.NgayBanHanh = data.NgayBanHanh;
            data.TenThuTuc = model.TenThuTuc;
            data.LastUpdatedBy = UserName;

            var result = ThuTucRepository.Update(data);
            if (result == Services.SaveResult.SUCCESS)
                SaveFiles(id, model.Files);

            return RedirectToRoute(UrlLink.THUTUC);
        }

        public ActionResult List(ValueSearchViewModel search)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var model = Find(search);
                return PartialView("_PartialPageList", model);
            });
        }

        [Authorize]
        public ActionResult ViewThuTuc()
        {
            return View();
        }

        public ActionResult ViewList(int? page)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var model = Find(new ValueSearchViewModel
                {
                    Page = page ?? 1
                });
                return PartialView("_ViewList", model);
            });
        }

        [Authorize, HttpPost, ActionName("Delete")]
        public async Task<JsonResult> DeleteConfirmed(int id)
        {
            return await ExecuteWithErrorHandling(async () =>
            {
                if (id == 0)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json("Bad Request", JsonRequestBehavior.AllowGet);
                }

                return await ExecuteResultAsync(async () => await ThuTucRepository.DeleteByAsync(id));
            });
        }

        [HttpGet]
        public PartialViewResult Detail(int id)
        {
            var model = ThuTucRepository.Single(id);
            return PartialView("_PartialPageDetail", model);
        }

        private InitThuTucViewModel CreateVanBanModel(string thuTucCongViec, int? coQuanId, int? linhVucCongViecId)
        {
            var model = new InitThuTucViewModel
            {
                LinhVucThuTucInfo = LinhVucThuTucRepository.GetAll().Select(x => x.ToDataInfo()),
                CoQuanInfos = CoQuanRepository.GetAll().Select(x => x.ToDataInfo()),
                ValueSearch = new ValueSearchViewModel
                {
                    ThuTucCongViec = thuTucCongViec,
                    CoQuanId = coQuanId,
                    LinhVucThuTucId = linhVucCongViecId,
                    Page = 1,
                },
            };

            return model;
        }

        private IPagedList<ThuTucResult> Find(ValueSearchViewModel model)
        {
            var seachAll = ThuTucRepository.GetAll();
            if (!string.IsNullOrEmpty(model.ThuTucCongViec))
                seachAll = seachAll.Where(x => x.TenThuTuc.Contains(model.ThuTucCongViec));

            if (model.CoQuanId.HasValue)
                seachAll = seachAll.Where(x => x.CoQuanThucHienId == model.CoQuanId);

            if (model.LinhVucThuTucId.HasValue)
                seachAll = seachAll.Where(x => x.LoaiThuTucId == model.LinhVucThuTucId);

            return seachAll.ToPagedList(model.Page, TechOfficeConfig.PAGESIZE);
        }

        private ThuTucViewModel IniViewModel()
        {
            var data = new ThuTucViewModel
            {
                CoQuanInfos = CoQuanRepository.GetAll().Select(x => x.ToDataInfo()),
                LinhVucThuTucInfo = LinhVucThuTucRepository.GetAll().Select(x => x.ToDataInfo()),
            };

            return data;
        }

        private void SaveFiles(int id, IEnumerable<HttpPostedFileBase> files)
        {
            ExecuteTryLogException(() =>
            {
                foreach (var file in files)
                {
                    SaveFilesThuTuc(file, id);
                    FilesRepository.Add(new TapTinThuTucResult
                    {
                        ThuTucId = id,
                        CreatedBy = UserName,
                        UserUploadId = UserId,
                        Url = Path.Combine(TechOfficeConfig.FOLDER_TT, id.ToString().PadLeft(TechOfficeConfig.LENGTHFOLDER, TechOfficeConfig.PAD_CHAR), file.FileName),
                    });
                }
            });
        }

        private void SaveFilesThuTuc(HttpPostedFileBase file, int vanBanId)
        {
            var folderVanBan = EnsureFolderThuTuc(vanBanId);
            if (file.FileName != null)
            {
                var savedFileName = Path.Combine(folderVanBan, Path.GetFileName(file.FileName));
                try
                {
                    file.SaveAs(savedFileName); // Save the file
                }
                catch (Exception ex)
                {
                    LogService.Error($"Has error in while save file {file.FileName}", ex);
                }
            }
        }

        private string EnsureFolderThuTuc(int id)
        {
            try
            {
                //1. Get folder upload
                var folderUpload = Server.MapPath(TechOfficeConfig.FOLDER_UPLOAD_TT);
                EnsureFolder(folderUpload);

                var folderThuTuc = Path.Combine(folderUpload, id.ToString().PadLeft(TechOfficeConfig.LENGTHFOLDER, TechOfficeConfig.PAD_CHAR));
                EnsureFolder(folderThuTuc);

                return folderThuTuc;
            }
            catch (Exception ex)
            {
                LogService.Error("Has error in while create new Temp folder upload", ex);
                throw;
            }
        }

        private void EnsureFolder(string folder)
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
        }
    }
}