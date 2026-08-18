using Invoice_System.Data;
using Invoice_System.Services;
using Microsoft.AspNetCore.Mvc;


namespace Invoice_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private readonly InvoiceService _invoiceService;
        private readonly InvoiceDocumentService _invoiceDocumentService;
        public InvoiceController(
            InvoiceService invoiceService,
            InvoiceDocumentService invoiceDocumentService
            )
        {
            _invoiceService = invoiceService;
            _invoiceDocumentService = invoiceDocumentService;
        }
        [HttpGet]
        public async Task<IActionResult> GenerateInvoice(int orderId)
        {
            var invoice = await _invoiceService.GenerateInvoiceAsync(orderId);
            if (invoice == null)
            {
                return NotFound($"Order with ID {orderId} not found.");
            }
            return Ok(invoice);
        }

        [HttpGet("{orderId}/pdf")]
        public async Task<IActionResult> GenerateInvoicePdf(int orderId)
        {
            var invoice = await _invoiceService.GenerateInvoiceAsync(orderId);

            if (invoice == null)
            {
                return NotFound();
            }

            var filePath = _invoiceDocumentService.GeneratePdf(invoice);

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);

            return File(
                fileBytes,
                "application/pdf",
                Path.GetFileName(filePath));
        }
    }
}
