using AnThinhPhat.Entities.Results;
using AnThinhPhat.Entities.Searchs;
using AnThinhPhat.Services.Repositories;
using System;
using System.Collections.Generic;

namespace AnThinhPhat.Services.Abstracts
{
    /// <summary>
    /// </summary>
    public interface IHoSoCongViecRepository : IRepository<HoSoCongViecResult>
    {
        IEnumerable<HoSoCongViecResult> Find(ValueSearchCongViec valueSearch);

        IEnumerable<HoSoCongViecResult> Search(ValueSearchManagementCongViec valueSearch);

        SaveResult AddCongViecWithChildren(HoSoCongViecResult entity);

        IEnumerable<StatisticCongViec> Statistic(DateTime from, DateTime to);

        IEnumerable<SummariesCongViecResult> Summaries(DateTime from, DateTime to);
    }
}