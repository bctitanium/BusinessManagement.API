using AutoMapper;
using BusinessManagement.API.DTOs;
using BusinessManagement.Contract;
using BusinessManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class StaffController : Controller
    {
        public readonly IMapper _mapper;
        public readonly IStaffRepository _staffRepository;

        public StaffController(IMapper mapper, IStaffRepository staffRepository)
        {
            _mapper = mapper;
            _staffRepository = staffRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var staff = await _staffRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<StaffDTO>>(staff));
        }

        [HttpPost]
        public async Task<IActionResult> Create(StaffDTO sdto, CancellationToken cancellationToken = default)
        {
            var staff = _mapper.Map<Staff>(sdto);

            _staffRepository.Add(staff);

            await _staffRepository.SaveChangesAsync(cancellationToken);

            return Ok(_mapper.Map<StaffDTO>(staff));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] StaffDTO sdto, int id, CancellationToken cancellationToken = default)
        {
            var staff = await _staffRepository.FindByIdAsync(id, cancellationToken);

            if (staff is null)
            {
                return NotFound();
            }

            _mapper.Map(sdto, staff);

            await _staffRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var staff = await _staffRepository.FindByIdAsync(id, cancellationToken);

            if (staff is null)
            {
                return NotFound();
            }

            _staffRepository.Delete(staff);

            await _staffRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}
