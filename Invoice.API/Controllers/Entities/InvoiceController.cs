using Invoice.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.API.Controllers.Entities{ 
    [ApiController]
    [Route("invoice")]
    public class InvoiceController: Controller
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IMediator _mediator;
        private readonly IInvoiceRepository _invoiceRepository;
        
        public InvoiceController(ILogger<InvoiceController> logger, IMediator mediator, IInvoiceRepository invoiceRepository)
        {
            _logger = logger;
             _mediator = mediator;
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
            return Ok(invoice);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] Domain.Entities.Invoice invoice)
        {
            _invoiceRepository.Add(invoice);
            _invoiceRepository.Save();
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateInvoice([FromBody] Domain.Entities.Invoice invoice)
        {
            _invoiceRepository.Update(invoice);
            _invoiceRepository.Save();
            return Ok();
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