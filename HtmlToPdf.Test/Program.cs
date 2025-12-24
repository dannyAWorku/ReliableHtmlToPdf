using HtmlToPdf.Core.Models;

var converter = await PlaywrightHtmlToPdfConverter.CreateAsync();

var html = """
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <style>
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; margin: 0; padding: 40px; color: #333; }
        .receipt-box { max-width: 800px; margin: auto; border: 1px solid #eee; padding: 30px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.05); }
        .header { display: flex; justify-content: space-between; border-bottom: 2px solid #00aba9; padding-bottom: 20px; margin-bottom: 20px; }
        .header h1 { margin: 0; color: #00aba9; font-size: 24px; }
        .info { display: flex; justify-content: space-between; margin-bottom: 40px; font-size: 14px; }
        table { width: 100%; border-collapse: collapse; margin-bottom: 40px; }
        table th { background: #f8f8f8; text-align: left; padding: 12px; border-bottom: 2px solid #eee; }
        table td { padding: 12px; border-bottom: 1px solid #eee; }
        .total-section { text-align: right; }
        .total-row { font-size: 18px; font-weight: bold; color: #00aba9; }
        .footer { margin-top: 50px; text-align: center; font-size: 12px; color: #999; border-top: 1px solid #eee; padding-top: 20px; }
    </style>
</head>
<body>
    <div class="receipt-box">
        <div class="header">
            <div>
                <h1>TRANSACTION RECEIPT</h1>
                <p>Order #88291</p>
            </div>
            <div style="text-align: right;">
                <strong>Playwright PDF Services</strong><br>
                123 Tech Avenue, Seattle, WA
            </div>
        </div>

        <div class="info">
            <div>
                <strong>Billed To:</strong><br>
                Daniel<br>
                daniel@example.com
            </div>
            <div style="text-align: right;">
                <strong>Date:</strong> December 24, 2025<br>
                <strong>Status:</strong> <span style="color: green;">PAID</span>
            </div>
        </div>

        <table>
            <thead>
                <tr>
                    <th>Description</th>
                    <th>Quantity</th>
                    <th>Unit Price</th>
                    <th>Total</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>PDF Generation Service (Playwright 1.57.0)</td>
                    <td>1</td>
                    <td>$45.00</td>
                    <td>$45.00</td>
                </tr>
                <tr>
                    <td>Chromium Binary Installation</td>
                    <td>1</td>
                    <td>$0.00</td>
                    <td>$0.00</td>
                </tr>
            </tbody>
        </table>

        <div class="total-section">
            <p>Subtotal: $45.00</p>
            <p>Tax (0%): $0.00</p>
            <p class="total-row">Amount Paid: $45.00</p>
        </div>

        <div class="footer">
            <p>Thank you for using Playwright for .NET!</p>
            <p>This document is a valid receipt for your records.</p>
        </div>
    </div>
</body>
</html>
""";

