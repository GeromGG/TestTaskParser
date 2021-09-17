using AngleSharp.Html.Dom;

namespace TestTaskParser.Interfaces
{
    public interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
