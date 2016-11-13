using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Repositories;
using System.Collections.Generic;

namespace AnThinhPhat.Services.Abstracts
{
    /// <summary>
    /// </summary>
    public interface ITacNghiepCoQuanLienQuanRepository : IRepository<TacNghiepCoQuanLienQuanResult>
    {
        IEnumerable<TacNghiepCoQuanLienQuanResult> GetAllByTacNghiepId(int id);
    }
}