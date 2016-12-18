using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Repositories;
using System.Collections.Generic;

namespace AnThinhPhat.Services.Abstracts
{
    /// <summary>
    /// </summary>
    public interface INewsRepository : IRepository<NewsResult>
    {
        IEnumerable<NewsResult> GetAllByNewsCategoryId(int id);
    }
}