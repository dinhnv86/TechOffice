using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Repositories;
using System.Collections.Generic;

namespace AnThinhPhat.Services.Abstracts
{
    /// <summary>
    /// </summary>
    public interface ITapTinVanBanRepository : IRepository<TapTinVanBanResult>
    {
        IEnumerable<TapTinVanBanResult> GetAllByVanBanId(int id);
    }
}