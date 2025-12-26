# ReliableHtmlToPdf

ReliableHtmlToPdf is a lightweight, production-ready **HTML to PDF converter for .NET** built on top of **Microsoft Playwright (Chromium)**.

It is designed for:

* Server-side PDF generation
* Large HTML documents
* Embedded fonts
* Headers, footers, and page numbers
* Reliable rendering across environments (Windows, Linux, Docker)

---

## ✨ Features

* ✅ Chromium-based rendering (high fidelity)
* ✅ Embedded fonts (Base64)
* ✅ Headers & footers
* ✅ Page margins & print backgrounds
* ✅ Large HTML support
* ✅ Async & memory-safe
* ✅ No native dependencies

---

## 📦 Installation

```powershell
dotnet add package ReliableHtmlToPdf
```

---

## 🚀 Basic Usage

```csharp
using ReliableHtmlToPdf.Models;
using ReliableHtmlToPdf;

await using var converter = await HtmlToPdfConverter.CreateAsync();

var html = """
<!DOCTYPE html>
<html>
<head>
  <style>
    body { font-family: Arial; }
  </style>
</head>
<body>
  <h1>Hello PDF</h1>
  <p>This PDF was generated using ReliableHtmlToPdf.</p>
</body>
</html>
""";

var options = new PdfOptions
{
    PrintBackground = true,
    MarginTop = 60,
    MarginBottom = 60,
    MarginLeft = 40,
    MarginRight = 40
};

byte[] pdf = await converter.ConvertAsync(html, options);

await File.WriteAllBytesAsync("output.pdf", pdf);
```

---

## 🔤 Embedded Fonts

ReliableHtmlToPdf supports fully embedded fonts using Base64 encoding.
This ensures consistent rendering across all environments (Windows, Linux, Docker).

### Add Embedded Font (C#)

```csharp
options.EmbeddedFonts.Add("Inter", interBase64);
```

### Use the Font (HTML)

```html
<style>
body {
  font-family: 'Inter';
}
</style>
```

---

## 📄 Headers & Footers

Headers and footers support dynamic page numbers using Chromium placeholders.

```csharp
options.HeaderHtml = """
<div style="font-size:10px; text-align:center; width:100%;">
  ReliableHtmlToPdf Demo
</div>
""";

options.FooterHtml = """
<div style="font-size:10px; text-align:center; width:100%;">
  Page <span class="pageNumber"></span> of <span class="totalPages"></span>
</div>
""";
```

---

## 🧠 Notes

* Chromium is downloaded automatically on first run by Playwright
* Suitable for APIs, background jobs, and server-side rendering
* Always dispose the converter after use

---

## 📜 License

MIT License
© Daniel Alemu
