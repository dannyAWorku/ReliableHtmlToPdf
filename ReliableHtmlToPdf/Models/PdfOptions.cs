namespace ReliableHtmlToPdf.Models;

public sealed class PdfOptions
{
    public string Format { get; init; } = "A4";
    public bool Landscape { get; init; }
    public bool PrintBackground { get; init; } = true;

    // New: Margins in pixels
    public float MarginTop { get; init; } = 20;
    public float MarginBottom { get; init; } = 20;
    public float MarginLeft { get; init; } = 20;
    public float MarginRight { get; init; } = 20;

    // New: Headers/Footers
    public string HeaderHtml { get; init; } = string.Empty;
    public string FooterHtml { get; init; } = string.Empty;

    // New: Custom Fonts (base64 embedded)
    public Dictionary<string, string> EmbeddedFonts { get; init; } = new();

    public int TimeoutMs { get; init; } = 30_000;
    // New: Timeout in milliseconds
}

