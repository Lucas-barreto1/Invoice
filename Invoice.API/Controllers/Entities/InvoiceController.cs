using Invoice.Core.Dtos;
using Invoice.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.API.Controllers.Entities{ 
    [ApiController]
    [Route("invoice")]
    public class InvoiceController: Controller
    {
        private readonly IInvoiceRepository _invoiceRepository;
        
        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _invoiceRepository.GetAllAsync();
            return Ok(invoices);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoice(Guid id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            var invoiceDto = new InvoiceResponseDto
            {
                IssueDate = invoice.IssueDate,
                TotalAmount = invoice.TotalAmount,
                CustomerId = invoice.CustomerId,
                InvoiceItemsIds = invoice.InvoiceItems.Select(i => i.Id).ToList()
            };
            return Ok(invoiceDto);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] Domain.Entities.Invoice invoice)
        {
            _invoiceRepository.Add(invoice);
            _invoiceRepository.Save();
            return Ok(await _invoiceRepository.GetByIdAsync(invoice.Id));
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateInvoice([FromBody] Domain.Entities.Invoice invoice)
        {
            _invoiceRepository.Update(invoice);
            _invoiceRepository.Save();
            return Ok(await _invoiceRepository.GetByIdAsync(invoice.Id));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(Guid id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            _invoiceRepository.Delete(invoice);
            _invoiceRepository.Save();
            return Ok();
        }
    }
}