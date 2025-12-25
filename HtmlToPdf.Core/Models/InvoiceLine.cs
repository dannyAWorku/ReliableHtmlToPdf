namespace ReliableHtmlToPdf.Models;

public sealed record InvoiceLine(
    string Description,
    int Quantity,
    decimal UnitPrice
);
