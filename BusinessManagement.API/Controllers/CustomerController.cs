using AutoMapper;
using BusinessManagement.API.DTOs;
using BusinessManagement.Contract;
using BusinessManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        public readonly IMapper _mapper;
        public readonly ICustomerRepository _customerRepository;

        public CustomerController(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var customer = await _customerRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<CustomerDTO>>(customer));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerDTO cdto, CancellationToken cancellationToken = default)
        {
            var customer = _mapper.Map<Customer>(cdto);

            _customerRepository.Add(customer);

            await _customerRepository.SaveChangesAsync(cancellationToken);

            return Ok(_mapper.Map<CustomerDTO>(customer));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CustomerDTO cdto, int id, CancellationToken cancellationToken = default)
        {
            var customer = await _customerRepository.FindByIdAsync(id, cancellationToken);

            if (customer is null)
            {
                return NotFound();
            }

            _mapper.Map(cdto, customer);

            await _customerRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var customer = await _customerRepository.FindByIdAsync(id, cancellationToken);

            if (customer is null)
            {
                return NotFound();
            }

            _customerRepository.Delete(customer);

            await _customerRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}
