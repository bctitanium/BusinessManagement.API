using AutoMapper;
using BusinessManagement.API.DTOs;
using BusinessManagement.Contract;
using BusinessManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        public readonly IMapper _mapper;
        public readonly ICategoryRepository _categoryRepository;

        public CategoryController(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var category = await _categoryRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<CategoryDTO>>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDTO cdto, CancellationToken cancellationToken = default)
        {
            var category = _mapper.Map<Category>(cdto);

            _categoryRepository.Add(category);

            await _categoryRepository.SaveChangesAsync(cancellationToken);

            return Ok(_mapper.Map<CategoryDTO>(category));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CategoryDTO cdto, int id, CancellationToken cancellationToken = default)
        {
            var category = await _categoryRepository.FindByIdAsync(id, cancellationToken);

            if (category is null)
            {
                return NotFound();
            }

            _mapper.Map(cdto, category);

            await _categoryRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var category = await _categoryRepository.FindByIdAsync(id, cancellationToken);

            if (category is null)
            {
                return NotFound();
            }

            _categoryRepository.Delete(category);

            await _categoryRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}
