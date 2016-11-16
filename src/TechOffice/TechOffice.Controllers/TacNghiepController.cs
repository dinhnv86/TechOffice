using System.Linq;
using System.Web.Mvc;
using AnThinhPhat.Entities;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.ViewModel.TacNghiep;
using Ninject;
using System;
using AnThinhPhat.ViewModel;
using System.Threading.Tasks;
using System.IO;
using AnThinhPhat.Utilities;
using PagedList;
using AnThinhPhat.Entities.Results;
using System.Collections.Generic;
using System.Web;

namespace AnThinhPhat.WebUI.Controllers
{
    [Authorize]
    public class TacNghiepController : OfficeController
    {
        [Inject]
        public ILinhVucTacNghiepRepository LinhVucTacNghiepRepository { get; set; }

        [Inject]
        public INhomCoQuanRepository NhomCoQuanRepository { get; set; }

        [Inject]
        public ICoQuanRepository CoQuanRepository { get; set; }

        [Inject]
        public IMucDoHoanThanhRepository MucDoHoanThanhRepository { get; set; }

        [Inject]
        public ITacNghiepRepository TacNghiepRepository { get; set; }

        [Inject]
        public ITacNghiepCoQuanLienQuanRepository CoQuanCoLienQuanRepository { get; set; }

        [Inject]
        public ITacNghiepTinhHinhThucHienRepository TinhHinhThucHienRepository { get; set; }

        [Inject]
        public ITacNghiepYKienCoQuanRepository YKienCoQuanRepository { get; set; }

        [Inject]
        public ITapTinTacNghiepRepository TapTinTacNghiepRepository { get; set; }

        [Inject]
        public ITapTinYKienCoQuanRepository TapTinYKienCoQuanRepository { get; set; }

        [HttpGet]
        public ActionResult Index(int? nhomCoquanId,
            int? coQuanId,
            int? linhVucTacNghiepId,
            int? mucDoHoanThanhId,
            int? namBanHanhId,
            string nhapThongTinTimKiem,
            string tieuChiTimKiem)
        {
            var model = CreateTacNghiepModel();

            model.ValueSearch.NhomCoquanId = nhomCoquanId;
            model.ValueSearch.CoQuanId = coQuanId;
            model.ValueSearch.LinhVucTacNghiepId = linhVucTacNghiepId;
            model.ValueSearch.MucDoHoanThanhId = mucDoHoanThanhId;
            model.ValueSearch.NamBanHanhId = namBanHanhId;
            model.ValueSearch.NhapThongTinTimKiem = nhapThongTinTimKiem;
            model.ValueSearch.TieuChiTimKiem = tieuChiTimKiem;
            model.ValueSearch.Page = 1;

            return View(model);
        }

