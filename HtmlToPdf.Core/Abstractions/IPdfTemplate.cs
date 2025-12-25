namespace ReliableHtmlToPdf.Abstractions;

public interface IPdfTemplate<TModel>
{
    string Render(TModel model);
}
