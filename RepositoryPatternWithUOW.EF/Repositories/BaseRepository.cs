using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core.intrefaces;
using System.Linq.Expressions;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T data)
        {
            if (data != null)
              await  _dbContext.AddAsync(data);
            return data;
        }

        public async Task<T> Find(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);   
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);

        }
    }
}
