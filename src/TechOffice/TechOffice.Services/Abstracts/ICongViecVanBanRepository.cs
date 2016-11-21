using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Repositories;
using System.Collections.Generic;

namespace AnThinhPhat.Services.Abstracts
{
    /// <summary>
    /// </summary>
    public interface ICongViecVanBanRepository : IRepository<CongViecVanBanResult>
    {
        SaveResult UpdateRange(IEnumerable<CongViecVanBanResult> entities);
    }
}