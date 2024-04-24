using Invoice.Domain.Entities;
using Invoice.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.API.Controllers.Entities{
    [ApiController]
    [Route("product")]
    public class ProductController: Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return Ok(product);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            _productRepository.Add(product);
            _productRepository.Save();
            return Ok(await _productRepository.GetByIdAsync(product.Id));
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            _productRepository.Update(product);
            _productRepository.Save();
            return Ok(await _productRepository.GetByIdAsync(product.Id));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            _productRepository.Delete(product);
            _productRepository.Save();
            return Ok();
        }
    }

}