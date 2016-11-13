using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Repositories;

namespace AnThinhPhat.Services.Abstracts
{
    /// <summary>
    /// </summary>
    public interface ITacNghiepRepository : IRepository<TacNghiepResult>
    {
        SaveResult AddTacNghiepWithCoQuan(TacNghiepResult entity);
    }
}