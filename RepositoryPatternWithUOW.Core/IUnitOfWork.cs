﻿using RepositoryPatternWithUOW.Core.intrefaces;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Author> Authores { get; }
        IBaseRepository<Book> Books { get; }

        int Complete();

    }
}
