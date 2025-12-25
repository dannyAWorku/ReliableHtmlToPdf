using ReliableHtmlToPdf.Models;

namespace ReliableHtmlToPdf;

/// <summary>
/// Converts HTML content into a PDF document.
/// </summary>
public interface IHtmlToPdfConverter : IAsyncDisposable
{
    /// <summary>
    /// Asynchronously converts the specified HTML content to a PDF document.
    /// </summary>
    /// <param name="html">The HTML markup to convert to PDF. Cannot be null or empty.</param>
    /// <param name="options">Optional settings that control PDF generation, such as page size, margins, or headers. If null, default options
    /// are used.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a byte array with the generated PDF
    /// document.</returns>
    Task<byte[]> ConvertAsync(string html, 
        PdfOptions? options=null,
        CancellationToken cancellationToken=default);
}

