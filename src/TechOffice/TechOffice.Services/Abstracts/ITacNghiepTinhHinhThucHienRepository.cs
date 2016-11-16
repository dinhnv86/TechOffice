using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Repositories;
using System.Collections.Generic;
using AnThinhPhat.Utilities.Enums;

namespace AnThinhPhat.Services.Abstracts
{
    /// <summary>
    /// </summary>
    public interface ITacNghiepTinhHinhThucHienRepository : IRepository<TacNghiepTinhHinhThucHienResult>
    {
        IEnumerable<TacNghiepTinhHinhThucHienResult> GetAllByTacNghiepId(int id);

        SaveResult UpdateIncrementMucDoHoanThanh(int tacNghiepId, int coQuanId, string userName, EnumMucDoHoanThanh status);
    }
}