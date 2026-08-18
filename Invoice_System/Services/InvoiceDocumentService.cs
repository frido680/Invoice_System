using Invoice_System.DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;


namespace Invoice_System.Services
{
    public class InvoiceDocumentService
    {
        private readonly string _outPutPath;
        public InvoiceDocumentService()
        {
            _outPutPath = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(_outPutPath);
        }

        public string GeneratePdf(InvoiceResponseDto invoice)
        {
            var fileName = $"Invoice_Order_{invoice.OrderId}.pdf";
            var filePath = Path.Combine(_outPutPath, fileName);

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(40);

                    page.Content()
                        .Column(column =>
                        {
                            column.Item()
                                .Text("INVOICE")
                                .FontSize(24)
                                .Bold();

                            column.Item().PaddingTop(20);

                            column.Item()
                                .Text($"Customer: {invoice.CustomerId}");

                            column.Item()
                                .Text($"Date: {invoice.OrderDate:yyyy-MM-dd}");

                            column.Item().PaddingTop(20);

                            column.Item()
                                .Text("ITEMS")
                                .Bold();

                            column.Item().PaddingTop(10);

                            foreach (var line in invoice.Lines)
                            {
                                column.Item()
                                    .Text(
                                        $"{line.ProductName}    " +
                                        $"{line.Quantity} x " +
                                        $"{line.UnitPrice:N2} = " +
                                        $"{line.LineTotal:N2} Ft");

                                if (line.Discount > 0)
                                {
                                    column.Item()
                                        .Text($"  - {line.Discount}% discount");
                                }

                                if (line.IsFragile)
                                {
                                    column.Item()
                                        .Text("  - FRAGILE");
                                }
                            }

                            column.Item().PaddingTop(20);

                            column.Item()
                                .Text($"TOTAL: {invoice.TotalAmount:N2} Ft")
                                .FontSize(16)
                                .Bold();
                        });
                });
            })
            .GeneratePdf(filePath);
            return filePath;
        }
    }
}
