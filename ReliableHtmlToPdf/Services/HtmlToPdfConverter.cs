using ReliableHtmlToPdf.Services;

namespace ReliableHtmlToPdf;

public static class HtmlToPdfConverter
{
    public static Task<IHtmlToPdfConverter> CreateAsync()
        => PlaywrightHtmlToPdfConverter.CreateAsync();
}

