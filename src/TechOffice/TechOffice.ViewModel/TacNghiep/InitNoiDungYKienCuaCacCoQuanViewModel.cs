using AnThinhPhat.Entities.Results;
using System.Collections.Generic;

namespace AnThinhPhat.ViewModel.TacNghiep
{
    public class InitNoiDungYKienCuaCacCoQuanViewModel
    {
        public int TacNghiepId { get; set; }

        public int CoQuanId { get; set; }

        public IEnumerable<TacNghiepYKienCoQuanResult> CacYKienCuaCoQuanResult { get; set; }
    }
}
