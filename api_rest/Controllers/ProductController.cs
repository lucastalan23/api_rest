using api_rest.Domain.Models;
using api_rest.Resources;
using api_rest.Domain.Services;
using api_rest.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using api_rest.Util;

namespace api_rest.Controllers
{
    [Route("/api/[Controller]")]
    [Authorize()]
    public class ProductController : Controller
    {
        private readonly IProductService _iProductService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _iProductService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllAsync()
        {
            var products = await _iProductService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
               
            var product = _mapper.Map<SaveProductResource, Product>(resources);
            var result = await _iProductService.SaveAsync(product);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var productResource = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(productResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductResource resources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var product = _mapper.Map<SaveProductResource, Product>(resources);
            var result = await _iProductService.UpdateAsync(id, product);

            if (!result.Success)
            {
                return BadRequest(result.Message);               
            }

            var productResource = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(productResource);
        }
    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _iProductService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var productResource = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(productResource);
        }
    }
}
