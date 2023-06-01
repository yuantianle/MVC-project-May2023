using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCode.Contract.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly OnBoardingDbContext _dbContext;

        public BaseRepository(OnBoardingDbContext Context)
        {
            _dbContext = Context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<bool> GetExistsAsync(System.Linq.Expressions.Expression<Func<T, bool>>? filter = null)
        {
            if (filter == null) return false;
            return await _dbContext.Set<T>().Where(filter).AnyAsync();

            //employees.where(x => x.salary >4000).any()/count()>1;
        }
        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
        public async Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }   
    }
}
