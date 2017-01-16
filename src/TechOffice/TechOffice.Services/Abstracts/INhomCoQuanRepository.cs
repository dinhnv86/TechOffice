using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Repositories;
using System.Collections.Generic;

namespace AnThinhPhat.Services.Abstracts
{
    /// <summary>
    /// </summary>
    public interface INhomCoQuanRepository : IRepository<NhomCoQuanResult>
    {
        IEnumerable<NhomCoQuanResult> GetAllWithChildren();

        NhomCoQuanResult GetById(int id);
    }
}