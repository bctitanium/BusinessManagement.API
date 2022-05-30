using AutoMapper;
using BusinessManagement.API.DTOs;
using BusinessManagement.Contract;
using BusinessManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class ReceiptController : Controller
    {
        public readonly IMapper _mapper;
        public readonly IReceiptRepository _receiptRepository;

        public ReceiptController(IMapper mapper, IReceiptRepository receiptRepository)
        {
            _mapper = mapper;
            _receiptRepository = receiptRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var receipt = await _receiptRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<ReceiptDTO>>(receipt));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReceiptDTO rdto, CancellationToken cancellationToken = default)
        {
            var receipt = _mapper.Map<Receipt>(rdto);

            _receiptRepository.Add(receipt);

            await _receiptRepository.SaveChangesAsync(cancellationToken);

            return Ok(_mapper.Map<ReceiptDTO>(receipt));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ReceiptDTO rdto, int id, CancellationToken cancellationToken = default)
        {
            var receipt = await _receiptRepository.FindByIdAsync(id, cancellationToken);

            if (receipt is null)
            {
                return NotFound();
            }

            _mapper.Map(rdto, receipt);

            await _receiptRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var receipt = await _receiptRepository.FindByIdAsync(id, cancellationToken);

            if (receipt is null)
            {
                return NotFound();
            }

            _receiptRepository.Delete(receipt);

            await _receiptRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}
