using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core.intrefaces;
using RepositoryPatternWithUOW.Core.Models;

namespace RespositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBaseRepository<Book> _booksRepository;

        public BooksController(IBaseRepository<Book> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_booksRepository.GetById(1));
        }
    }
}
