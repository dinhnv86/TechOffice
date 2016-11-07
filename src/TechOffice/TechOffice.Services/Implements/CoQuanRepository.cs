using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Abstracts;

namespace AnThinhPhat.Services.Implements
{
    public class CoQuanRepository : DbExecute, ICoQuanRepository
    {
        public SaveResult Add(CoQuanResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> AddAsync(CoQuanResult entity)
        {
            throw new NotImplementedException();
        }

        public SaveResult AddRange(IEnumerable<CoQuanResult> entities)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> AddRangeAsync(IEnumerable<CoQuanResult> entities)
        {
            throw new NotImplementedException();
        }

        public SaveResult Delete(CoQuanResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> DeleteAsync(CoQuanResult entity)
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

        public IEnumerable<CoQuanResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CoQuanResult>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public CoQuanResult Single(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CoQuanResult> SingleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public SaveResult Update(CoQuanResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> UpdateAsync(CoQuanResult entity)
        {
            throw new NotImplementedException();
        }
    }
}
