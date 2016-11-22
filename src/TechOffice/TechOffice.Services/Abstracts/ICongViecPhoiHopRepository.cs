using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Repositories;
using System.Collections.Generic;

namespace AnThinhPhat.Services.Abstracts
{
    /// <summary>
    /// </summary>
    public interface ICongViecPhoiHopRepository : IRepository<CongViecPhoiHopResult>
    {
        SaveResult AddOrUpdate(int congViecId, IEnumerable<CongViecPhoiHopResult> entities,string userName);
    }
}