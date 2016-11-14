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
            var urlFiles = EnsureFolderTacNghiep(id);

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
                      MoveFiles(model.Guid, entity.Id);
                  }

                  return saveResult;
              });
          });
        }

        [HttpGet]
        public PartialViewResult NoiDungYKienCuaCacCoQuan(int id)//TacNghiepId
        {
            var result = YKienCoQuanRepository.GetAll().Where(x => x.TacNghiepId == id);

            if (!User.IsInRole("Admin"))
            {
                var user = AuthInfo();
                result = result.Where(x => x.CoQuanId == user.CoQuanId);
            }
           
            return PartialView("_PartialPageNoiDungYKien", result);
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

        private void MoveFiles(string guid, int id)
        {
            try
            {
                string folderTemp = Path.Combine(Server.MapPath("~/Uploads"), guid);

                if (Directory.Exists(folderTemp) && Directory.GetFiles(folderTemp).Count() > 0)
                {
                    string folderTN = EnsureFolderTacNghiep(id);
                    foreach (var item in Directory.GetFiles(folderTemp))
                    {
                        string dest = Path.Combine(folderTN, Path.GetFileName(item));
                        System.IO.File.Move(item, dest);
                        HistoryMoveFiles(id, dest);
                    }

                    Directory.Delete(folderTemp);
                }
            }
            catch (Exception ex)
            {
                LogService.Error(string.Format("Has Error while move files from {0} to {1}", guid, id), ex);
            }
        }

        private void HistoryMoveFiles(int id, string url)
        {
            TapTinTacNghiepRepository.Add(new TapTinTacNghiepResult
            {
                TacNghiepId = id,
                UserUploadId = Convert.ToInt32(UserId),
                Url = url,
                CreatedBy = UserName,
            });
        }

        private string EnsureFolderTacNghiep(int id)
        {
            string folderParentTT = Server.MapPath("~/Uploads/TT");
            EnsureFolder(folderParentTT);

            string folderTT = Path.Combine(folderParentTT, id.ToString().PadLeft(TechOfficeConfig.LENGTHFOLDER, '0'));
            EnsureFolder(folderTT);

            string folderUser = Path.Combine(folderTT, UserId.PadLeft(TechOfficeConfig.LENGTHFOLDER, '0'));
            EnsureFolder(folderUser);

            return folderUser;
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
                json += "<a href=" + Url.Action("DownloadFile", new { path = path, file = Path.GetFileName(file) }) + ">" + Path.GetFileName(file) + "</a>" + "<br/>";
            }
            return json;
        }
    }
}