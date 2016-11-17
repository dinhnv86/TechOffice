using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Repositories;
using System.Collections.Generic;

namespace AnThinhPhat.Services.Abstracts
{
    /// <summary>
    /// </summary>
    public interface ICoQuanRepository : IRepository<CoQuanResult>
    {
        IEnumerable<CoQuanResult> GetAllByNhomCoQuanId(int id);
    }
}