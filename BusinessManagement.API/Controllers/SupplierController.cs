using AutoMapper;
using BusinessManagement.API.DTOs;
using BusinessManagement.Contract;
using BusinessManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class SupplierController : Controller
    {
        public readonly IMapper _mapper;
        public readonly ISupplierRepository _supplierRepository;

        public SupplierController(IMapper mapper, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var supplier = await _supplierRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<SupplierDTO>>(supplier));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SupplierDTO psdto, CancellationToken cancellationToken = default)
        {
            var supplier = _mapper.Map<Supplier>(psdto);

            _supplierRepository.Add(supplier);

            await _supplierRepository.SaveChangesAsync(cancellationToken);

            return Ok(_mapper.Map<SupplierDTO>(supplier));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] SupplierDTO psdto, int id, CancellationToken cancellationToken = default)
        {
            var supplier = await _supplierRepository.FindByIdAsync(id, cancellationToken);

            if (supplier is null)
            {
                return NotFound();
            }

            _mapper.Map(psdto, supplier);

            await _supplierRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var supplier = await _supplierRepository.FindByIdAsync(id, cancellationToken);

            if (supplier is null)
            {
                return NotFound();
            }

            _supplierRepository.Delete(supplier);

            await _supplierRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}
