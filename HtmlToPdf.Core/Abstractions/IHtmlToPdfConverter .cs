using HtmlToPdf.Core.Models;

namespace HtmlToPdf.Core.Abstractions;

public interface IHtmlToPdfConverter : IAsyncDisposable
{
    Task<byte[]> ConvertAsync(string html, PdfOptions options);
}

