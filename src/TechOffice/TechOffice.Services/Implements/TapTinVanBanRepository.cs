using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Abstracts;

namespace AnThinhPhat.Services.Implements
{
    public class TapTinVanBanRepository : DbExecute, ITapTinVanBanRepository
    {
        public SaveResult Add(TapTinVanBanResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> AddAsync(TapTinVanBanResult entity)
        {
            throw new NotImplementedException();
        }

        public SaveResult AddRange(IEnumerable<TapTinVanBanResult> entities)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> AddRangeAsync(IEnumerable<TapTinVanBanResult> entities)
        {
            throw new NotImplementedException();
        }

        public SaveResult Delete(TapTinVanBanResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> DeleteAsync(TapTinVanBanResult entity)
        {
            throw new NotImplementedException();
        }

        public SaveResult DeleteBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> DeleteByAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TapTinVanBanResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TapTinVanBanResult>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public TapTinVanBanResult Single(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TapTinVanBanResult> SingleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public SaveResult Update(TapTinVanBanResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> UpdateAsync(TapTinVanBanResult entity)
        {
            throw new NotImplementedException();
        }
    }
}
