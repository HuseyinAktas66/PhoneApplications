using PhoneApplications.Services.Report.Core.Repositories;
using PhoneApplications.Services.Report.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Report.Services.Service
{
    public class BaseService<T> : IBaseService<T> where T:class
    {
        private readonly IGenericRepository<T> _repository;
        public BaseService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.GetByFilterAsync(predicate);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.SingleOrDefaultAsync(predicate);
        }

        public T Update(T entity)
        {
            return _repository.Update(entity);
        }
    }
}
