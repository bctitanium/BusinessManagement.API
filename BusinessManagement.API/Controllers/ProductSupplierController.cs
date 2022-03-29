using AutoMapper;
using BusinessManagement.API.DTOs;
using BusinessManagement.Contract;
using BusinessManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductSupplierController : Controller
    {
        public readonly IMapper _mapper;
        public readonly IProductSupplierRepository _productSupplierRepository;
        public readonly IStoreRepository _storeRepository;

        public ProductSupplierController(IMapper mapper, IProductSupplierRepository productSupplierRepository, IStoreRepository storeRepository)
        {
            _mapper = mapper;
            _productSupplierRepository = productSupplierRepository;
            _storeRepository = storeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var supplier = await _productSupplierRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<ProductSupplierDTO>>(supplier));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductSupplierDTO psdto, CancellationToken cancellationToken = default)
        {
            var supplier = _mapper.Map<ProductSupplier>(psdto);

            _productSupplierRepository.Add(supplier);

            await _productSupplierRepository.SaveChangesAsync(cancellationToken);

            return Ok(_mapper.Map<ProductSupplierDTO>(supplier));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ProductSupplierDTO psdto, int id, CancellationToken cancellationToken = default)
        {
            var supplier = await _productSupplierRepository.FindByIdAsync(id, cancellationToken);

            if (supplier is null)
            {
                return NotFound();
            }

            _mapper.Map(psdto, supplier);

            await _productSupplierRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        //còn cái put dài nữa

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var supplier = await _productSupplierRepository.FindByIdAsync(id, cancellationToken);

            if (supplier is null)
            {
                return NotFound();
            }

            _productSupplierRepository.Delete(supplier);

            await _productSupplierRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}
