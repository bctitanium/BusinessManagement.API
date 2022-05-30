using AutoMapper;
using BusinessManagement.API.DTOs;
using BusinessManagement.Contract;
using BusinessManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        public readonly IMapper _mapper;
        public readonly IProductRepository _productRepository;

        public ProductController(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<ProductDTO>>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDTO pdto, CancellationToken cancellationToken = default)
        {
            var product = _mapper.Map<Product>(pdto);

            _productRepository.Add(product);

            await _productRepository.SaveChangesAsync(cancellationToken);

            return Ok(_mapper.Map<ProductDTO>(product));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductDTO pdto, int id, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.FindByIdAsync(id, cancellationToken);

            if (product is null)
            {
                return NotFound();
            }

            _mapper.Map(pdto, product);

            await _productRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.FindByIdAsync(id, cancellationToken);

            if (product is null)
            {
                return NotFound();
            }

            _productRepository.Delete(product);

            await _productRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}
