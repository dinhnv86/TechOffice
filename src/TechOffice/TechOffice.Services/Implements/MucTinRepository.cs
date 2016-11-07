using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Abstracts;

namespace AnThinhPhat.Services.Implements
{
    public class MucTinRepository : DbExecute, IMucTinRepository
    {
        public SaveResult Add(MucTinResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> AddAsync(MucTinResult entity)
        {
            throw new NotImplementedException();
        }

        public SaveResult AddRange(IEnumerable<MucTinResult> entities)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> AddRangeAsync(IEnumerable<MucTinResult> entities)
        {
            throw new NotImplementedException();
        }

        public SaveResult Delete(MucTinResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> DeleteAsync(MucTinResult entity)
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

        public IEnumerable<MucTinResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MucTinResult>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public MucTinResult Single(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MucTinResult> SingleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public SaveResult Update(MucTinResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> UpdateAsync(MucTinResult entity)
        {
            throw new NotImplementedException();
        }
    }
}
