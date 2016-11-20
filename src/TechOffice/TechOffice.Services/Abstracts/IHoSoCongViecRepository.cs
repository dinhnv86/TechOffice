using AnThinhPhat.Entities.Results;
using AnThinhPhat.Entities.Searchs;
using AnThinhPhat.Services.Repositories;
using System.Collections.Generic;

namespace AnThinhPhat.Services.Abstracts
{
    /// <summary>
    /// </summary>
    public interface IHoSoCongViecRepository : IRepository<HoSoCongViecResult>
    {
        IEnumerable<HoSoCongViecResult> Find(ValueSearchCongViec valueSearch);

        SaveResult AddCongViecWithChildren(HoSoCongViecResult entity);
    }
}