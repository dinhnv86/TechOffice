using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Abstracts;

namespace AnThinhPhat.Services.Implements
{
    public class NhomCoQuanRepository : DbExecute, INhomCoQuanRepository
    {
        public SaveResult Add(NhomCoQuanResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> AddAsync(NhomCoQuanResult entity)
        {
            throw new NotImplementedException();
        }

        public SaveResult AddRange(IEnumerable<NhomCoQuanResult> entities)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> AddRangeAsync(IEnumerable<NhomCoQuanResult> entities)
        {
            throw new NotImplementedException();
        }

        public SaveResult Delete(NhomCoQuanResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> DeleteAsync(NhomCoQuanResult entity)
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

        public IEnumerable<NhomCoQuanResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NhomCoQuanResult>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public NhomCoQuanResult Single(int id)
        {
            throw new NotImplementedException();
        }

        public Task<NhomCoQuanResult> SingleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public SaveResult Update(NhomCoQuanResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> UpdateAsync(NhomCoQuanResult entity)
        {
            throw new NotImplementedException();
        }
    }
}
