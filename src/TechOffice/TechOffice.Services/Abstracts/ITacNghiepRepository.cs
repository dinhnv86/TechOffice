using AnThinhPhat.Entities.Results;
using AnThinhPhat.Entities.Searchs;
using AnThinhPhat.Services.Repositories;
using System.Collections.Generic;

namespace AnThinhPhat.Services.Abstracts
{
    /// <summary>
    /// </summary>
    public interface ITacNghiepRepository : IRepository<TacNghiepResult>
    {
        SaveResult AddTacNghiepWithTinhHinhThucHien(TacNghiepResult entity);

        IEnumerable<TacNghiepResult> Find(ValueSearchTacNghiep valueSearch);
    }
}