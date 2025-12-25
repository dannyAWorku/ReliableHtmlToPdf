using ReliableHtmlToPdf.Models;

namespace ReliableHtmlToPdf.Abstractions;

/// <summary>
/// Converts HTML content into a PDF document.
/// </summary>
public interface IHtmlToPdfConverter : IAsyncDisposable
{
    /// <summary>
    /// Converts the given HTML into a PDF byte array.
    /// </summary>
    /// <param name="html">Complete HTML document including head and body.</param>
    /// <param name="options">PDF rendering options.</param>
    /// <returns>PDF as byte array.</returns>
    Task<byte[]> ConvertAsync(string html, PdfOptions options);
}

