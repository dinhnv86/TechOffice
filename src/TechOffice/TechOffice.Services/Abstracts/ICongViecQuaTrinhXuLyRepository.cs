using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Repositories;
using System.Collections.Generic;

namespace AnThinhPhat.Services.Abstracts
{
    /// <summary>
    /// </summary>
    public interface ICongViecQuaTrinhXuLyRepository : IRepository<CongViecQuaTrinhXuLyResult>
    {
        SaveResult UpdateRange(IEnumerable<CongViecQuaTrinhXuLyResult> entities);
    }
}