using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Abstracts;

namespace AnThinhPhat.Services.Implements
{
    public class TacNghiepRepository : DbExecute, ITacNghiepRepository
    {
        public SaveResult Add(TacNghiepResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> AddAsync(TacNghiepResult entity)
        {
            throw new NotImplementedException();
        }

        public SaveResult AddRange(IEnumerable<TacNghiepResult> entities)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> AddRangeAsync(IEnumerable<TacNghiepResult> entities)
        {
            throw new NotImplementedException();
        }

        public SaveResult Delete(TacNghiepResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> DeleteAsync(TacNghiepResult entity)
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

        public IEnumerable<TacNghiepResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TacNghiepResult>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public TacNghiepResult Single(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TacNghiepResult> SingleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public SaveResult Update(TacNghiepResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> UpdateAsync(TacNghiepResult entity)
        {
            throw new NotImplementedException();
        }
    }
}
