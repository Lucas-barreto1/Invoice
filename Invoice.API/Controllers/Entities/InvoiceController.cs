using Invoice.Core.Dtos;
using Invoice.Domain.Entities;
using Invoice.Domain.Interfaces;
using Invoice.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.API.Controllers.Entities{ 
    [ApiController]
    [Route("invoice")]
    public class InvoiceController: Controller
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IProductRepository _productRepository;
        
        public InvoiceController(IInvoiceRepository invoiceRepository, IProductRepository productRepository)
        {
            _invoiceRepository = invoiceRepository;
            _productRepository = productRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _invoiceRepository.GetAllAsync();
            var invoiceDtos = MapToInvoiceResponseDtoList(invoices);
            return Ok(invoiceDtos);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoice(Guid id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if(invoice == null)
                return NotFound();
            var invoiceDto = MapToInvoiceResponseDto(invoice);
            return Ok(invoiceDto);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateInvoice(InvoiceDto invoiceDto)
        {
            var invoice = MapToInvoice(invoiceDto);
            _invoiceRepository.Add(invoice);
            _invoiceRepository.Save();
            return CreatedAtAction(nameof(GetInvoice), new { id = invoice.Id }, MapToInvoiceResponseDto(invoice));
        }
    
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice(Guid id, InvoiceDto invoiceDto)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if(invoice == null)
                return NotFound();
            
            invoice.IssueDate = invoiceDto.IssueDate;
            invoice.CustomerId = invoiceDto.CustomerId;
            invoice.InvoiceItems.Clear();
            foreach (var item in invoiceDto.InvoiceItems)
            {
                var product = _productRepository.GetByIdAsync(item.ProductId).Result;
                invoice.addInvoiceItem(product, item.Quantity);
            }
            
            _invoiceRepository.Update(invoice);
            _invoiceRepository.Save();
            return Ok(MapToInvoiceResponseDto(invoice));
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(Guid id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null)
                return NotFound();
            _invoiceRepository.Delete(invoice);
            _invoiceRepository.Save();
            return NoContent();
        }
        
        private InvoiceResponseDto MapToInvoiceResponseDto(Domain.Entities.Invoice invoice)
        {
            return new InvoiceResponseDto
            {
                Id = invoice.Id,
                IssueDate = invoice.IssueDate,
                TotalAmount = invoice.TotalAmount,
                CustomerId = invoice.CustomerId,
                InvoiceItems = invoice.InvoiceItems.Select(i => new InvoiceItemResponseDto
                {
                    Product = i.Product,
                    Quantity = i.Quantity
                }).ToList()
            };
        }
        
        private Domain.Entities.Invoice MapToInvoice(InvoiceDto invoiceDto)
        {
            var invoice = new Domain.Entities.Invoice
            {
                Id = invoiceDto.Id,
                IssueDate = invoiceDto.IssueDate,
                CustomerId = invoiceDto.CustomerId,
            };
            
            foreach (var item in invoiceDto.InvoiceItems)
            {
                var product = _productRepository.GetByIdAsync(item.ProductId).Result;
                invoice.addInvoiceItem(product, item.Quantity);
            }
            
            return invoice;
        }
        
        private List<InvoiceResponseDto> MapToInvoiceResponseDtoList(IEnumerable<Domain.Entities.Invoice> invoices)
        {
            return invoices.Select(MapToInvoiceResponseDto).ToList();
        }
    }
}