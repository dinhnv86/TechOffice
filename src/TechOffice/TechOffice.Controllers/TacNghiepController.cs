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
        public ActionResult Statistic()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            var coquanInfos = CoQuanRepository.GetAll().GroupBy(x => x.NhomCoQuan, x => x, (key, cq) =>
                      new InitCoQuanCoLienQuan
                      {
                          NhomCoQuan = key,
                          CoQuanInfo = cq.Select(q => q.ToDataInfo()).ToList(),
                      }).OrderBy(x => x.NhomCoQuan.Id).ToList();

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

            var coQuanInfos = CoQuanRepository.GetAll().GroupBy(x => x.NhomCoQuan, x => x, (key, cq) =>
                     new InitCoQuanCoLienQuan
                     {
                         NhomCoQuan = key,
                         CoQuanInfo = cq.Where(x => cqlq.Any(y => x.Id == y.CoQuanId)).Select(q => q.ToDataInfo().Update(x => x.IsSelected = true)).ToList(),
                     }).Where(x => x.CoQuanInfo.Count > 0).OrderBy(x => x.NhomCoQuan.Id).ToList();

            //var linhVucs = LinhVucTacNghiepRepository.GetAll().Select(x => x.ToDataInfo());

            //var ttth = TinhHinhThucHienRepository.GetAllByTacNghiepId(id);

            var result = TacNghiepRepository.Single(id);

            var detail = new DetailTacNghiepViewModel
            {
                NgayHetHan = result.NgayHetHan,
                NgayHoanThanh = result.NgayHoanThanh,
                NgayTao = result.NgayTao,
                NoiDung = result.NoiDung,
                NoiDungYKienTraoDoi = result.NoiDungTraoDoi,
                LinhVucString = result.LinhVucTacNghiepInfo.IfNotNull(x => x.Name),
                CoQuanInfos = coQuanInfos,
            };

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
                        System.IO.File.Move(item, Path.Combine(folderTN, Path.GetFileName(item)));
                    }

                    Directory.Delete(folderTemp);
                }
            }
            catch (Exception ex)
            {
                LogService.Error(string.Format("Has Error while move files from {0} to {1}", guid, id), ex);
            }
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
    }
}