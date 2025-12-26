
using Microsoft.Playwright;
using ReliableHtmlToPdf.Models;
using System.Text;

namespace ReliableHtmlToPdf.Services;
internal sealed class PlaywrightHtmlToPdfConverter : IHtmlToPdfConverter , IAsyncDisposable
{
    private readonly IBrowser _browser;
    private readonly IPlaywright _playwright;

    private PlaywrightHtmlToPdfConverter(IPlaywright playwright, IBrowser browser)
    {
        _browser = browser;
        _playwright = playwright;
    }

    public static async Task<IHtmlToPdfConverter> CreateAsync()
    {
        // Initialize the Playwright driver
        var playwright = await Playwright.CreateAsync();

        try
        {
            // Launch the browser
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,
                // 'Args' help prevent crashes in restricted environments like Docker or IIS
                Args = new[] { "--no-sandbox", "--disable-dev-shm-usage" }
            });

            // Pass both to your class so it can call .Dispose() on both later
            return new PlaywrightHtmlToPdfConverter(playwright, browser);
        }
        catch (Exception)
        {
            // If browser launch fails, clean up the driver to prevent leaks
            playwright.Dispose();
            throw;
        }
    }

    public async Task<byte[]> ConvertAsync(string html,
        PdfOptions? options =null,
        CancellationToken cancellationToken=default)
    {
        if (string.IsNullOrWhiteSpace(html))
            throw new ArgumentException("HTML cannot be empty.");

        if (html.Length > 5_000_000)
            throw new InvalidOperationException("HTML too large.");
        
        options ??= new PdfOptions();

        html = InjectFonts(html, options);

        IPage page = null;

        try
        {
            page = await _browser.NewPageAsync();
            page.SetDefaultTimeout(options.TimeoutMs);

            await page.SetContentAsync(html);

            return await page.PdfAsync(new PagePdfOptions
            {
                Format = options.Format,
                PrintBackground = options.PrintBackground,
                Margin = new Margin
                {
                    Top = $"{options.MarginTop}px",
                    Bottom = $"{options.MarginBottom}px",
                    Left = $"{options.MarginLeft}px",
                    Right = $"{options.MarginRight}px"
                },
                DisplayHeaderFooter = !string.IsNullOrEmpty(options.HeaderHtml)
                                   || !string.IsNullOrEmpty(options.FooterHtml),
                HeaderTemplate = options.HeaderHtml,
                FooterTemplate = options.FooterHtml
            });
        }
        finally
        {
            if (page != null)
                await page.CloseAsync();
        }
    }


    internal static string InjectFonts(string html, PdfOptions options)
    {
        if (options.EmbeddedFonts.Count == 0)
            return html;

        var fontCss = new StringBuilder("<style>");

        foreach (var font in options.EmbeddedFonts)
        {
            fontCss.Append($@"
            @font-face {{
                font-family: '{font.Key}';
                src: url(data:font/ttf;base64,{font.Value}) format('truetype');
                font-weight: normal;
                font-style: normal;
            }}");
        }

        fontCss.Append("</style>");

        return html.Replace("</head>", fontCss + "</head>");
    }

    public async ValueTask DisposeAsync()
    {
        // Proper cleanup sequence
        if (_browser != null) await _browser.CloseAsync();
        _playwright?.Dispose();
    }
}
