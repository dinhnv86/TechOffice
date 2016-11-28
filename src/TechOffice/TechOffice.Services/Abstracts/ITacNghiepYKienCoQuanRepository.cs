using AnThinhPhat.Entities.Infos;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Repositories;
using System.Collections.Generic;

namespace AnThinhPhat.Services.Abstracts
{
    /// <summary>
    /// </summary>
    public interface ITacNghiepYKienCoQuanRepository : IRepository<TacNghiepYKienCoQuanResult>
    {
        IEnumerable<TacNghiepYKienCoQuanResult> GetByTacNghiepId(int tacNghiepId);

        SaveResult ReplyYKien(NoiDungTraLoiInfo reply);

        NoiDungTraLoiInfo GetReplyYKien(int id);
    }
}