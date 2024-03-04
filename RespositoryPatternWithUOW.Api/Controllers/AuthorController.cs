using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.intrefaces;
using RepositoryPatternWithUOW.Core.Models;

namespace RespositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Authores.GetById(1));
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _unitOfWork.Authores.GetAll();
        }

        [HttpGet("FindAuthor")]
        public async Task<Author> GetByName(string name)
        {
            return await _unitOfWork.Authores.Find(x=> x.Name == name);
        }
        [HttpPost]
        public async Task<IActionResult> AddAuthor(Author author)
        {
            var DomainModel = await _unitOfWork.Authores.Add(author);
            return Ok(DomainModel);

        }

    }
}