var html2 = """
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <style>
        @page { size: A4; margin: 2cm; }
        body { font-family: 'Segoe UI', Arial, sans-serif; line-height: 1.6; color: #333; margin: 0; }
        
        /* Cover Page Style */
        .page { page-break-after: always; padding: 40px; border: 1px solid #eee; height: 25cm; position: relative; }
        .cover-content { text-align: center; margin-top: 200px; }
        .cover-content h1 { font-size: 48px; color: #2c3e50; margin-bottom: 10px; }
        .cover-content p { font-size: 20px; color: #7f8c8d; }
        
        /* Content Page Style */
        .section-title { border-bottom: 2px solid #3498db; color: #3498db; padding-bottom: 5px; margin-top: 30px; }
        .data-table { width: 100%; border-collapse: collapse; margin-top: 20px; }
        .data-table th, .data-table td { border: 1px solid #ddd; padding: 12px; text-align: left; }
        .data-table th { background-color: #f2f2f2; }
        
        .placeholder-text { margin-bottom: 20px; text-align: justify; }
        .footer-note { position: absolute; bottom: 40px; width: 100%; text-align: center; color: #bdc3c7; font-size: 12px; }
    </style>
</head>
<body>

    <div class="page">
        <div class="cover-content">
            <h1>ANNUAL REPORT</h1>
            <p>Project: Playwright PDF Automation</p>
            <p>Year: 2025</p>
        </div>
        <div class="footer-note">Confidential - For Internal Use Only</div>
    </div>

    <div class="page">
        <h2 class="section-title">1. Executive Summary</h2>
        <div class="placeholder-text">
            This report details the successful implementation of the <strong>Playwright 1.57.0</strong> engine for 
            server-side PDF generation. By leveraging the Chromium "Chrome for Testing" binary, we have 
            achieved 99.9% rendering accuracy compared to standard browser views.
        </div>
        
        <h2 class="section-title">2. System Performance Data</h2>
        <table class="data-table">
            <thead>
                <tr>
                    <th>Metric</th>
                    <th>Baseline</th>
                    <th>Current</th>
                    <th>Improvement</th>
                </tr>
            </thead>
            <tbody>
                <tr><td>Render Speed</td><td>1200ms</td><td>450ms</td><td>+62%</td></tr>
                <tr><td>Memory Usage</td><td>240MB</td><td>110MB</td><td>+54%</td></tr>
                <tr><td>Font Accuracy</td><td>88%</td><td>100%</td><td>+12%</td></tr>
                <tr><td>Process Stability</td><td>Failing</td><td>Stable</td><td>Resolved</td></tr>
            </tbody>
        </table>
        
        <div class="placeholder-text" style="margin-top: 40px;">
            This content is long enough that if we add a bit more, it would naturally flow to a third page. 
            However, we used the "page-break-after" property on the cover page to force the separation 
            cleanly.
        </div>
    </div>

    <div class="page">
        <h2 class="section-title">3. Deployment Logs</h2>
        <p>Log entries for the browser installation process:</p>
        <ul style="color: #666;">
            <li>[10:15:02] NuGet Package Microsoft.Playwright 1.57.0 restored.</li>
            <li>[10:16:45] Command 'dotnet tool install' executed successfully.</li>
            <li>[10:18:12] Chromium binary download started (v131.0.6778.33).</li>
            <li>[10:20:05] Installation verified in %LOCALAPPDATA%\ms-playwright.</li>
            <li>[10:22:00] First PDF generated successfully.</li>
        </ul>
        <div style="margin-top: 100px; padding: 20px; background: #ebf5fb; border-left: 5px solid #3498db;">
            <strong>Note:</strong> Page 3 confirms that even with complex CSS and multiple pages, 
            the PDF layout remains consistent.
        </div>
    </div>

</body>
</html>
""";

var html3 = """     
    
    <!DOCTYPE html>
    <html>
    <head>
        <meta charset="utf-8" />
        <style>
            @font-face {
                font-family: 'TestFont';
                src: url('file:///C:/Windows/Fonts/arial.ttf') format('truetype');
            }

            body {
                font-family: 'TestFont', sans-serif;
            }
        </style>
    </head>
    <body>
        <h1>Font Test</h1>
        <p>This text should clearly look like Arial.</p>
    </body>
    </html>
    
    """;

var html4 = """
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
</head>
<body style="font-family: Inter;">
    <h1>Font Test</h1>
    <p>This should use Inter.</p>
</body>
</html>
""";

//var pdf = await converter.ConvertAsync(html, new PdfOptions
//{
//    MarginTop = 50,
//    MarginBottom = 50,
//    HeaderHtml = "<div style='font-size:12px; text-align:center;'>Header Text</div>",
//    FooterHtml = "<div style='font-size:12px; text-align:center;'>Page <span class='pageNumber'></span></div>"
//});

//var pdf2 = await converter.ConvertAsync(html2, new PdfOptions
//{
//    MarginTop = 50,
//    MarginBottom = 50,
//    HeaderHtml = "<div style='font-size:12px; text-align:center;'>Header Text</div>",
//    FooterHtml = "<div style='font-size:12px; text-align:center;'>Page <span class='pageNumber'></span></div>"
//});

//var pdf3 = await converter.ConvertAsync(html3, new PdfOptions
//{
//    MarginTop = 50,
//    MarginBottom = 50,
//    HeaderHtml = "<div style='font-size:12px; text-align:center;'>Header Text</div>",
//    FooterHtml = "<div style='font-size:12px; text-align:center;'>Page <span class='pageNumber'></span></div>"
//});
var bytes = File.ReadAllBytes("C:\\Users\\Daniel\\source\\repos\\HtmlToPdf\\HtmlToPdf.Core\\Assets\\Fonts\\Inter_18pt-Regular.ttf");
var base64 = Convert.ToBase64String(bytes);
var options = new PdfOptions
{
    PrintBackground = true
};
options.EmbeddedFonts.Add("Inter", base64);
var pdf4 = await converter.ConvertAsync(html4, options);

//File.WriteAllBytes("C:\\Users\\Daniel\\Desktop\\test1.pdf", pdf);
//File.WriteAllBytes("C:\\Users\\Daniel\\Desktop\\test2.pdf", pdf2);
//File.WriteAllBytes("C:\\Users\\Daniel\\Desktop\\test3.pdf", pdf3);
File.WriteAllBytes("C:\\Users\\Daniel\\Desktop\\test4.pdf", pdf4);
