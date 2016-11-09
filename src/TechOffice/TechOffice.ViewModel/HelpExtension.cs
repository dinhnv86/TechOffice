using AnThinhPhat.Entities;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.ViewModel.Users;
using System;
using System.Reflection;
using System.Linq;
using AnThinhPhat.Entities.Infos;

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

        public static InitUserViewModel ToDataViewModel(this UserResult entity)
        {
            return new InitUserViewModel
            {
                Id = entity.Id,
                UserName = entity.UserName,
                ChucVuId = entity.ChucVuId,
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
            return entity == null ? null :
                new AddRoleInfoViewModel
                {
                    Id = entity.Id,
                    Name = entity.Ten,
                    IsChecked = false,
                };
        }

        public static UserResult ToUseResult(this AddUserViewModel entity)
        {
            return entity == null ? null :
                  new UserResult
                  {
                      Id = entity.Id,
                      UserName = entity.UserName,
                      ChucVuId = entity.ChucVuId,
                      HoVaTen = entity.FullName,
                      UserRoles = entity.RoleInfos
                      .Where(x => x.IsChecked)
                      .Select(x => x.ToUserRoleResult())
                  };
        }

        public static UserRoleInfo ToUserRoleResult(this AddRoleInfoViewModel entity)
        {
            return entity == null ? null :
                new UserRoleInfo
                {
                    RoleInfo = new RoleInfo
                    {
                        Id = entity.Id
                    },
                };
        }

        public static TResult ToDataResult<TResult>(this BaseDataViewModel entity) where TResult : DataResult
        {
            Type type = typeof(TResult);
            var result = (TResult)Activator.CreateInstance(type);

            var proInfoFirsts = typeof(TResult).GetProperties();

            foreach (PropertyInfo info in proInfoFirsts)
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
    }
}