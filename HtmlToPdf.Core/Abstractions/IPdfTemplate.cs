namespace HtmlToPdf.Core.Abstractions;

public interface IPdfTemplate<TModel>
{
    string Render(TModel model);
}
