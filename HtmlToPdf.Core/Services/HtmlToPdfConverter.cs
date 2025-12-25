using ReliableHtmlToPdf.Abstractions;
using ReliableHtmlToPdf.Services;

namespace HtmlToPdf.Core.Services;

public static class HtmlToPdfConverter
{
    public static Task<IHtmlToPdfConverter> CreateAsync()
        => PlaywrightHtmlToPdfConverter.CreateAsync();
}

