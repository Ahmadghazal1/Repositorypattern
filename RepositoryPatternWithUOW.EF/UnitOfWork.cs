using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.intrefaces;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IBaseRepository<Author> Authores { get; private set; }
        public IBaseRepository<Book> Books { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
            Authores = new BaseRepository<Author>(_dbContext);
            Books = new BaseRepository<Book>(_dbContext);
        }
        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
