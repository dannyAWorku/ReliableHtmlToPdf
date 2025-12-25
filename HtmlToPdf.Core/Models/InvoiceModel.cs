namespace HtmlToPdf.Core.Models;

public sealed record InvoiceModel(
    string InvoiceNumber,
    DateTime Date,
    string CustomerName,
    IReadOnlyList<InvoiceLine> Lines,
    decimal Total
);
