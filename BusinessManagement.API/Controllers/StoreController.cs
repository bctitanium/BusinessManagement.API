﻿using AutoMapper;
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
        public readonly IProductRepository _productRepository;

        public StoreController(IMapper mapper, IStoreRepository storeRepository, IProductRepository productRepository)
        {
            _mapper = mapper;
            _storeRepository = storeRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var store = await _storeRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<StoreDTO>>(store));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var store = await _storeRepository.FindByIdAsync(id);

            if (store is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StoreDTO>(store));
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(StoreDTO sdto, CancellationToken cancellationToken = default) //cái này để tạo cửa hàng
        //{
        //    var store = _mapper.Map<Store>(sdto);

        //    _storeRepository.Add(store);

        //    await _storeRepository.SaveChangesAsync(cancellationToken);

        //    return Ok(_mapper.Map<StoreDTO>(store));
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StoreDTO sdto, CancellationToken cancellationToken = default)
        {
            var store = _mapper.Map<Store>(sdto);

            //Add Supplier to Store
            foreach (var product in sdto.Products)
            {
                var foundProduct = await _productRepository.FindByIdAsync(sdto.Id, cancellationToken);
                
                if (foundProduct is null)
                {
                    return NotFound($"ProductId {product} not found");
                }

                store.Products.Add(foundProduct);
            }

            _storeRepository.Add(store);
            await _storeRepository.SaveChangesAsync(cancellationToken);

            return CreatedAtAction(nameof(Get), new { store.Id }, _mapper.Map<StoreDTO>(store));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] StoreDTO sdto, int id, CancellationToken cancellationToken = default)
        {
            var store = await _storeRepository.FindByIdAsync(id, cancellationToken);

            if (store is null)
            {
                return NotFound();
            }

            _mapper.Map(sdto, store);

            ICollection<Product> products = store.Products;
            ICollection<int> requestProducts = sdto.Products;
            ICollection<int> originalProducts = store.Products.Select(s => s.Id).ToList();

            //Delete product from store
            ICollection<int> deleteProducts = originalProducts.Except(requestProducts).ToList();
            if (deleteProducts.Count > 0)
            {
                foreach (var product in deleteProducts)
                {
                    var foundProduct = await _productRepository.FindByIdAsync(sdto.Id, cancellationToken);
                    
                    if (foundProduct is null)
                    {
                        return NotFound($"productId {product} not found");
                    }

                    products.Remove(foundProduct);
                }
            }

            //Add new product to store
            ICollection<int> newProducts = requestProducts.Except(originalProducts).ToList();
            if (newProducts.Count > 0)
            {
                foreach (var product in newProducts)
                {
                    var foundProduct = await _productRepository.FindByIdAsync(sdto.Id, cancellationToken);

                    if (foundProduct is null)
                    {
                        return NotFound($"productId {product} not found");
                    }

                    products.Add(foundProduct);
                }
            }

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
