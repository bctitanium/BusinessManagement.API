using AutoMapper;
using BusinessManagement.API.DTOs;
using BusinessManagement.Contract;
using BusinessManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class DetailedReceiptController : Controller
    {
        public readonly IMapper _mapper;
        public readonly IDetailedReceiptRepository _detailedReceiptRepository;

        public DetailedReceiptController(IMapper mapper, IDetailedReceiptRepository detailedReceiptRepository)
        {
            _mapper = mapper;
            _detailedReceiptRepository = detailedReceiptRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var detailedReceipt = await _detailedReceiptRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<DetailedReceiptDTO>>(detailedReceipt));
        }

        [HttpPost]
        public async Task<IActionResult> Create(DetailedReceiptDTO drdto, CancellationToken cancellationToken = default)
        {
            var detailedReceipt = _mapper.Map<DetailedReceipt>(drdto);

            _detailedReceiptRepository.Add(detailedReceipt);

            await _detailedReceiptRepository.SaveChangesAsync(cancellationToken);

            return Ok(_mapper.Map<CategoryDTO>(detailedReceipt));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] DetailedReceiptDTO drdto, int id, CancellationToken cancellationToken = default)
        {
            var detailedReceipt = await _detailedReceiptRepository.FindByIdAsync(id, cancellationToken);

            if (detailedReceipt is null)
            {
                return NotFound();
            }

            _mapper.Map(drdto, detailedReceipt);

            await _detailedReceiptRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var detailedReceipt = await _detailedReceiptRepository.FindByIdAsync(id, cancellationToken);

            if (detailedReceipt is null)
            {
                return NotFound();
            }

            _detailedReceiptRepository.Delete(detailedReceipt);

            await _detailedReceiptRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}
