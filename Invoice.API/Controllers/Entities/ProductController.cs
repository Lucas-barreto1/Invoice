using Invoice.Core.Dtos;
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
            var productDTOs = MapToProductResponseDtoList(products);
            return Ok(productDTOs);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            var productDto = MapToProductResponseDto(product);
            return Ok(productDto);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto productDTO)
        {
            var product = MapToProduct(productDTO);
            _productRepository.Add(product);
            _productRepository.Save();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, MapToProductResponseDto(product));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, ProductDto productDTO)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if(existingProduct == null)
                return NotFound();
            
            existingProduct.Name = productDTO.Name;
            existingProduct.Price = productDTO.Price;
            
            _productRepository.Update(existingProduct);
            _productRepository.Save();
            return Ok(MapToProductResponseDto(existingProduct));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            _productRepository.Delete(product);
            _productRepository.Save();
            return NoContent();
        }
        
        private ProductResponseDto MapToProductResponseDto(Product product)
        {
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
        
        private Product MapToProduct(ProductDto productDto)
        {
            return new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price
            };
        }
        
        private List<ProductResponseDto> MapToProductResponseDtoList(IEnumerable<Product> products)
        {
            return products.Select(MapToProductResponseDto).ToList();
        }
    }

}