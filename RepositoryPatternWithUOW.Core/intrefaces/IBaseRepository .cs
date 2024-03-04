using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.intrefaces
{
    public interface IBaseRepository<T> where T :class
    {
        T GetById(int id);

        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Find(Expression<Func<T, bool>> expression);
        Task<T> Add(T data);
    }
}