        public ActionResult List(ValueSearchViewModel search)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var model = Find(search);
                return View("_PartialPageList", model);
            });
        }

        [HttpGet]
        public ActionResult Statistic(int? nhomCoQuanId, int? coQuanId, int? linhVucTacNghiepId, int? mucDoHoanThanhId, DateTime? from, DateTime? to, string submit)
        {
            var dataBind = CreateTacNghiepModel();
            var model = new InitTacNghiepThongKeViewModel
            {
                CoQuanInfos = dataBind.CoQuanInfos,
                LinhVucTacNghiepInfo = dataBind.LinhVucTacNghiepInfo,
                MucDoHoanThanhInfo = dataBind.MucDoHoanThanhInfo,
                NhomCoQuanInfos = dataBind.NhomCoQuanInfos,
            };

            if (!string.IsNullOrEmpty(submit))
            {
                model.IsShowResult = true;
                switch (submit.ToUpper())
                {
                    case "SB01":
                        model.TypeStatistic = "T01";
                        break;
                    case "SB02":
                        model.TypeStatistic = "T02";
                        break;
                }
                model.ValueSearch = new ValueSearchStatisticViewModel
                {
                    CoQuanId = coQuanId,
                    NhomCoquanId = nhomCoQuanId,
                    LinhVucTacNghiepId = linhVucTacNghiepId,
                    MucDoHoanThanhId = mucDoHoanThanhId,
                    From = from,
                    To = to
                };
            }
            else
            {
                model.IsShowResult = false;
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult StatisticCongViec(ValueSearchStatisticViewModel model)
        {
            var find = Find(model);
            List<TacNghiepTinhHinhThucHienResult> tinhHinhThucHienByTacNghiep = new List<TacNghiepTinhHinhThucHienResult>();
            find.ToList().ForEach(x =>
            {
                tinhHinhThucHienByTacNghiep.AddRange(TinhHinhThucHienRepository.GetAll().Where(t => t.TacNghiepId == x.Id));
            });

            var result = tinhHinhThucHienByTacNghiep.GroupBy(x => x.TacNghiepInfo, y => y, (a, b) =>
            {
                return new ResultStatisticByCongViecViewModel
                {
                    NgayTao = a.NgayTao,
                    Name = a.NoiDung,
                    NotExecuteResults = b.Where(w => w.MucDoHoanThanhId == (int)EnumMucDoHoanThanh.CHUATHUHIEN).Select(s => new ResultCoQuanThucHien
                    {
                        Name = s.CoQuanInfo.Name,
                    }),
                    ExecutingResults = b.Where(w => w.MucDoHoanThanhId == (int)EnumMucDoHoanThanh.DANGTHUCHIEN).Select(s => new ResultCoQuanThucHien
                    {
                        Name = s.CoQuanInfo.Name,
                    }),
                    ExecutedResults = b.Where(w => w.MucDoHoanThanhId == (int)EnumMucDoHoanThanh.DATHUCHIEN).Select(s => new ResultCoQuanThucHien
                    {
                        Name = s.CoQuanInfo.Name,
                        NgayHoanThanh = a.NgayHoanThanh,
                    }),
                };
            });

            return PartialView("_PartialPageStatisticCongViec", result);
        }

        public ActionResult StatisticCoQuan(ValueSearchStatisticViewModel model)
        {
            var find = Find(model);

            List<TacNghiepTinhHinhThucHienResult> tinhHinhThucHienByTacNghiep = new List<TacNghiepTinhHinhThucHienResult>();
            find.ToList().ForEach(x =>
            {
                tinhHinhThucHienByTacNghiep.AddRange(TinhHinhThucHienRepository.GetAll().Where(t => t.TacNghiepId == x.Id));
            });

            var result = tinhHinhThucHienByTacNghiep.GroupBy(x => x.CoQuanInfo, y => y, (a, b) =>
            {
                return new ResultStatisticByCoQuanViewModel
                {
                    Name = a.Name,
                    NotExecuteResults = b.Where(x => x.MucDoHoanThanhId == (int)EnumMucDoHoanThanh.CHUATHUHIEN).Select(s => new ResultCongViecThucHien
                    {
                        Name = s.TacNghiepInfo.NoiDung,
                    }),
                    ExecutingResults = b.Where(w => w.MucDoHoanThanhId == (int)EnumMucDoHoanThanh.DANGTHUCHIEN).Select(s => new ResultCongViecThucHien
                    {
                        Name = s.TacNghiepInfo.NoiDung,
                    }),
                    ExecutedResults = b.Where(w => w.MucDoHoanThanhId == (int)EnumMucDoHoanThanh.DATHUCHIEN).Select(s => new ResultCongViecThucHien
                    {
                        Name = s.TacNghiepInfo.NoiDung,
                    }),
                };
            });

            return PartialView("_PartialPageStatisticCoQuan", result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<InitCoQuanCoLienQuan> coquanInfos = new List<InitCoQuanCoLienQuan>();
            NhomCoQuanRepository.GetAllWithChildren().ToList().ForEach(x =>
            {
                coquanInfos.Add(new InitCoQuanCoLienQuan
                {
                    NhomCoQuan = new Entities.Infos.NhomCoQuanInfo
                    {
                        Id = x.Id,
                        Name = x.Ten,
                    },
                    CoQuanInfo = x.CoQuanResult.Select(s => s.ToDataInfo()).ToList()
                });
            });

            var linhVucs = LinhVucTacNghiepRepository.GetAll().Select(x => x.ToDataInfo());

            var model = new AddTacNghiepViewModel
            {
                Guid = Guid.NewGuid().ToString(),
                NgayTao = DateTime.Now,
                NgayHetHan = DateTime.Now,
                NgayHoanThanh = DateTime.Now,
                CoQuanInfos = coquanInfos,
                LinhVucInfos = linhVucs,
            };

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var cqlq = CoQuanCoLienQuanRepository.GetAllByTacNghiepId(id);

            var result = TacNghiepRepository.Single(id);

            //get files in folder upload
            var urlFiles = EnsureFolderTacNghiepWithUser(id);

            var detail = new DetailTacNghiepViewModel
            {
                Id = id,
                NgayHetHan = result.NgayHetHan,
                NgayHoanThanh = result.NgayHoanThanh,
                NgayTao = result.NgayTao,
                NoiDung = result.NoiDung,
                NoiDungYKienTraoDoi = result.NoiDungTraoDoi,
                LinhVucString = result.LinhVucTacNghiepInfo.IfNotNull(x => x.Name),
                CoQuanInfos = cqlq,
                JsonFiles = GetPathFiles(urlFiles),
            };

            //Update status for tinhinhcongviec

            return View(detail);
        }

        [HttpPost, ActionName("Add")]
        public JsonResult AddRecord(AddTacNghiepViewModel model)
        {
            return ExecuteWithErrorHandling(() =>
          {
              var entity = model.ToTacNghiepResult().Update(x =>
              {
                  x.CreatedBy = UserName;
              });
              return ExecuteResult(() =>
              {
                  var saveResult = TacNghiepRepository.AddTacNghiepWithCoQuan(entity);

                  if (entity.Id > 0)
                  {
                      MoveFilesTacNghiep(model.Guid, entity.Id);
                  }

                  return saveResult;
              });
          });
        }

        [HttpGet]
        public PartialViewResult NoiDungYKienCuaCacCoQuan(int id)//TacNghiepId
        {
            var result = YKienCoQuanRepository.GetAll().Where(x => x.TacNghiepId == id);
            var user = AuthInfo();

            if (!User.IsInRole(RoleConstant.ADMIN) || !User.IsInRole(RoleConstant.SUPPER_ADMIN))
            {
                result = result.Where(x => x.CoQuanId == user.CoQuanId);
            }

            result.ToList().ForEach(x =>
            {
                //Get files by yKienCoQuanId
                string path = EnsureFolderTacNghiepWithCoQuan(x.TacNghiepId, x.Id);
                x.JsonFiles = GetPathFiles(path);
            });

            var model = new InitNoiDungYKienCuaCacCoQuanViewModel
            {
                CoQuanId = user.CoQuanId,
                TacNghiepId = id,
                CacYKienCuaCoQuanResult = result,
            };

            return PartialView("_PartialPageNoiDungYKien", model);
        }

        [HttpGet]
        public PartialViewResult TinhHinhThucHien(int id)//TacNghiepId
        {
            var result = TinhHinhThucHienRepository.GetAll().Where(x => x.TacNghiepId == id);
            return PartialView("_PartialPageTinhHinhThucHien", result);
        }

        [ChildActionOnly]
        public PartialViewResult CoQuanLienQuan(int? id) //id: tacNghiepId
        {
            var model = CoQuanRepository.GetAll().GroupBy(x => x.NhomCoQuan, x => x, (key, cq) =>
                     new InitCoQuanCoLienQuan
                     {
                         NhomCoQuan = key,
                         CoQuanInfo = cq.Select(q => q.ToDataInfo()).ToList(),
                     });

            return PartialView("_PartialPageGroupListBodies", model);
        }

        [HttpGet]
        public PartialViewResult EditYKien(int id)//id y kien cua cac co quan
        {
            var model = YKienCoQuanRepository.Single(id);
            return PartialView("_PartialPageNoiDungYKienEdit", model);
        }

        [HttpPost]
        public JsonResult EditYKien(int id, string noiDung)//id y kien co quan
        {
            return ExecuteWithErrorHandling(() =>
            {
                var model = YKienCoQuanRepository.Single(id);
                model.NoiDung = noiDung;

                return ExecuteResult(() =>
                {
                    return YKienCoQuanRepository.Update(model);
                });
            });
        }

        [HttpGet]
        public PartialViewResult AddYKien(int tacNghiepId, int coQuanId)
        {
            var model = new EditNoiDungYKienCuaCoQuan
            {
                TacNghiepId = tacNghiepId,
                CoQuanId = coQuanId,
                NoiDung = string.Empty,
                Guid = Guid.NewGuid().ToString(),
            };
            return PartialView("_PartialPageNoiDungYKienAdd", model);
        }

        [HttpPost]
        public JsonResult AddYKien(int tacNghiepId, int coQuanId, string guid, string noiDung)
        {
            return ExecuteWithErrorHandling(() =>
            {
                return ExecuteResult(() =>
                {
                    var add = new TacNghiepYKienCoQuanResult
                    {
                        CoQuanId = coQuanId,
                        TacNghiepId = tacNghiepId,
                        NoiDung = noiDung,
                        CreatedBy = UserName,
                    };

                    //1. Save data to DB
                    var save = YKienCoQuanRepository.Add(add);
                    //2. Move files temp into the upload folder
                    MoveFilesYKienCuaCacCoQuan(guid, tacNghiepId, add.Id);

                    return save;
                });
            });
        }

        [NonAction]
        private InitTacNghiepViewModel CreateTacNghiepModel()
        {
            var model = new InitTacNghiepViewModel
            {
                LinhVucTacNghiepInfo = LinhVucTacNghiepRepository.GetAll().Select(x => x.ToIfNotNullDataInfo()),
                CoQuanInfos = CoQuanRepository.GetAll().Select(x => x.ToIfNotNullDataInfo()),
                NhomCoQuanInfos = NhomCoQuanRepository.GetAll().Select(x => x.ToIfNotNullDataInfo()),
                MucDoHoanThanhInfo = MucDoHoanThanhRepository.GetAll()
            };

            return model;
        }

        private IPagedList<TacNghiepResult> Find(ValueSearchViewModel model)
        {
            var seachAll = TacNghiepRepository.GetAll();
            if (model.CoQuanId.HasValue)
                seachAll = seachAll.Where(x => x.CoQuanInfos.Any(y => y.Id == model.CoQuanId.Value));

            if (model.LinhVucTacNghiepId.HasValue)
                seachAll = seachAll.Where(x => x.LinhVucTacNghiepId == model.LinhVucTacNghiepId.Value);

            if (model.MucDoHoanThanhId.HasValue)
                seachAll = seachAll.Where(x => x.MucDoHoanThanhId == model.MucDoHoanThanhId.Value);

            if (model.NamBanHanhId.HasValue)
                seachAll = seachAll.Where(x => x.NgayTao.Year == model.NamBanHanhId.Value);

            if (!string.IsNullOrEmpty(model.NhapThongTinTimKiem))
                seachAll = seachAll.Where(x => x.NoiDung.Contains(model.NhapThongTinTimKiem));

            if (!string.IsNullOrEmpty(model.TieuChiTimKiem))
                seachAll = seachAll.Where(x => x.NoiDungTraoDoi.Contains(model.TieuChiTimKiem));

            return seachAll.ToPagedList(model.Page, TechOfficeConfig.PAGESIZE);
        }

        private IEnumerable<TacNghiepResult> Find(ValueSearchStatisticViewModel model)
        {
            var all = TacNghiepRepository.GetAll();

            if (model.CoQuanId.HasValue)
                all.ToList().ForEach(a => { a.CoQuanInfos = a.CoQuanInfos.Where(x => x.Id == model.CoQuanId.Value); });

            if (model.LinhVucTacNghiepId.HasValue)
                all = all.Where(x => x.LinhVucTacNghiepId == model.LinhVucTacNghiepId.Value);

            if (model.MucDoHoanThanhId.HasValue)
                all = all.Where(x => x.MucDoHoanThanhId == model.MucDoHoanThanhId.Value);

            if (model.From.HasValue)
                all = all.Where(x => x.NgayTao >= model.From.Value);

            if (model.To.HasValue)
                all = all.Where(x => x.NgayTao <= model.To.Value);

            return all;
        }

        private void MoveFilesTacNghiep(string guid, int tacNghiepId)
        {
            try
            {
                string folderTemp = Path.Combine(Server.MapPath(TechOfficeConfig.FOLDER_UPLOAD), guid);

                if (Directory.Exists(folderTemp) && Directory.GetFiles(folderTemp).Count() > 0)
                {
                    string folderTN = EnsureFolderTacNghiepWithUser(tacNghiepId);
                    foreach (var item in Directory.GetFiles(folderTemp))
                    {
                        string dest = Path.Combine(folderTN, Path.GetFileName(item));
                        System.IO.File.Move(item, dest);
                        HistoryMoveFilesTacNghiep(tacNghiepId, dest);
                    }

                    Directory.Delete(folderTemp);
                }
            }
            catch (Exception ex)
            {
                LogService.Error(string.Format("Has Error while move files from {0} to {1}", guid, tacNghiepId), ex);
            }
        }

        private void MoveFilesYKienCuaCacCoQuan(string guid, int tacNghiepId, int yKienCuaCacCoQuanId)
        {
            try
            {
                string folderTemp = Path.Combine(Server.MapPath(TechOfficeConfig.FOLDER_UPLOAD), guid);

                if (Directory.Exists(folderTemp) && Directory.GetFiles(folderTemp).Count() > 0)
                {
                    string folderTN = EnsureFolderTacNghiepWithCoQuan(tacNghiepId, yKienCuaCacCoQuanId);
                    foreach (var item in Directory.GetFiles(folderTemp))
                    {
                        string dest = Path.Combine(folderTN, Path.GetFileName(item));
                        System.IO.File.Move(item, dest);
                        HistoryMoveFilesYKienCoQuan(yKienCuaCacCoQuanId, dest);
                    }

                    Directory.Delete(folderTemp);
                }
            }
            catch (Exception ex)
            {
                LogService.Error(string.Format("Has Error while move files from {0} to {1}", guid, tacNghiepId), ex);
            }
        }

        private void HistoryMoveFilesTacNghiep(int tacNghiepId, string url)
        {
            TapTinTacNghiepRepository.Add(new TapTinTacNghiepResult
            {
                TacNghiepId = tacNghiepId,
                UserUploadId = UserId,
                Url = url,
                CreatedBy = UserName,
            });
        }

        private void HistoryMoveFilesYKienCoQuan(int yKienCoQuanId, string url)
        {
            TapTinYKienCoQuanRepository.Add(new TapTinYKienCoQuanResult
            {
                YKienCoQuanId = yKienCoQuanId,
                Url = url,
                CreatedBy = UserName,
                UserUploadId = UserId,
            });
        }

        private string EnsureFolderTacNghiepWithUser(int tacNghiepId)//
        {
            string folderTT = EnsureFolderTacNghiep(tacNghiepId);

            string folderUser = Path.Combine(folderTT, UserId.ToString().PadLeft(TechOfficeConfig.LENGTHFOLDER, TechOfficeConfig.PADDING_CHAR));
            EnsureFolder(folderUser);

            return folderUser;
        }

        private string EnsureFolderTacNghiepWithCoQuan(int tacNghiepId, int yKienCoQuanId)//
        {
            string folderTT = EnsureFolderTacNghiep(tacNghiepId);

            string folderCoQuan = Path.Combine(folderTT, yKienCoQuanId.ToString().PadLeft(TechOfficeConfig.LENGTHFOLDER, TechOfficeConfig.PADDING_CHAR));
            EnsureFolder(folderCoQuan);

            return folderCoQuan;
        }

        private string EnsureFolderTacNghiep(int tacNghiepId)
        {
            string folderParentTN = Server.MapPath(TechOfficeConfig.FOLDER_UPLOAD_TACNGHIEP);
            EnsureFolder(folderParentTN);

            string folderTN = Path.Combine(folderParentTN, tacNghiepId.ToString().PadLeft(TechOfficeConfig.LENGTHFOLDER, TechOfficeConfig.PADDING_CHAR));
            EnsureFolder(folderTN);

            return folderTN;
        }

        private void EnsureFolder(string folder)
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
        }

        private string GetPathFiles(string path)
        {
            var files = Directory.GetFiles(path);
            string json = string.Empty;
            foreach (string file in files)
            {
                json += "<a href=" + Url.Action("DownloadFile", "File", new { path = path, file = Path.GetFileName(file) }) + ">" + Path.GetFileName(file) + "</a>" + "<br/>";
            }
            return json;
        }
    }
}