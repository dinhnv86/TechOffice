using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Repositories;
using System.Collections.Generic;

namespace AnThinhPhat.Services.Abstracts
{
    /// <summary>
    /// </summary>
    public interface ITacNghiepTinhHinhThucHienRepository : IRepository<TacNghiepTinhHinhThucHienResult>
    {
        IEnumerable<TacNghiepTinhHinhThucHienResult> GetAllByTacNghiepId(int id);
    }
}