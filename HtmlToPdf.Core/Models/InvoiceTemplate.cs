namespace HtmlToPdf.Core.Models;

public sealed class InvoiceTemplate
    : PdfTemplateBase<InvoiceModel>
{
    protected override string Body(InvoiceModel model)
    {
        var rows = string.Join("", model.Lines.Select(l => $"""
<tr>
  <td>{l.Description}</td>
  <td>{l.Quantity}</td>
  <td>{l.UnitPrice:C}</td>
</tr>
"""));

        return $"""
<h1>Invoice</h1>

<p>
<strong>Invoice #:</strong> {model.InvoiceNumber}<br/>
<strong>Date:</strong> {model.Date:yyyy-MM-dd}<br/>
<strong>Customer:</strong> {model.CustomerName}
</p>

<table>
<thead>
<tr>
  <th>Description</th>
  <th>Qty</th>
  <th>Unit Price</th>
</tr>
</thead>
<tbody>
{rows}
</tbody>
</table>

<div class="page-break"></div>

<div class="no-break">
    <h3>Total</h3>
    <p>{model.Total:C}</p>
</div>
""";
    }
}

