using HtmlToPdf.Core.Abstractions;

namespace HtmlToPdf.Core.Models;

public abstract class PdfTemplateBase<TModel> : IPdfTemplate<TModel>
{
    public string Render(TModel model)
    {
        return $"""
        <!DOCTYPE html>
        <html>
        <head>
        <meta charset="utf-8">
        {Styles()}
        </head>
        <body>
        {Body(model)}
        </body>
        </html>
        """;
    }

    protected abstract string Body(TModel model);

    protected virtual string Styles() => """
        <style>
        body {
            font-family: Inter;
            font-size: 12px;
            color: #111;
        }
        h1 {
            font-size: 20px;
        }
        table {
            width: 100%;
            border-collapse: collapse;
        }
        th, td {
            padding: 6px;
            border-bottom: 1px solid #ddd;
        }
        .page-break {
            page-break-before: always;
        }

        .no-break {
            page-break-inside: avoid;
        }

        table {
            page-break-inside: auto;
        }

        tr {
            page-break-inside: avoid;
            page-break-after: auto;
        }

        thead {
            display: table-header-group;
        }

        tfoot {
            display: table-footer-group;
        }
        
        </style>
        """;
}

