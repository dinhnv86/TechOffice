using AnThinhPhat.Entities.Results;

namespace AnThinhPhat.ViewModel
{
    public static class HelpExtension
    {
        public static BaseDataViewModel ToIfNotNullDataViewModel(this ChucVuResult entity)
        {
            return entity == null ? null : entity.ToDataViewModel();
        }

        public static BaseDataViewModel ToDataViewModel(this ChucVuResult entity)
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
    }
}