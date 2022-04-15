using AutoMapper;
using BusinessManagement.API.DTOs;
using BusinessManagement.Contract;
using BusinessManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class StoreController : Controller
    {
        public readonly IMapper _mapper;
        public readonly IStoreRepository _storeRepository;

        public StoreController(IMapper mapper, IStoreRepository storeRepository)
        {
            _mapper = mapper;
            _storeRepository = storeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var store = await _storeRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<StoreDTO>>(store));
        }

        //[HttpGet]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var store = await _storeRepository.FindByIdAsync(id);
        //    if (store is null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_mapper.Map<StoreDTO>(store));
        //}

        [HttpPost]
        public async Task<IActionResult> Create(StoreDTO sdto, CancellationToken cancellationToken = default) //cái này để tạo cửa hàng
        {
            var store = _mapper.Map<Store>(sdto);

            _storeRepository.Add(store);

            await _storeRepository.SaveChangesAsync(cancellationToken);

            return Ok(_mapper.Map<StoreDTO>(store));
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] StoreDTO sdto, CancellationToken cancellationToken = default)
        //{
        //    var store = _mapper.Map<Store>(sdto);

        //    //Add Supplier to Store
        //    foreach (var supplier in sdto.ProductSuppliers)
        //    {
        //        var foundSupplier = await _productSupplierRepository.FindByIdAsync(supplier);
        //        if (foundSupplier is null)
        //        {
        //            return NotFound($"SupplierId {supplier} not found");
        //        }

        //        store.ProductSuppliers.Add(foundSupplier);
        //    }

        //    _storeRepository.Add(store);
        //    await _storeRepository.SaveChangesAsync(cancellationToken);

        //    //return Ok(_mapper.Map<StoreDTO>(store));
        //    return CreatedAtAction(nameof(Get), new { store.Id }, _mapper.Map<StoreDTO>(store));
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] StoreDTO sdto, int id, CancellationToken cancellationToken = default)
        {
            var store = await _storeRepository.FindByIdAsync(id, cancellationToken);

            if (store is null)
            {
                return NotFound();
            }

            _mapper.Map(sdto, store);

            await _storeRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var store = await _storeRepository.FindByIdAsync(id, cancellationToken);

            if (store is null)
            {
                return NotFound();
            }

            _storeRepository.Delete(store);

            await _storeRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}
