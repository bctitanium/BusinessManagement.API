using AutoMapper;
using BusinessManagement.API.DTOs;
using BusinessManagement.Contract;
using BusinessManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class BrandController : Controller
    {
        public readonly IMapper _mapper;
        public readonly IBrandRepository _brandRepository;

        public BrandController(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var brand = await _brandRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<BrandDTO>>(brand));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BrandDTO bdto, CancellationToken cancellationToken = default)
        {
            var brand = _mapper.Map<Brand>(bdto);

            _brandRepository.Add(brand);

            await _brandRepository.SaveChangesAsync(cancellationToken);

            return Ok(_mapper.Map<BrandDTO>(brand));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] BrandDTO bdto, int id, CancellationToken cancellationToken = default)
        {
            var brand = await _brandRepository.FindByIdAsync(id, cancellationToken);

            if (brand is null)
            {
                return NotFound();
            }

            _mapper.Map(bdto, brand);

            await _brandRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var brand = await _brandRepository.FindByIdAsync(id, cancellationToken);

            if (brand is null)
            {
                return NotFound();
            }

            _brandRepository.Delete(brand);

            await _brandRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}
