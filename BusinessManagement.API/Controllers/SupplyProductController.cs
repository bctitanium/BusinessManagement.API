using AutoMapper;
using BusinessManagement.API.DTOs;
using BusinessManagement.Contract;
using BusinessManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class SupplyProductController : Controller
    {
        public readonly IMapper _mapper;
        public readonly ISupplyProductRepository _supplyProductRepository;

        public SupplyProductController(IMapper mapper, ISupplyProductRepository supplyProductRepository)
        {
            _mapper = mapper;
            _supplyProductRepository = supplyProductRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var supplyProduct = await _supplyProductRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<SupplyProductDTO>>(supplyProduct));
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplyProductDTO spdto, CancellationToken cancellationToken = default)
        {
            var supplyProduct = _mapper.Map<SupplyProduct>(spdto);

            _supplyProductRepository.Add(supplyProduct);

            await _supplyProductRepository.SaveChangesAsync(cancellationToken);

            return Ok(_mapper.Map<SupplyProductDTO>(supplyProduct));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] SupplyProductDTO spdto, int id, CancellationToken cancellationToken = default)
        {
            var supplyProduct = await _supplyProductRepository.FindByIdAsync(id, cancellationToken);

            if (supplyProduct is null)
            {
                return NotFound();
            }

            _mapper.Map(spdto, supplyProduct);

            await _supplyProductRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var supplyProduct = await _supplyProductRepository.FindByIdAsync(id, cancellationToken);

            if (supplyProduct is null)
            {
                return NotFound();
            }

            _supplyProductRepository.Delete(supplyProduct);

            await _supplyProductRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}
