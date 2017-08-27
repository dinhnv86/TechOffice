using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using AnThinhPhat.Entities;
using AnThinhPhat.Entities.Infos;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Entities.Searchs;
using AnThinhPhat.ViewModel.CoQuan;
using AnThinhPhat.ViewModel.TacNghiep;
using AnThinhPhat.ViewModel.Users;
using System.Collections.Generic;
using AnThinhPhat.ViewModel.News;
using AnThinhPhat.ViewModel.ThuTuc;
using AnThinhPhat.ViewModel.NewsCategories;
using AnThinhPhat.ViewModel.Menu;

namespace AnThinhPhat.ViewModel
{
    public static class HelpExtension
    {
        public static BaseDataViewModel ToIfNotNullDataViewModel(this DataResult entity)
        {
            return entity?.ToDataViewModel();
        }

        public static BaseDataViewModel ToDataViewModel(this DataResult entity)
        {
            return new BaseDataViewModel
            {
                Id = entity.Id,
                Name = entity.Ten,
                Description = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static CoQuanViewModel ToDataViewModel(this CoQuanResult entity)
        {
            return new CoQuanViewModel
            {
                Id = entity.Id,
                Name = entity.Ten,
                Description = entity.MoTa,
                NhomCoQuanId = entity.NhomCoQuanId,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static InitUserViewModel ToDataViewModel(this UserResult entity)
        {
            return new InitUserViewModel
            {
                Id = entity.Id,
                UserName = entity.UserName,
                ChucVuId = entity.ChucVuId,
                ChucVuInfo = entity.ChucVuInfo,
                FullName = entity.HoVaTen,
                Password = entity.Password,
                IsLocked = entity.IsLocked,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static AddRoleInfoViewModel ToRoleViewModel(this RoleResult entity)
        {
            return entity == null
                ? null
                : new AddRoleInfoViewModel
                {
                    Id = entity.Id,
                    Name = entity.Ten,
                    Display = entity.Display,
                    IsChecked = entity.IsChecked
                };
        }

        public static UserResult ToUseResult(this AddUserViewModel entity)
        {
            return entity == null
                ? null
                : new UserResult
                {
                    Id = entity.Id,
                    UserName = entity.UserName,
                    ChucVuId = entity.ChucVuId,
                    CoQuanId = entity.CoQuanId,
                    HoVaTen = entity.FullName,
                    UserRoles = entity.RoleInfos
                        .Where(x => x.IsChecked)
                        .Select(x => x.ToUserRoleResult())
                };
        }

        public static UserRoleInfo ToUserRoleResult(this AddRoleInfoViewModel entity)
        {
            return entity == null
                ? null
                : new UserRoleInfo
                {
                    RoleInfo = new RoleInfo
                    {
                        Id = entity.Id
                    }
                };
        }

        public static TacNghiepResult ToTacNghiepResult(this AddTacNghiepViewModel entity)
        {
            return new TacNghiepResult
            {
                LinhVucTacNghiepId = entity.LinhVucId,
                NgayHetHan = entity.NgayHetHan,
                NgayHoanThanh = entity.NgayHoanThanh,
                NgayTao = entity.NgayTao,
                NoiDung = entity.NoiDung,
                NoiDungTraoDoi = entity.NoiDungYKienTraoDoi,
                CoQuanInfos =
                    entity.CoQuanInfos.Select(x => x.CoQuanInfos.Where(y => y.IsSelected))
                        .Aggregate((a, b) => { return a.Concat(b); })
            };
        }

        public static ValueSearchTacNghiep ToValueSearch(this TacNghiep.ValueSearchViewModel valueSearch)
        {
            return new ValueSearchTacNghiep
            {
                CoQuanId = valueSearch.CoQuanId,
                LinhVucTacNghiepId = valueSearch.LinhVucTacNghiepId,
                MucDoHoanThanhId = valueSearch.MucDoHoanThanhId,
                NamBanHanhId = valueSearch.NamBanHanhId,
                NhomCoquanId = valueSearch.NhomCoquanId,
                NoiDungTimKiem = valueSearch.NoiDungTimKiem,
                SearchTypeValue = valueSearch.SearchTypeValue
            };
        }

        public static ValueSearchManagementCongViec ToValueSearch(this CongViec.ValueSearchViewModel valueSearch)
        {
            return new ValueSearchManagementCongViec
            {
                //From = valueSearch.From,
                //To = valueSearch.To,
                UserIds = valueSearch.UserIds,
                Areas = valueSearch.Areas,
                Content = valueSearch.Content,
                Roles = valueSearch.Roles,
                Status = valueSearch.Status,
                //SoVanBan = valueSearch.SoVanBan,
                //CoQuanId = valueSearch.CoQuanId
            };
        }

        public static NewsResult ToNewsResult(this AddNewsViewModel model)
        {
            return model == null ? null : new NewsResult
            {
                Id = model.Id,
                CreateDate = model.CreateDate,
                CreatedBy = model.CreatedBy,
                IsDeleted = model.IsDeleted,
                LastUpdated = model.LastUpdated,
                LastUpdatedBy = model.LastUpdatedBy,
                Content = model.Content,
                Summary = model.Summary,
                NewsCategoryId = model.NewsCategoryId,
                Title = model.Title,
                UrlImage = model.UrlImage,
            };
        }

        public static AddNewsViewModel ToViewModel(this NewsResult entity)
        {
            return entity == null ? null : new AddNewsViewModel
            {
                Id = entity.Id,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
                Content = entity.Content,
                Summary = entity.Summary,
                NewsCategoryId = entity.NewsCategoryId,
                Title = entity.Title,
                UrlImage = entity.UrlImage,
            };
        }

        public static LinhVucThuTucViewModel ToIfNotNullDataViewModel(this LinhVucThuTucResult entity)
        {
            return entity?.ToDataViewModel();
        }

        public static LinhVucThuTucViewModel ToDataViewModel(this LinhVucThuTucResult entity)
        {
            return new LinhVucThuTucViewModel
            {
                Id = entity.Id,
                Name = entity.Ten,
                ParentId = entity.ParentId,
                Position  =entity.Position,
                Description = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static NewsCategoryViewModel ToDataViewModel(this NewsCategoryResult entity)
        {
            return new NewsCategoryViewModel
            {
                Id = entity.Id,
                Name = entity.Ten,
                ParentId = entity.ParentId,
                Position = entity.Position,
                Description = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy
            };
        }

        public static PageReferenceResult ToDataResult(this PageReferenceViewModel model)
        {
            return model == null ? null : new PageReferenceResult
            {
                Id = model.Id,
                UrlLink = model.UrlLink,
                IsNewPage = model.IsNewPage,
                Alt = model.Alt,
                UrlImage = model.UrlImage,

                CreateDate = model.CreateDate,
                CreatedBy = model.CreatedBy,
                IsDeleted = model.IsDeleted,
                LastUpdated = model.LastUpdated,
                LastUpdatedBy = model.LastUpdatedBy,
            };
        }

        public static PageReferenceViewModel ToDataViewModel(this PageReferenceResult entity)
        {
            return entity == null ? null : new PageReferenceViewModel
            {
                Id = entity.Id,
                UrlLink = entity.UrlLink,
                IsNewPage = entity.IsNewPage,
                Alt = entity.Alt,
                UrlImage = entity.UrlImage,

                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }

        public static TResult ToDataResult<TResult>(this BaseDataViewModel entity) where TResult : DataResult
        {
            var type = typeof(TResult);
            var result = (TResult)Activator.CreateInstance(type);

            var proInfoFirsts = typeof(TResult).GetProperties().Where(x => x.Name.Equals("Id", StringComparison.OrdinalIgnoreCase) ||
            x.Name.Equals("Ten", StringComparison.OrdinalIgnoreCase) ||
            x.Name.Equals("MoTa", StringComparison.OrdinalIgnoreCase));

            foreach (var info in proInfoFirsts)
            {
                switch (info.Name)
                {
                    case "Id":
                        info.SetValue(result, entity.Id);
                        break;
                    case "Ten":
                        info.SetValue(result, entity.Name);
                        break;
                    case "MoTa":
                        info.SetValue(result, entity.Description);
                        break;
                }
            }

            return result;
        }

        public static TUpdate Update<TUpdate>(this TUpdate entity, Action<TUpdate> action)
        {
            action?.Invoke(entity);

            return entity;
        }

        public static string IfNotNull(this DataInfo entity, Func<DataInfo, string> func)
        {
            return entity == null
                ? string.Empty
                : func(entity);
        }

        public static string FullName(this IIdentity identity)
        {
            var claims = (ClaimsIdentity)identity;

            return claims.Claims.Where(x => x.Type == ClaimTypes.Surname).Select(x => x.Value).FirstOrDefault();
        }

        public static string ToAggregate(this IEnumerable<string> data)
        {
            return data != null && data.Any() ?
                  data.Aggregate((a, b) => (a + ", " + b)) :
                  string.Empty;
        }
    }
}