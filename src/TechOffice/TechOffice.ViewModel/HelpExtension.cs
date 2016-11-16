using System;
using System.Linq;
using AnThinhPhat.Entities;
using AnThinhPhat.Entities.Infos;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.ViewModel.CoQuan;
using AnThinhPhat.ViewModel.Users;
using AnThinhPhat.ViewModel.TacNghiep;
using System.Security.Principal;
using System.Security.Claims;

namespace AnThinhPhat.ViewModel
{
    public static class HelpExtension
    {
        public static BaseDataViewModel ToIfNotNullDataViewModel(this DataResult entity)
        {
            return entity == null ? null : entity.ToDataViewModel();
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
                CoQuanInfos = entity.CoQuanInfos.Select(x => x.CoQuanInfos.Where(y => y.IsSelected)).Aggregate((a, b) => { return a.Concat(b); }),
            };
        }

        public static TResult ToDataResult<TResult>(this BaseDataViewModel entity) where TResult : DataResult
        {
            var type = typeof(TResult);
            var result = (TResult)Activator.CreateInstance(type);

            var proInfoFirsts = typeof(TResult).GetProperties();

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
            ClaimsIdentity claims = (ClaimsIdentity)identity;

            return claims.Claims.Where(x => x.Type == ClaimTypes.Surname).Select(x => x.Value).FirstOrDefault();
        }
    }
}